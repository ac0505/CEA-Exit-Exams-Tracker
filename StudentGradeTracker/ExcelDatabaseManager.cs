using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace StudentGradeTracker
{
    /// <summary>
    /// Handles all Excel file I/O and acts as the central data store for CEA Exit Exams Tracker.
    /// The in-memory list is kept in sync with the Excel file, ensuring Excel is always the source of truth.
    /// Fires the DataChanged event whenever data is added, updated, deleted, or imported.
    /// </summary>
    public class ExcelDatabaseManager
    {
        public static ExcelDatabaseManager Instance { get; } = new ExcelDatabaseManager();

        public static string FilePath
        {
            get
            {
                string inBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentDatabase.xlsx");
                if (File.Exists(inBase)) return inBase;

                string inCwd = Path.Combine(Directory.GetCurrentDirectory(), "StudentDatabase.xlsx");
                if (File.Exists(inCwd)) return inCwd;

                return inBase;
            }
        }

        public static readonly string[] ValidPrograms =
            { "AR", "CE", "CHE", "CPE", "ECE", "EE", "IE", "ME" };

        public event Action? DataChanged;

        private readonly List<StudentRecord> _students = new List<StudentRecord>();
        private readonly object _lock = new object();

        public ExcelDatabaseManager()
        {
            Load();
        }

        // ───────────────────────── Read / Load ─────────────────────────

        public List<StudentRecord> GetAllStudents()
        {
            lock (_lock)
            {
                return new List<StudentRecord>(_students);
            }
        }

        public void Load()
        {
            lock (_lock)
            {
                _students.Clear();

                string path = FilePath;
                if (!File.Exists(path))
                {
                    return;
                }

                try
                {
                    using (var wb = new XLWorkbook(path))
                    {
                        var ws = GetTargetWorksheet(wb);
                        if (ws == null || ws.RowsUsed().Count() <= 1)
                        {
                            return;
                        }

                        var map = GetColumnMapping(ws);

                        foreach (var row in ws.RowsUsed().Skip(1))
                        {
                            string id = Val(row, map, "School ID", "Student ID", "StudentID", "ID");
                            if (string.IsNullOrWhiteSpace(id)) continue;

                            _students.Add(new StudentRecord
                            {
                                SchoolID      = id,
                                FirstName     = Val(row, map, "First Name", "Firstname", "Given Name"),
                                LastName      = Val(row, map, "Last Name", "Lastname", "Surname"),
                                MiddleInitial = Val(row, map, "M.I", "M.I.", "Middle Initial", "MiddleInitial"),
                                Program       = NormalizeProgram(Val(row, map, "Program", "Course", "Degree")),
                                CourseCode    = Val(row, map, "Course Code", "CourseCode", "Subject Code"),
                                Section       = Val(row, map, "Section", "Sec"),
                                Status        = Val(row, map, "Status"),
                                Term          = Val(row, map, "Term", "Semester"),
                                SchoolYear    = Val(row, map, "School Year", "SchoolYear", "SY", "Academic Year")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ExcelDatabaseManager.Load Error]: {ex.Message}");
                }
            }
        }

        // ───────────────────────── Write / Save ────────────────────────

        /// <summary>
        /// Saves all student records to StudentDatabase.xlsx with specified header and status cell formatting.
        /// </summary>
        public void SaveAll()
        {
            lock (_lock)
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet("Grades");

                    string[] headers = {
                        "School ID", "First Name", "Last Name", "M.I",
                        "Program", "Course Code", "Section", "Status",
                        "Term", "School Year"
                    };

                    for (int c = 0; c < headers.Length; c++)
                    {
                        ws.Cell(1, c + 1).Value = headers[c];
                    }

                    // Header styling: #303030 background, bold sans-serif, white text
                    var hdr = ws.Range(1, 1, 1, headers.Length);
                    hdr.Style.Font.Bold = true;
                    hdr.Style.Font.FontName = "Segoe UI";
                    hdr.Style.Fill.BackgroundColor = XLColor.FromArgb(0x30, 0x30, 0x30);
                    hdr.Style.Font.FontColor = XLColor.White;
                    hdr.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    for (int i = 0; i < _students.Count; i++)
                    {
                        int r = i + 2;
                        var s = _students[i];

                        ws.Cell(r, 1).Value  = s.SchoolID;
                        ws.Cell(r, 2).Value  = s.FirstName;
                        ws.Cell(r, 3).Value  = s.LastName;
                        ws.Cell(r, 4).Value  = s.MiddleInitial;
                        ws.Cell(r, 5).Value  = NormalizeProgram(s.Program);
                        ws.Cell(r, 6).Value  = s.CourseCode;
                        ws.Cell(r, 7).Value  = s.Section;
                        ws.Cell(r, 8).Value  = s.Status;
                        ws.Cell(r, 9).Value  = s.Term;
                        ws.Cell(r, 10).Value = s.SchoolYear;

                        // Status colors: Passed -> light green #8CFF8A, Completion -> light yellow #FBFF8A
                        var statusCell = ws.Cell(r, 8);
                        if (string.Equals(s.Status, "Passed", StringComparison.OrdinalIgnoreCase))
                        {
                            statusCell.Style.Fill.BackgroundColor = XLColor.FromArgb(0x8C, 0xFF, 0x8A);
                        }
                        else if (string.Equals(s.Status, "Completion", StringComparison.OrdinalIgnoreCase))
                        {
                            statusCell.Style.Fill.BackgroundColor = XLColor.FromArgb(0xFB, 0xFF, 0x8A);
                        }
                    }

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(FilePath);
                }
            }

            NotifyDataChanged();
        }

        // ───────────────────────── CRUD Operations ─────────────────────

        public bool AddStudent(StudentRecord student, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(student.SchoolID))
            {
                errorMessage = "School ID is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName))
            {
                errorMessage = "First Name and Last Name are required.";
                return false;
            }

            student.Program = NormalizeProgram(student.Program);
            if (!IsValidProgram(student.Program))
            {
                errorMessage = $"Program must be one of: {string.Join(", ", ValidPrograms)}.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.CourseCode))
            {
                errorMessage = "Course Code is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.Status))
            {
                student.Status = "Completion";
            }
            else if (!student.Status.Equals("Passed", StringComparison.OrdinalIgnoreCase) &&
                     !student.Status.Equals("Completion", StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Status must be either 'Passed' or 'Completion'.";
                return false;
            }

            lock (_lock)
            {
                // Check duplicate: same School ID + Course Code
                bool exists = _students.Any(s =>
                    s.SchoolID.Equals(student.SchoolID, StringComparison.OrdinalIgnoreCase) &&
                    s.CourseCode.Equals(student.CourseCode, StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    errorMessage = $"A record for School ID '{student.SchoolID}' in course '{student.CourseCode}' already exists.";
                    return false;
                }

                _students.Add(student);
            }

            SaveAll();
            return true;
        }

        public void UpdateStatus(IEnumerable<StudentRecord> targetStudents, string newStatus)
        {
            lock (_lock)
            {
                var targetSet = new HashSet<StudentRecord>(targetStudents);
                foreach (var s in _students)
                {
                    if (targetSet.Contains(s))
                    {
                        s.Status = newStatus;
                    }
                }
            }

            SaveAll();
        }

        public void DeleteStudents(IEnumerable<StudentRecord> targetStudents)
        {
            lock (_lock)
            {
                var targetSet = new HashSet<StudentRecord>(targetStudents);
                _students.RemoveAll(s => targetSet.Contains(s));
            }

            SaveAll();
        }

        public int ImportFromFile(string externalFilePath, out string message)
        {
            message = string.Empty;
            if (!File.Exists(externalFilePath))
            {
                message = "The selected file does not exist.";
                return 0;
            }

            int imported = 0;
            int skipped = 0;

            try
            {
                using (var wb = new XLWorkbook(externalFilePath))
                {
                    var ws = GetTargetWorksheet(wb);
                    if (ws == null || ws.RowsUsed().Count() <= 1)
                    {
                        message = "The selected Excel file contains no data rows.";
                        return 0;
                    }

                    var map = GetColumnMapping(ws);

                    lock (_lock)
                    {
                        foreach (var row in ws.RowsUsed().Skip(1))
                        {
                            string id = Val(row, map, "School ID", "Student ID", "StudentID", "ID");
                            if (string.IsNullOrWhiteSpace(id)) continue;

                            string course = Val(row, map, "Course Code", "CourseCode", "Subject Code");
                            string program = NormalizeProgram(Val(row, map, "Program", "Course", "Degree"));
                            string status = Val(row, map, "Status");
                            if (string.IsNullOrWhiteSpace(status)) status = "Completion";

                            // Duplicate check against current student database
                            bool isDup = _students.Any(s =>
                                s.SchoolID.Equals(id, StringComparison.OrdinalIgnoreCase) &&
                                s.CourseCode.Equals(course, StringComparison.OrdinalIgnoreCase));

                            if (isDup)
                            {
                                skipped++;
                                continue;
                            }

                            _students.Add(new StudentRecord
                            {
                                SchoolID      = id,
                                FirstName     = Val(row, map, "First Name", "Firstname", "Given Name"),
                                LastName      = Val(row, map, "Last Name", "Lastname", "Surname"),
                                MiddleInitial = Val(row, map, "M.I", "M.I.", "Middle Initial", "MiddleInitial"),
                                Program       = program,
                                CourseCode    = course,
                                Section       = Val(row, map, "Section", "Sec"),
                                Status        = status,
                                Term          = Val(row, map, "Term", "Semester"),
                                SchoolYear    = Val(row, map, "School Year", "SchoolYear", "SY", "Academic Year")
                            });

                            imported++;
                        }
                    }
                }

                if (imported > 0)
                {
                    SaveAll();
                }

                message = $"Successfully imported {imported} student record(s).";
                if (skipped > 0)
                {
                    message += $" ({skipped} duplicate record(s) skipped)";
                }

                return imported;
            }
            catch (Exception ex)
            {
                message = $"Import failed: {ex.Message}";
                return 0;
            }
        }

        // ──────────────────────── Aggregations ─────────────────────────

        public List<ExamRow> GetExamRows()
        {
            lock (_lock)
            {
                return _students
                    .GroupBy(s => new {
                        Course = string.IsNullOrWhiteSpace(s.CourseCode) ? "N/A" : s.CourseCode.Trim().ToUpperInvariant(),
                        Sec    = string.IsNullOrWhiteSpace(s.Section) ? "N/A" : s.Section.Trim().ToUpperInvariant(),
                        SY     = s.SchoolYear?.Trim() ?? "",
                        Term   = s.Term?.Trim() ?? ""
                    })
                    .Select(g => new ExamRow
                    {
                        CourseCode       = g.Key.Course,
                        Section          = g.Key.Sec,
                        SchoolYear       = g.Key.SY,
                        Term             = g.Key.Term,
                        NumberOfStudents = g.Count(),
                        Passed           = g.Count(x => string.Equals(x.Status, "Passed", StringComparison.OrdinalIgnoreCase)),
                        Completion       = g.Count(x => string.Equals(x.Status, "Completion", StringComparison.OrdinalIgnoreCase))
                    })
                    .OrderBy(r => r.CourseCode)
                    .ThenBy(r => r.Section)
                    .ToList();
            }
        }

        public class CourseDashboardStat
        {
            public string CourseCode { get; set; } = "";
            public int TotalStudents { get; set; }
            public int Passed { get; set; }
            public int Completion { get; set; }
            public double PassingRate => TotalStudents > 0 ? (double)Passed / TotalStudents * 100.0 : 0.0;
        }

        public List<CourseDashboardStat> GetCourseDashboardStats()
        {
            lock (_lock)
            {
                return _students
                    .GroupBy(s => string.IsNullOrWhiteSpace(s.CourseCode) ? "N/A" : s.CourseCode.Trim().ToUpperInvariant())
                    .Select(g => new CourseDashboardStat
                    {
                        CourseCode    = g.Key,
                        TotalStudents = g.Count(),
                        Passed        = g.Count(x => string.Equals(x.Status, "Passed", StringComparison.OrdinalIgnoreCase)),
                        Completion    = g.Count(x => string.Equals(x.Status, "Completion", StringComparison.OrdinalIgnoreCase))
                    })
                    .OrderBy(s => s.CourseCode)
                    .ToList();
            }
        }

        public void NotifyDataChanged()
        {
            DataChanged?.Invoke();
        }

        // ──────────────────────── Program Normalizer ───────────────────

        public static string NormalizeProgram(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            string p = raw.Trim();
            string key = p.ToUpperInvariant().Replace(" ", "").Replace(".", "").Replace("-", "");

            switch (key)
            {
                case "CE": case "BSCE":                             return "CE";
                case "CPE": case "BSCPE":                           return "CPE";
                case "EE": case "BSEE":                             return "EE";
                case "ME": case "BSME":                             return "ME";
                case "CHE": case "BSCHE":                           return "CHE";
                case "ECE": case "BSECE":                           return "ECE";
                case "IE": case "BSIE":                             return "IE";
                case "AR": case "ARCH": case "BSAR": case "BSARCH": return "AR";
            }

            string lo = p.ToLowerInvariant();
            if (lo.Contains("computer eng") || lo.Contains("cpe"))        return "CPE";
            if (lo.Contains("civil"))                                     return "CE";
            if (lo.Contains("electronics") || lo.Contains("electronic"))  return "ECE";
            if (lo.Contains("electrical"))                                return "EE";
            if (lo.Contains("mechanical"))                                return "ME";
            if (lo.Contains("chemical"))                                  return "CHE";
            if (lo.Contains("industrial"))                                return "IE";
            if (lo.Contains("architect"))                                 return "AR";
            if (lo.Contains("computer"))                                  return "CPE";

            return p;
        }

        public static bool IsValidProgram(string program)
        {
            return ValidPrograms.Contains(program, StringComparer.OrdinalIgnoreCase);
        }

        // ──────────────────────── Helpers ──────────────────────────────

        private IXLWorksheet? GetTargetWorksheet(XLWorkbook wb)
        {
            return wb.Worksheets.FirstOrDefault(w =>
                       w.Name.Equals("Grades", StringComparison.OrdinalIgnoreCase))
                   ?? wb.Worksheets.FirstOrDefault();
        }

        private Dictionary<string, int> GetColumnMapping(IXLWorksheet ws)
        {
            var headerRow = ws.Row(1);
            var map = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            if (ws.RowsUsed().Count() == 0 || headerRow.IsEmpty())
                throw new Exception("The file does not contain a header row in Row 1.");

            foreach (var cell in headerRow.CellsUsed())
            {
                string name = cell.Value.ToString().Trim();
                if (!string.IsNullOrEmpty(name) && !map.ContainsKey(name))
                    map[name] = cell.Address.ColumnNumber;
            }

            if (!map.ContainsKey("School ID") && !map.ContainsKey("Student ID") &&
                !map.ContainsKey("StudentID") && !map.ContainsKey("ID"))
            {
                throw new Exception("Missing required header: 'School ID' (or 'Student ID') was not found in Row 1.");
            }

            return map;
        }

        private string Val(IXLRow row, Dictionary<string, int> map, params string[] names)
        {
            foreach (var n in names)
            {
                if (map.TryGetValue(n, out int col))
                    return row.Cell(col).Value.ToString().Trim();
            }
            return "";
        }
    }
}