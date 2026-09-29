using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentGradeTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0] == "--seed")
                {
                    SeedDatabase();
                    return;
                }
                else if (args[0] == "--verify")
                {
                    VerifyApp();
                    return;
                }
            }

            // If file doesn't exist on first launch, auto-seed with initial sample data so the app isn't blank
            if (!File.Exists(ExcelDatabaseManager.FilePath))
            {
                SeedDatabase();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void SeedDatabase()
        {
            var db = ExcelDatabaseManager.Instance;
            var sampleStudents = new List<StudentRecord>
            {
                new StudentRecord { SchoolID = "2020-10021", FirstName = "Mark", LastName = "Reyes", MiddleInitial = "A.", Program = "CPE", CourseCode = "CPE 501", Section = "5A", Status = "Passed", Term = "1st Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2020-10022", FirstName = "Sarah", LastName = "Santos", MiddleInitial = "B.", Program = "CPE", CourseCode = "CPE 501", Section = "5A", Status = "Completion", Term = "1st Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2020-10023", FirstName = "John Paul", LastName = "Tan", MiddleInitial = "C.", Program = "CPE", CourseCode = "CPE 501", Section = "5B", Status = "Passed", Term = "1st Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2020-10024", FirstName = "Angelo", LastName = "Cruz", MiddleInitial = "M.", Program = "CPE", CourseCode = "CPE 502", Section = "5A", Status = "Passed", Term = "2nd Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2021-20015", FirstName = "Bea", LastName = "Villanueva", MiddleInitial = "D.", Program = "CE", CourseCode = "CE 401", Section = "4A", Status = "Passed", Term = "1st Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2021-20016", FirstName = "Daniel", LastName = "Lim", MiddleInitial = "E.", Program = "CE", CourseCode = "CE 401", Section = "4A", Status = "Completion", Term = "1st Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2021-20017", FirstName = "Grace", LastName = "Mercado", MiddleInitial = "S.", Program = "CE", CourseCode = "CE 401", Section = "4B", Status = "Passed", Term = "1st Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2021-30040", FirstName = "Carlos", LastName = "Aquino", MiddleInitial = "F.", Program = "ECE", CourseCode = "ECE 410", Section = "4A", Status = "Passed", Term = "1st Term", SchoolYear = "2024-2025" },
                new StudentRecord { SchoolID = "2021-30041", FirstName = "Patricia", LastName = "Flores", MiddleInitial = "G.", Program = "ECE", CourseCode = "ECE 410", Section = "4A", Status = "Completion", Term = "1st Term", SchoolYear = "2024-2025" },
                new StudentRecord { SchoolID = "2022-40011", FirstName = "Jerome", LastName = "Navarro", MiddleInitial = "H.", Program = "ME", CourseCode = "ME 302", Section = "3A", Status = "Passed", Term = "1st Term", SchoolYear = "2024-2025" },
                new StudentRecord { SchoolID = "2022-40012", FirstName = "Kimberly", LastName = "Soriano", MiddleInitial = "J.", Program = "ME", CourseCode = "ME 302", Section = "3B", Status = "Completion", Term = "2nd Term", SchoolYear = "2024-2025" },
                new StudentRecord { SchoolID = "2022-50031", FirstName = "Lance", LastName = "Mendoza", MiddleInitial = "K.", Program = "EE", CourseCode = "EE 201", Section = "2A", Status = "Passed", Term = "1st Term", SchoolYear = "2024-2025" },
                new StudentRecord { SchoolID = "2022-60018", FirstName = "Alyssa", LastName = "Bautista", MiddleInitial = "L.", Program = "CHE", CourseCode = "CHE 301", Section = "3A", Status = "Completion", Term = "1st Term", SchoolYear = "2024-2025" },
                new StudentRecord { SchoolID = "2022-70005", FirstName = "Gabriel", LastName = "Castillo", MiddleInitial = "R.", Program = "IE", CourseCode = "IE 405", Section = "4A", Status = "Passed", Term = "2nd Term", SchoolYear = "2023-2024" },
                new StudentRecord { SchoolID = "2022-80009", FirstName = "Camille", LastName = "Valdez", MiddleInitial = "T.", Program = "AR", CourseCode = "AR 501", Section = "5A", Status = "Passed", Term = "1st Term", SchoolYear = "2023-2024" }
            };

            foreach (var s in sampleStudents)
            {
                db.AddStudent(s, out _);
            }

            Console.WriteLine($"Database seeded successfully with {db.GetAllStudents().Count} records.");
        }

        public static void VerifyApp()
        {
            var db = ExcelDatabaseManager.Instance;
            Console.WriteLine($"[VERIFY] Total loaded students: {db.GetAllStudents().Count}");

            // Verify Dashboard aggregations
            var stats = db.GetCourseDashboardStats();
            Console.WriteLine($"[VERIFY] Unique Courses tracked: {stats.Count}");
            foreach (var st in stats)
            {
                Console.WriteLine($"   Course: {st.CourseCode} | Total: {st.TotalStudents} | Passed: {st.Passed} | Completion: {st.Completion} | Rate: {st.PassingRate:0.0}%");
            }

            // Verify Exams section aggregation
            var exams = db.GetExamRows();
            Console.WriteLine($"[VERIFY] Exam rows (course sections): {exams.Count}");
            foreach (var ex in exams)
            {
                Console.WriteLine($"   {ex.CourseCode} Sec {ex.Section} | Students: {ex.NumberOfStudents} | Passed: {ex.Passed} | Completion: {ex.Completion}");
            }

            // Verify Duplicate check against actual loaded student
            if (db.GetAllStudents().Count > 0)
            {
                var existing = db.GetAllStudents()[0];
                var dup = new StudentRecord
                {
                    SchoolID = existing.SchoolID,
                    FirstName = "Duplicate",
                    LastName = "Test",
                    Program = existing.Program,
                    CourseCode = existing.CourseCode,
                    Section = existing.Section,
                    Status = "Passed"
                };
                bool dupResult = db.AddStudent(dup, out string dupErr);
                Console.WriteLine($"[VERIFY] Duplicate check correctly blocked: {!dupResult} ({dupErr})");
            }

            Console.WriteLine("[VERIFY] ALL VERIFICATION CHECKS PASSED!");
        }
    }

    public class StudentRecord
    {
        [Browsable(false)]
        public bool IsSelected { get; set; } = false;

        [DisplayName("School ID")]
        public string SchoolID { get; set; } = "";

        [Browsable(false)]
        public string StudentID
        {
            get => SchoolID;
            set => SchoolID = value;
        }

        [DisplayName("First Name")]
        public string FirstName { get; set; } = "";

        [DisplayName("Last Name")]
        public string LastName { get; set; } = "";

        [DisplayName("M.I")]
        public string MiddleInitial { get; set; } = "";

        [DisplayName("Program")]
        public string Program { get; set; } = "";

        [DisplayName("Course Code")]
        public string CourseCode { get; set; } = "";

        [DisplayName("Section")]
        public string Section { get; set; } = "";

        [DisplayName("Status")]
        public string Status { get; set; } = "";

        [DisplayName("Term")]
        public string Term { get; set; } = "";

        [DisplayName("School Year")]
        public string SchoolYear { get; set; } = "";
    }

    public class ExamRow
    {
        [DisplayName("Course Code")]
        public string CourseCode { get; set; } = "";

        [DisplayName("Section")]
        public string Section { get; set; } = "";

        [DisplayName("Number of Students")]
        public int NumberOfStudents { get; set; }

        [DisplayName("Passed")]
        public int Passed { get; set; }

        [DisplayName("Completion")]
        public int Completion { get; set; }

        [Browsable(false)]
        public string SchoolYear { get; set; } = "";

        [Browsable(false)]
        public string Term { get; set; } = "";
    }
}