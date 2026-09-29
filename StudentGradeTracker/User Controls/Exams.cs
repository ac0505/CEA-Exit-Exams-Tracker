using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace StudentGradeTracker.User_Controls
{
    public partial class Exams : UserControl
    {
        private List<StudentRecord> _allStudents = new List<StudentRecord>();
        private List<ExamRow> _currentExamRows = new List<ExamRow>();
        private bool _isUpdatingFilters = false;

        public Exams()
        {
            InitializeComponent();
            SetupGridColumns();
            WireEvents();

            ExcelDatabaseManager.Instance.DataChanged += OnDataChanged;
            this.Load += (s, e) => LoadExamsData();
        }

        private void SetupGridColumns()
        {
            dgvExams.AutoGenerateColumns = false;
            dgvExams.Columns.Clear();
            dgvExams.ReadOnly = true;
            dgvExams.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvExams.AllowUserToResizeColumns = false;
            dgvExams.AllowUserToResizeRows = false;
            dgvExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvExams.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvExams.ColumnHeadersHeight = 30;

            var colCourse = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseCode",
                HeaderText = "Course Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 140,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False
            };
            colCourse.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            var colSection = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Section",
                HeaderText = "Section",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 100,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False
            };

            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumberOfStudents",
                HeaderText = "Number of Students",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 110,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colPassed = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Passed",
                HeaderText = "Passed",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(4, 120, 87), Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };

            var colCompletion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Completion",
                HeaderText = "Completion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(161, 98, 7), Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };

            dgvExams.Columns.AddRange(colCourse, colSection, colTotal, colPassed, colCompletion);

            dgvExams.CellFormatting += (s, e) =>
            {
                if (e.CellStyle != null)
                {
                    // Do not show selected color on cells when clicked
                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                    e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                }
            };

            dgvExams.SelectionChanged += (s, e) => dgvExams.ClearSelection();
        }

        private void WireEvents()
        {
            txtSearchExams.TextChanged += (s, e) => ApplySearchAndDisplay();

            // Toggle popup filter panel
            btnFilterCourses.Click += (s, e) =>
            {
                pnlFilterCourses.Visible = !pnlFilterCourses.Visible;
                if (pnlFilterCourses.Visible)
                {
                    pnlFilterCourses.BringToFront();
                }
            };

            btnClose.Click += (s, e) =>
            {
                pnlFilterCourses.Visible = false;
            };

            btnReset.Click += (s, e) => ResetSequentialFilters();

            btnApply.Click += (s, e) =>
            {
                ApplySequentialFiltering();
                pnlFilterCourses.Visible = false;
            };

            // Sequential dependent filter changes
            cmbSchoolYear.SelectedIndexChanged += CmbSchoolYear_SelectedIndexChanged;
            cmbTerm.SelectedIndexChanged += CmbTerm_SelectedIndexChanged;
            cmbCourse.SelectedIndexChanged += CmbCourse_SelectedIndexChanged;
            cmbSection.SelectedIndexChanged += CmbSection_SelectedIndexChanged;
        }

        public void LoadExamsData()
        {
            _allStudents = ExcelDatabaseManager.Instance.GetAllStudents();
            InitializeSchoolYearFilter();
            ApplySequentialFiltering();
        }

        private void InitializeSchoolYearFilter()
        {
            _isUpdatingFilters = true;

            string selectedSY = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";

            var years = _allStudents.Select(s => s.SchoolYear.Trim())
                                    .Where(s => !string.IsNullOrEmpty(s))
                                    .Distinct()
                                    .OrderBy(s => s)
                                    .ToList();

            cmbSchoolYear.Items.Clear();
            cmbSchoolYear.Items.Add("All Years");
            cmbSchoolYear.Items.AddRange(years.ToArray());

            if (cmbSchoolYear.Items.Contains(selectedSY))
                cmbSchoolYear.SelectedItem = selectedSY;
            else
                cmbSchoolYear.SelectedIndex = 0;

            // Downstream filters initially disabled
            ResetTermFilter();
            ResetCourseFilter();
            ResetSectionFilter();

            _isUpdatingFilters = false;
        }

        private void CmbSchoolYear_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingFilters) return;

            _isUpdatingFilters = true;

            string sy = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";

            if (sy != "All Years")
            {
                // Enable Term and populate with terms for this SY
                var terms = _allStudents.Where(s => string.Equals(s.SchoolYear.Trim(), sy, StringComparison.OrdinalIgnoreCase))
                                        .Select(s => s.Term.Trim())
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .Distinct()
                                        .OrderBy(s => s)
                                        .ToList();

                cmbTerm.Items.Clear();
                cmbTerm.Items.Add("All Terms");
                cmbTerm.Items.AddRange(terms.ToArray());
                cmbTerm.SelectedIndex = 0;
                cmbTerm.Enabled = true;
            }
            else
            {
                ResetTermFilter();
            }

            // Downstream of Term are reset & disabled
            ResetCourseFilter();
            ResetSectionFilter();

            _isUpdatingFilters = false;
            ApplySequentialFiltering();
        }

        private void CmbTerm_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingFilters) return;

            _isUpdatingFilters = true;

            string sy = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";
            string term = cmbTerm.SelectedItem?.ToString() ?? "All Terms";

            if (term != "All Terms")
            {
                // Enable Course and populate with courses for (SY + Term)
                var courses = _allStudents.Where(s => string.Equals(s.SchoolYear.Trim(), sy, StringComparison.OrdinalIgnoreCase) &&
                                                     string.Equals(s.Term.Trim(), term, StringComparison.OrdinalIgnoreCase))
                                          .Select(s => s.CourseCode.Trim().ToUpperInvariant())
                                          .Where(s => !string.IsNullOrEmpty(s))
                                          .Distinct()
                                          .OrderBy(s => s)
                                          .ToList();

                cmbCourse.Items.Clear();
                cmbCourse.Items.Add("All Courses");
                cmbCourse.Items.AddRange(courses.ToArray());
                cmbCourse.SelectedIndex = 0;
                cmbCourse.Enabled = true;
            }
            else
            {
                ResetCourseFilter();
            }

            // Downstream of Course is reset & disabled
            ResetSectionFilter();

            _isUpdatingFilters = false;
            ApplySequentialFiltering();
        }

        private void CmbCourse_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingFilters) return;

            _isUpdatingFilters = true;

            string sy = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";
            string term = cmbTerm.SelectedItem?.ToString() ?? "All Terms";
            string course = cmbCourse.SelectedItem?.ToString() ?? "All Courses";

            if (course != "All Courses")
            {
                // Enable Section and populate with sections for (SY + Term + Course)
                var sections = _allStudents.Where(s => string.Equals(s.SchoolYear.Trim(), sy, StringComparison.OrdinalIgnoreCase) &&
                                                       string.Equals(s.Term.Trim(), term, StringComparison.OrdinalIgnoreCase) &&
                                                       string.Equals(s.CourseCode.Trim(), course, StringComparison.OrdinalIgnoreCase))
                                           .Select(s => s.Section.Trim().ToUpperInvariant())
                                           .Where(s => !string.IsNullOrEmpty(s))
                                           .Distinct()
                                           .OrderBy(s => s)
                                           .ToList();

                cmbSection.Items.Clear();
                cmbSection.Items.Add("All Sections");
                cmbSection.Items.AddRange(sections.ToArray());
                cmbSection.SelectedIndex = 0;
                cmbSection.Enabled = true;
            }
            else
            {
                ResetSectionFilter();
            }

            _isUpdatingFilters = false;
            ApplySequentialFiltering();
        }

        private void CmbSection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingFilters) return;
            ApplySequentialFiltering();
        }

        private void ResetTermFilter()
        {
            cmbTerm.Items.Clear();
            cmbTerm.Items.Add("All Terms");
            cmbTerm.SelectedIndex = 0;
            cmbTerm.Enabled = false;
        }

        private void ResetCourseFilter()
        {
            cmbCourse.Items.Clear();
            cmbCourse.Items.Add("All Courses");
            cmbCourse.SelectedIndex = 0;
            cmbCourse.Enabled = false;
        }

        private void ResetSectionFilter()
        {
            cmbSection.Items.Clear();
            cmbSection.Items.Add("All Sections");
            cmbSection.SelectedIndex = 0;
            cmbSection.Enabled = false;
        }

        private void ResetSequentialFilters()
        {
            _isUpdatingFilters = true;
            cmbSchoolYear.SelectedIndex = 0;
            ResetTermFilter();
            ResetCourseFilter();
            ResetSectionFilter();
            _isUpdatingFilters = false;

            ApplySequentialFiltering();
        }

        private void ApplySequentialFiltering()
        {
            string sy = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";
            string term = cmbTerm.SelectedItem?.ToString() ?? "All Terms";
            string course = cmbCourse.SelectedItem?.ToString() ?? "All Courses";
            string section = cmbSection.SelectedItem?.ToString() ?? "All Sections";

            var filtered = _allStudents.AsEnumerable();

            if (sy != "All Years")
                filtered = filtered.Where(s => string.Equals(s.SchoolYear.Trim(), sy, StringComparison.OrdinalIgnoreCase));

            if (cmbTerm.Enabled && term != "All Terms")
                filtered = filtered.Where(s => string.Equals(s.Term.Trim(), term, StringComparison.OrdinalIgnoreCase));

            if (cmbCourse.Enabled && course != "All Courses")
                filtered = filtered.Where(s => string.Equals(s.CourseCode.Trim(), course, StringComparison.OrdinalIgnoreCase));

            if (cmbSection.Enabled && section != "All Sections")
                filtered = filtered.Where(s => string.Equals(s.Section.Trim(), section, StringComparison.OrdinalIgnoreCase));

            // Group into ExamRow: one row per course section
            _currentExamRows = filtered
                .GroupBy(s => new {
                    Course = string.IsNullOrWhiteSpace(s.CourseCode) ? "N/A" : s.CourseCode.Trim().ToUpperInvariant(),
                    Sec    = string.IsNullOrWhiteSpace(s.Section) ? "N/A" : s.Section.Trim().ToUpperInvariant()
                })
                .Select(g => new ExamRow
                {
                    CourseCode       = g.Key.Course,
                    Section          = g.Key.Sec,
                    NumberOfStudents = g.Count(),
                    Passed           = g.Count(x => string.Equals(x.Status, "Passed", StringComparison.OrdinalIgnoreCase)),
                    Completion       = g.Count(x => string.Equals(x.Status, "Completion", StringComparison.OrdinalIgnoreCase))
                })
                .OrderBy(r => r.CourseCode)
                .ThenBy(r => r.Section)
                .ToList();

            UpdateActiveFilterTags(sy, term, course, section);
            ApplySearchAndDisplay();
            AdjustGridLayout();
        }

        private void ApplySearchAndDisplay()
        {
            string search = txtSearchExams.Text.Trim();
            var displayed = string.IsNullOrEmpty(search)
                ? _currentExamRows
                : _currentExamRows.Where(r =>
                    r.CourseCode.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.Section.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            dgvExams.DataSource = null;
            dgvExams.DataSource = displayed;

            lblNoRecords.Visible = (displayed.Count == 0);
            if (lblNoRecords.Visible) lblNoRecords.BringToFront();
        }

        private void UpdateActiveFilterTags(string sy, string term, string course, string section)
        {
            flpActiveFiltersExams.Controls.Clear();

            if (sy != "All Years")
            {
                AddFilterBadge($"SY: {sy}", () => {
                    _isUpdatingFilters = true;
                    cmbSchoolYear.SelectedIndex = 0;
                    ResetTermFilter();
                    ResetCourseFilter();
                    ResetSectionFilter();
                    _isUpdatingFilters = false;
                    ApplySequentialFiltering();
                });
            }

            if (cmbTerm.Enabled && term != "All Terms")
            {
                AddFilterBadge($"Term: {term}", () => {
                    _isUpdatingFilters = true;
                    cmbTerm.SelectedIndex = 0;
                    ResetCourseFilter();
                    ResetSectionFilter();
                    _isUpdatingFilters = false;
                    ApplySequentialFiltering();
                });
            }

            if (cmbCourse.Enabled && course != "All Courses")
            {
                AddFilterBadge($"Course: {course}", () => {
                    _isUpdatingFilters = true;
                    cmbCourse.SelectedIndex = 0;
                    ResetSectionFilter();
                    _isUpdatingFilters = false;
                    ApplySequentialFiltering();
                });
            }

            if (cmbSection.Enabled && section != "All Sections")
            {
                AddFilterBadge($"Section: {section}", () => {
                    cmbSection.SelectedIndex = 0;
                    ApplySequentialFiltering();
                });
            }
        }

        private void AddFilterBadge(string text, Action onRemove)
        {
            var btn = new Guna2Button
            {
                Text = $"✕  {text}",
                Height = 28,
                AutoSize = true,
                BorderRadius = 14,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(208, 208, 208),
                FillColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(39, 39, 39),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Margin = new Padding(0, 0, 8, 4),
                Cursor = Cursors.Hand
            };
            btn.HoverState.FillColor = Color.FromArgb(254, 226, 226);
            btn.HoverState.ForeColor = Color.FromArgb(185, 28, 28);
            btn.HoverState.BorderColor = Color.FromArgb(248, 113, 113);
            btn.Click += (s, e) => onRemove();
            flpActiveFiltersExams.Controls.Add(btn);
        }

        private void AdjustGridLayout()
        {
            int top = 76;

            if (flpActiveFiltersExams.Controls.Count > 0)
            {
                flpActiveFiltersExams.Visible = true;
                flpActiveFiltersExams.Location = new Point(53, top);
                top += flpActiveFiltersExams.PreferredSize.Height + 8;
            }
            else
            {
                flpActiveFiltersExams.Visible = false;
                top = 80;
            }

            dgvExams.Location = new Point(53, top);
            dgvExams.Height = this.ClientSize.Height - top - 25;
            dgvExams.Width = this.ClientSize.Width - 106;
        }

        private void OnDataChanged()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(LoadExamsData));
            }
            else
            {
                LoadExamsData();
            }
        }
    }
}
