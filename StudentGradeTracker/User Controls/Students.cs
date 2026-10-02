using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace StudentGradeTracker
{
    public partial class Students : UserControl
    {
        private List<StudentRecord> _allStudents = new List<StudentRecord>();
        private List<StudentRecord> _filteredStudents = new List<StudentRecord>();
        private readonly HashSet<StudentRecord> _selectedStudents = new HashSet<StudentRecord>();
        private bool _isUpdatingFilterOptions = false;
        private bool _isUpdatingSelection = false;
        private bool _isSelectionMode = false;
        private CheckBox? _headerCheckBox;

        public Students()
        {
            InitializeComponent();
            SetupGridColumns();
            SetupFilterControls();
            WireEvents();
            ApplyVisualStyle();

            this.Resize += (s, e) => AdjustGridLayout();
            AdjustGridLayout();

            ExcelDatabaseManager.Instance.DataChanged += OnDataChanged;
            this.Load += (s, e) => LoadStudentData();
        }

        private void SetupGridColumns()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            dgvStudents.ReadOnly = false;
            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStudents.AllowUserToResizeColumns = false;
            dgvStudents.AllowUserToResizeRows = false;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStudents.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvStudents.ColumnHeadersHeight = 34;

            // Mass Selection CheckBox Column
            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name = "colSelect",
                HeaderText = "",
                Width = 30,
                Resizable = DataGridViewTriState.False,
                ReadOnly = true,
                Visible = false,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(30, 64, 175),
                    NullValue = false,
                    Padding = new Padding(5, 0, 5, 0)
                }
            };
            dgvStudents.Columns.Add(chkCol);

            // Add Header CheckBox for Select All
            _headerCheckBox = new CheckBox
            {
                Size = new Size(18, 18),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 64, 175),
                FlatStyle = FlatStyle.Standard,
                CheckAlign = ContentAlignment.MiddleCenter,
                Location = new Point(6, 8),
                Cursor = Cursors.Hand,
                Visible = false
            };
            _headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
            dgvStudents.Controls.Add(_headerCheckBox);

            AddTextCol("SchoolID", "School ID", 100, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("FirstName", "First Name", 120, DataGridViewAutoSizeColumnMode.Fill);
            AddTextCol("LastName", "Last Name", 120, DataGridViewAutoSizeColumnMode.Fill);
            AddTextCol("MiddleInitial", "M.I", 50, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("Program", "Program", 75, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("CourseCode", "Course Code", 105, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("Section", "Section", 75, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("Status", "Status", 95, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("Term", "Term", 85, DataGridViewAutoSizeColumnMode.AllCells);
            AddTextCol("SchoolYear", "School Year", 110, DataGridViewAutoSizeColumnMode.AllCells);

            dgvStudents.CellFormatting += DgvStudents_CellFormatting;
            dgvStudents.CellContentClick += DgvStudents_CellContentClick;
            dgvStudents.CellValueChanged += DgvStudents_CellValueChanged;
            dgvStudents.CellClick += DgvStudents_CellClick;
            dgvStudents.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvStudents.IsCurrentCellDirty && dgvStudents.CurrentCell?.OwningColumn.Name == "colSelect")
                    dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgvStudents.SelectionChanged += (s, e) => dgvStudents.ClearSelection();
        }

        private void ApplyVisualStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            txtSearchStudents.BorderRadius = 10;
            txtSearchStudents.BorderColor = Color.FromArgb(203, 213, 225);
            txtSearchStudents.FillColor = Color.White;

            foreach (var button in new[] { btnMassUpdate, btnMassDelete, btnAddStudent, btnUpload, btnFilter, btnSelect, btnCancelSelection })
            {
                button.BorderRadius = 10;
                button.TextAlign = HorizontalAlignment.Center;
                button.TextOffset = Point.Empty;
            }

            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.GridColor = Color.FromArgb(226, 232, 240);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvStudents.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(15, 23, 42);
            dgvStudents.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(15, 23, 42);
            _headerCheckBox!.BackColor = Color.FromArgb(15, 23, 42);
            _headerCheckBox.ForeColor = Color.White;

            pnlFilterStudents.FillColor = Color.White;
            pnlFilterStudents.BorderColor = Color.FromArgb(226, 232, 240);
            pnlFilterStudents.BorderRadius = 16;
            pnlFilterStudents.ShadowDecoration.Depth = 12;
        }

        private void AddTextCol(string propName, string headerText, int minWidth, DataGridViewAutoSizeColumnMode mode)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propName,
                Name = propName,
                HeaderText = headerText,
                MinimumWidth = minWidth,
                AutoSizeMode = mode,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False
            };
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvStudents.Columns.Add(col);
        }

        private void DgvStudents_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStudents.Rows.Count || e.CellStyle == null) return;

            // Status cell highlight: Passed -> light green #8CFF8A, Completion -> light yellow #FBFF8A
            if (e.ColumnIndex >= 0 && dgvStudents.Columns[e.ColumnIndex]?.Name == "Status")
            {
                string status = e.Value?.ToString() ?? "";
                if (string.Equals(status, "Passed", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(0x8C, 0xFF, 0x8A); // #8CFF8A
                    e.CellStyle.ForeColor = Color.FromArgb(20, 80, 20);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (string.Equals(status, "Completion", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(0xFB, 0xFF, 0x8A); // #FBFF8A
                    e.CellStyle.ForeColor = Color.FromArgb(100, 80, 10);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }

            // Do not show selected color on cells when clicked
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

        private void DgvStudents_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_isSelectionMode && e.RowIndex >= 0 && e.ColumnIndex == dgvStudents.Columns["colSelect"].Index)
                dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvStudents_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (!_isSelectionMode || e.RowIndex < 0 || e.ColumnIndex == dgvStudents.Columns["colSelect"].Index)
                return;

            var cell = dgvStudents.Rows[e.RowIndex].Cells["colSelect"];
            cell.Value = !Convert.ToBoolean(cell.Value ?? false);
        }

        private void DgvStudents_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (!_isSelectionMode || _isUpdatingSelection || e.RowIndex < 0 || e.ColumnIndex < 0 ||
                dgvStudents.Columns[e.ColumnIndex].Name != "colSelect")
                return;

            var row = dgvStudents.Rows[e.RowIndex];
            if (row.DataBoundItem is not StudentRecord student)
                return;

            bool isSelected = Convert.ToBoolean(row.Cells["colSelect"].Value ?? false);
            student.IsSelected = isSelected;
            if (isSelected)
                _selectedStudents.Add(student);
            else
                _selectedStudents.Remove(student);

            UpdateHeaderCheckBox();
            UpdateMassActionButtons();
        }

        private void HeaderCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (!_isSelectionMode || _isUpdatingSelection)
                return;

            bool isChecked = _headerCheckBox?.Checked ?? false;
            _isUpdatingSelection = true;
            foreach (var student in _filteredStudents)
            {
                student.IsSelected = isChecked;
                if (isChecked)
                    _selectedStudents.Add(student);
                else
                    _selectedStudents.Remove(student);
            }

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                row.Cells["colSelect"].Value = isChecked;
            }
            _isUpdatingSelection = false;

            UpdateHeaderCheckBox();
            UpdateMassActionButtons();
        }

        private void UpdateHeaderCheckBox()
        {
            if (_headerCheckBox == null || !_isSelectionMode)
                return;

            bool allVisibleSelected = _filteredStudents.Count > 0 && _filteredStudents.All(_selectedStudents.Contains);
            _headerCheckBox.Enabled = _filteredStudents.Count > 0;
            _isUpdatingSelection = true;
            _headerCheckBox.Checked = allVisibleSelected;
            _isUpdatingSelection = false;
        }

        private void StartSelectionMode()
        {
            _isSelectionMode = true;
            dgvStudents.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvStudents.Columns["colSelect"].Visible = true;
            dgvStudents.Columns["colSelect"].ReadOnly = false;
            if (_headerCheckBox != null)
            {
                _headerCheckBox.Visible = true;
                _headerCheckBox.BringToFront();
            }

            UpdateMassActionButtons();
        }

        private void CancelSelectionMode()
        {
            _isUpdatingSelection = true;
            _isSelectionMode = false;
            if (dgvStudents.IsCurrentCellInEditMode)
                dgvStudents.CancelEdit();
            dgvStudents.CurrentCell = null;
            _selectedStudents.Clear();
            foreach (var student in _allStudents)
                student.IsSelected = false;
            foreach (DataGridViewRow row in dgvStudents.Rows)
                row.Cells["colSelect"].Value = false;
            if (_headerCheckBox != null)
                _headerCheckBox.Checked = false;
            _isUpdatingSelection = false;

            dgvStudents.Columns["colSelect"].ReadOnly = true;
            dgvStudents.Columns["colSelect"].Visible = false;
            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            if (_headerCheckBox != null)
                _headerCheckBox.Visible = false;

            UpdateMassActionButtons();
        }

        private void UpdateMassActionButtons()
        {
            int count = _selectedStudents.Count;
            btnSelect.Visible = !_isSelectionMode;
            btnCancelSelection.Visible = _isSelectionMode;

            if (_isSelectionMode && count > 0)
            {
                btnMassUpdate.Text = $"Update Status ({count})";
                btnMassDelete.Text = $"Delete ({count})";
                btnMassUpdate.Visible = true;
                btnMassDelete.Visible = true;
            }
            else
            {
                btnMassUpdate.Visible = false;
                btnMassDelete.Visible = false;
            }

            AdjustGridLayout();
        }

        private void SetupFilterControls()
        {
            cmbProgram.Items.Clear();
            cmbProgram.Items.Add("All Programs");
            cmbProgram.Items.AddRange(ExcelDatabaseManager.ValidPrograms);
            cmbProgram.SelectedIndex = 0;

            cmbCourse.Items.Clear();
            cmbCourse.Items.Add("All Courses");
            cmbCourse.SelectedIndex = 0;

            cmbSection.Items.Clear();
            cmbSection.Items.Add("All Sections");
            cmbSection.SelectedIndex = 0;

            cmbTerm.Items.Clear();
            cmbTerm.Items.Add("All Terms");
            cmbTerm.SelectedIndex = 0;

            cmbSchoolYear.Items.Clear();
            cmbSchoolYear.Items.Add("All Years");
            cmbSchoolYear.SelectedIndex = 0;
        }

        private void WireEvents()
        {
            txtSearchStudents.TextChanged += (s, e) => ApplyFilters();

            // Popup filter panel toggle
            btnFilter.Click += (s, e) =>
            {
                pnlFilterStudents.Visible = !pnlFilterStudents.Visible;
                if (pnlFilterStudents.Visible)
                {
                    pnlFilterStudents.BringToFront();
                }
            };

            btnClose.Click += (s, e) =>
            {
                pnlFilterStudents.Visible = false;
            };

            btnReset.Click += (s, e) =>
            {
                ResetFilters();
            };

            btnApply.Click += (s, e) =>
            {
                ApplyFilters();
                pnlFilterStudents.Visible = false;
            };

            cmbProgram.SelectedIndexChanged += (s, e) => { if (!_isUpdatingFilterOptions) ApplyFilters(); };
            cmbCourse.SelectedIndexChanged += (s, e) => { if (!_isUpdatingFilterOptions) ApplyFilters(); };
            cmbSection.SelectedIndexChanged += (s, e) => { if (!_isUpdatingFilterOptions) ApplyFilters(); };
            cmbTerm.SelectedIndexChanged += (s, e) => { if (!_isUpdatingFilterOptions) ApplyFilters(); };
            cmbSchoolYear.SelectedIndexChanged += (s, e) => { if (!_isUpdatingFilterOptions) ApplyFilters(); };

            btnAddStudent.Click += BtnAddStudent_Click;
            btnUpload.Click += BtnUpload_Click;
            btnSelect.Click += (s, e) => StartSelectionMode();
            btnCancelSelection.Click += (s, e) => CancelSelectionMode();
            btnMassUpdate.Click += BtnMassUpdate_Click;
            btnMassDelete.Click += BtnMassDelete_Click;
        }

        public void LoadStudentData()
        {
            _allStudents = ExcelDatabaseManager.Instance.GetAllStudents();
            CancelSelectionMode();

            UpdateDynamicFilterCombos();
            ApplyFilters();
        }

        private void UpdateDynamicFilterCombos()
        {
            _isUpdatingFilterOptions = true;

            string selectedCourse = cmbCourse.SelectedItem?.ToString() ?? "All Courses";
            string selectedSection = cmbSection.SelectedItem?.ToString() ?? "All Sections";
            string selectedTerm = cmbTerm.SelectedItem?.ToString() ?? "All Terms";
            string selectedSY = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";

            // Courses present in cells
            var courses = _allStudents.Select(s => s.CourseCode.Trim().ToUpperInvariant())
                                     .Where(s => !string.IsNullOrEmpty(s))
                                     .Distinct().OrderBy(s => s).ToList();
            cmbCourse.Items.Clear();
            cmbCourse.Items.Add("All Courses");
            cmbCourse.Items.AddRange(courses.ToArray());
            cmbCourse.SelectedItem = cmbCourse.Items.Contains(selectedCourse) ? selectedCourse : "All Courses";

            // Sections present in cells
            var sections = _allStudents.Select(s => s.Section.Trim().ToUpperInvariant())
                                       .Where(s => !string.IsNullOrEmpty(s))
                                       .Distinct().OrderBy(s => s).ToList();
            cmbSection.Items.Clear();
            cmbSection.Items.Add("All Sections");
            cmbSection.Items.AddRange(sections.ToArray());
            cmbSection.SelectedItem = cmbSection.Items.Contains(selectedSection) ? selectedSection : "All Sections";

            // Terms present in cells
            var terms = _allStudents.Select(s => s.Term.Trim())
                                   .Where(s => !string.IsNullOrEmpty(s))
                                   .Distinct().OrderBy(s => s).ToList();
            cmbTerm.Items.Clear();
            cmbTerm.Items.Add("All Terms");
            cmbTerm.Items.AddRange(terms.ToArray());
            cmbTerm.SelectedItem = cmbTerm.Items.Contains(selectedTerm) ? selectedTerm : "All Terms";

            // School Years present in cells
            var years = _allStudents.Select(s => s.SchoolYear.Trim())
                                    .Where(s => !string.IsNullOrEmpty(s))
                                    .Distinct().OrderBy(s => s).ToList();
            cmbSchoolYear.Items.Clear();
            cmbSchoolYear.Items.Add("All Years");
            cmbSchoolYear.Items.AddRange(years.ToArray());
            cmbSchoolYear.SelectedItem = cmbSchoolYear.Items.Contains(selectedSY) ? selectedSY : "All Years";

            _isUpdatingFilterOptions = false;
        }

        private void ApplyFilters()
        {
            string search = txtSearchStudents.Text.Trim();
            string selProgram = cmbProgram.SelectedItem?.ToString() ?? "All Programs";
            string selCourse = cmbCourse.SelectedItem?.ToString() ?? "All Courses";
            string selSection = cmbSection.SelectedItem?.ToString() ?? "All Sections";
            string selTerm = cmbTerm.SelectedItem?.ToString() ?? "All Terms";
            string selSY = cmbSchoolYear.SelectedItem?.ToString() ?? "All Years";

            var filtered = _allStudents.AsEnumerable();

            // Program filter (Fixed list exception)
            if (selProgram != "All Programs")
            {
                filtered = filtered.Where(s => string.Equals(s.Program, selProgram, StringComparison.OrdinalIgnoreCase));
            }

            // Course filter
            if (selCourse != "All Courses")
            {
                filtered = filtered.Where(s => string.Equals(s.CourseCode, selCourse, StringComparison.OrdinalIgnoreCase));
            }

            // Section filter
            if (selSection != "All Sections")
            {
                filtered = filtered.Where(s => string.Equals(s.Section, selSection, StringComparison.OrdinalIgnoreCase));
            }

            // Term filter
            if (selTerm != "All Terms")
            {
                filtered = filtered.Where(s => string.Equals(s.Term, selTerm, StringComparison.OrdinalIgnoreCase));
            }

            // School Year filter
            if (selSY != "All Years")
            {
                filtered = filtered.Where(s => string.Equals(s.SchoolYear, selSY, StringComparison.OrdinalIgnoreCase));
            }

            // Text search across all fields
            if (!string.IsNullOrEmpty(search))
            {
                filtered = filtered.Where(s =>
                    s.SchoolID.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.FirstName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.LastName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.MiddleInitial.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.Program.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.CourseCode.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.Section.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.Status.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.Term.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.SchoolYear.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            _filteredStudents = filtered.ToList();

            // Re-apply selection states
            foreach (var student in _filteredStudents)
            {
                student.IsSelected = _selectedStudents.Contains(student);
            }

            _isUpdatingSelection = true;
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = _filteredStudents;

            // Sync checkbox column values
            for (int i = 0; i < dgvStudents.Rows.Count; i++)
            {
                if (dgvStudents.Rows[i].DataBoundItem is StudentRecord rec)
                {
                    dgvStudents.Rows[i].Cells["colSelect"].Value = rec.IsSelected;
                }
            }
            _isUpdatingSelection = false;
            UpdateHeaderCheckBox();

            // Check if selected program has no records
            if (_filteredStudents.Count == 0 && selProgram != "All Programs")
            {
                lblNoRecords.Text = "No student record found.";
                lblNoRecords.Visible = true;
                lblNoRecords.BringToFront();
            }
            else if (_filteredStudents.Count == 0)
            {
                lblNoRecords.Text = "No student records match the search/filters.";
                lblNoRecords.Visible = true;
                lblNoRecords.BringToFront();
            }
            else
            {
                lblNoRecords.Visible = false;
            }

            UpdateActiveFilterTags(selProgram, selCourse, selSection, selTerm, selSY);
            AdjustGridLayout();
            UpdateMassActionButtons();
        }

        private void UpdateActiveFilterTags(string program, string course, string section, string term, string sy)
        {
            flpActiveFilters.Controls.Clear();

            if (program != "All Programs")
                AddFilterBadge($"Program: {program}", () => { cmbProgram.SelectedIndex = 0; ApplyFilters(); });

            if (course != "All Courses")
                AddFilterBadge($"Course: {course}", () => { cmbCourse.SelectedIndex = 0; ApplyFilters(); });

            if (section != "All Sections")
                AddFilterBadge($"Section: {section}", () => { cmbSection.SelectedIndex = 0; ApplyFilters(); });

            if (term != "All Terms")
                AddFilterBadge($"Term: {term}", () => { cmbTerm.SelectedIndex = 0; ApplyFilters(); });

            if (sy != "All Years")
                AddFilterBadge($"SY: {sy}", () => { cmbSchoolYear.SelectedIndex = 0; ApplyFilters(); });
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
            flpActiveFilters.Controls.Add(btn);
        }

        private void AdjustGridLayout()
        {
            const int left = 45;
            const int right = 45;
            const int gap = 8;
            const int buttonY = 36;
            int width = ClientSize.Width;

            int searchRight;
            if (_isSelectionMode)
            {
                btnAddStudent.Visible = false;
                btnUpload.Visible = false;
                btnFilter.Visible = false;
                btnSelect.Visible = false;
                btnCancelSelection.Bounds = new Rectangle(width - right - 82, buttonY, 82, 36);
                btnMassDelete.Bounds = new Rectangle(btnCancelSelection.Left - gap - 85, buttonY, 85, 36);
                btnMassUpdate.Bounds = new Rectangle(btnMassDelete.Left - gap - 120, buttonY, 120, 36);
                searchRight = btnMassUpdate.Left;
            }
            else
            {
                btnAddStudent.Visible = true;
                btnUpload.Visible = true;
                btnFilter.Visible = true;
                btnSelect.Visible = true;
                btnCancelSelection.Visible = false;
                btnSelect.Bounds = new Rectangle(width - right - 82, buttonY, 82, 36);
                btnFilter.Bounds = new Rectangle(btnSelect.Left - gap - 88, buttonY, 88, 36);
                btnUpload.Bounds = new Rectangle(btnFilter.Left - gap - 110, buttonY, 110, 36);
                btnAddStudent.Bounds = new Rectangle(btnUpload.Left - gap - 110, buttonY, 110, 36);
                searchRight = btnAddStudent.Left;
            }

            txtSearchStudents.Bounds = new Rectangle(left, buttonY,
                Math.Min(320, Math.Max(160, searchRight - left - gap)), 36);

            int top = 78;
            flpActiveFilters.Location = new Point(left, top);
            flpActiveFilters.Width = Math.Max(0, width - left - right);
            flpActiveFilters.MinimumSize = Size.Empty;
            flpActiveFilters.MaximumSize = new Size(Math.Max(0, width - left - right), 45);

            if (flpActiveFilters.Controls.Count > 0)
            {
                flpActiveFilters.Visible = true;
                top += flpActiveFilters.PreferredSize.Height + 8;
            }
            else
            {
                flpActiveFilters.Visible = false;
                top = 90;
            }

            dgvStudents.Location = new Point(left, top);
            dgvStudents.Height = Math.Max(100, ClientSize.Height - top - 25);
            dgvStudents.Width = Math.Max(100, width - left - right);
        }

        private void ResetFilters()
        {
            _isUpdatingFilterOptions = true;
            cmbProgram.SelectedIndex = 0;
            cmbCourse.SelectedIndex = 0;
            cmbSection.SelectedIndex = 0;
            cmbTerm.SelectedIndex = 0;
            cmbSchoolYear.SelectedIndex = 0;
            _isUpdatingFilterOptions = false;

            ApplyFilters();
        }

        private void BtnAddStudent_Click(object? sender, EventArgs e)
        {
            using (var form = new AddStudentForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadStudentData();
                }
            }
        }

        private void BtnUpload_Click(object? sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Workbooks (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                ofd.Title = "Import Student Records from Excel";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var confirm = MessageBox.Show(
                        $"Do you want to import student records from '{ofd.SafeFileName}'?\nDuplicate records will be skipped automatically.",
                        "Confirm Excel Import",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        int count = ExcelDatabaseManager.Instance.ImportFromFile(ofd.FileName, out string msg);
                        if (count > 0)
                        {
                            MessageBox.Show(msg, "Import Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(msg, "Import Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        LoadStudentData();
                    }
                }
            }
        }

        private void BtnMassUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedStudents.Count == 0) return;

            using (var dlg = new StatusUpdateDialog(_selectedStudents.Count))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string newStatus = dlg.SelectedStatus;
                    ExcelDatabaseManager.Instance.UpdateStatus(_selectedStudents, newStatus);
                    MessageBox.Show($"Successfully updated status to '{newStatus}' for {_selectedStudents.Count} student(s).",
                        "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentData();
                }
            }
        }

        private void BtnMassDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedStudents.Count == 0) return;

            var res = MessageBox.Show(
                $"Are you sure you want to delete {_selectedStudents.Count} selected student record(s)?\nThis will also be removed from the Excel database.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                int count = _selectedStudents.Count;
                ExcelDatabaseManager.Instance.DeleteStudents(_selectedStudents);
                MessageBox.Show($"Successfully deleted {count} student record(s).",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudentData();
            }
        }

        private void OnDataChanged()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(LoadStudentData));
            }
            else
            {
                LoadStudentData();
            }
        }
    }
}
