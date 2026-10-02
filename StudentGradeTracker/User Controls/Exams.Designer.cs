namespace StudentGradeTracker.User_Controls
{
    partial class Exams
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exams));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            txtSearchExams = new Guna.UI2.WinForms.Guna2TextBox();
            btnFilterCourses = new Guna.UI2.WinForms.Guna2Button();
            flpActiveFiltersExams = new System.Windows.Forms.FlowLayoutPanel();
            dgvExams = new Guna.UI2.WinForms.Guna2DataGridView();
            lblNoRecords = new System.Windows.Forms.Label();
            pnlFilterCourses = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new System.Windows.Forms.Label();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblSY = new System.Windows.Forms.Label();
            cmbSchoolYear = new Guna.UI2.WinForms.Guna2ComboBox();
            lblTerm = new System.Windows.Forms.Label();
            cmbTerm = new Guna.UI2.WinForms.Guna2ComboBox();
            lblCourse = new System.Windows.Forms.Label();
            cmbCourse = new Guna.UI2.WinForms.Guna2ComboBox();
            lblSection = new System.Windows.Forms.Label();
            cmbSection = new Guna.UI2.WinForms.Guna2ComboBox();
            btnReset = new Guna.UI2.WinForms.Guna2Button();
            btnApply = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)dgvExams).BeginInit();
            pnlFilterCourses.SuspendLayout();
            SuspendLayout();

            // 
            // txtSearchExams
            // 
            txtSearchExams.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            txtSearchExams.BorderRadius = 4;
            txtSearchExams.CustomizableEdges = customizableEdges1;
            txtSearchExams.DefaultText = "";
            txtSearchExams.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSearchExams.Location = new System.Drawing.Point(53, 30);
            txtSearchExams.Name = "txtSearchExams";
            txtSearchExams.PasswordChar = '\0';
            txtSearchExams.PlaceholderText = "Search by course code or section...";
            txtSearchExams.SelectedText = "";
            txtSearchExams.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearchExams.Size = new System.Drawing.Size(360, 36);
            txtSearchExams.TabIndex = 0;

            // 
            // btnFilterCourses
            // 
            btnFilterCourses.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFilterCourses.BorderRadius = 4;
            btnFilterCourses.CustomizableEdges = customizableEdges3;
            btnFilterCourses.FillColor = System.Drawing.Color.FromArgb(30, 64, 175);
            btnFilterCourses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnFilterCourses.ForeColor = System.Drawing.Color.White;
            btnFilterCourses.Location = new System.Drawing.Point(828, 30);
            btnFilterCourses.Name = "btnFilterCourses";
            btnFilterCourses.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnFilterCourses.Size = new System.Drawing.Size(120, 36);
            btnFilterCourses.TabIndex = 1;
            btnFilterCourses.Text = "Filter Courses";

            // 
            // flpActiveFiltersExams
            // 
            flpActiveFiltersExams.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flpActiveFiltersExams.AutoSize = true;
            flpActiveFiltersExams.BackColor = System.Drawing.Color.Transparent;
            flpActiveFiltersExams.Location = new System.Drawing.Point(53, 76);
            flpActiveFiltersExams.Margin = new System.Windows.Forms.Padding(0);
            flpActiveFiltersExams.MaximumSize = new System.Drawing.Size(895, 45);
            flpActiveFiltersExams.MinimumSize = System.Drawing.Size.Empty;
            flpActiveFiltersExams.Name = "flpActiveFiltersExams";
            flpActiveFiltersExams.Size = new System.Drawing.Size(895, 0);
            flpActiveFiltersExams.TabIndex = 2;

            // 
            // dgvExams
            // 
            dgvExams.AllowUserToAddRows = false;
            dgvExams.AllowUserToDeleteRows = false;
            dgvExams.AllowUserToResizeColumns = false;
            dgvExams.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dgvExams.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvExams.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvExams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(48, 48, 48); // #303030
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvExams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvExams.ColumnHeadersHeight = 32;
            dgvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvExams.DefaultCellStyle = dataGridViewCellStyle3;
            dgvExams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgvExams.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dgvExams.Location = new System.Drawing.Point(53, 85);
            dgvExams.MultiSelect = false;
            dgvExams.Name = "dgvExams";
            dgvExams.ReadOnly = true;
            dgvExams.RowHeadersVisible = false;
            dgvExams.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvExams.RowTemplate.Height = 28;
            dgvExams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dgvExams.Size = new System.Drawing.Size(895, 395);
            dgvExams.TabIndex = 3;
            dgvExams.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            dgvExams.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dgvExams.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dgvExams.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvExams.ThemeStyle.HeaderStyle.Height = 32;
            dgvExams.ThemeStyle.ReadOnly = true;
            dgvExams.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvExams.ThemeStyle.RowsStyle.Height = 28;

            // 
            // lblNoRecords
            // 
            lblNoRecords.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblNoRecords.AutoSize = true;
            lblNoRecords.BackColor = System.Drawing.Color.White;
            lblNoRecords.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblNoRecords.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblNoRecords.Location = new System.Drawing.Point(400, 260);
            lblNoRecords.Name = "lblNoRecords";
            lblNoRecords.Size = new System.Drawing.Size(199, 21);
            lblNoRecords.TabIndex = 4;
            lblNoRecords.Text = "No exam records found.";
            lblNoRecords.Visible = false;

            // 
            // pnlFilterCourses (POPUP PANEL)
            // 
            pnlFilterCourses.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlFilterCourses.BackColor = System.Drawing.Color.White;
            pnlFilterCourses.BorderColor = System.Drawing.Color.FromArgb(97, 97, 97);
            pnlFilterCourses.BorderRadius = 20;
            pnlFilterCourses.BorderThickness = 1;
            pnlFilterCourses.Controls.Add(label1);
            pnlFilterCourses.Controls.Add(btnClose);
            pnlFilterCourses.Controls.Add(lblSY);
            pnlFilterCourses.Controls.Add(cmbSchoolYear);
            pnlFilterCourses.Controls.Add(lblTerm);
            pnlFilterCourses.Controls.Add(cmbTerm);
            pnlFilterCourses.Controls.Add(lblCourse);
            pnlFilterCourses.Controls.Add(cmbCourse);
            pnlFilterCourses.Controls.Add(lblSection);
            pnlFilterCourses.Controls.Add(cmbSection);
            pnlFilterCourses.Controls.Add(btnReset);
            pnlFilterCourses.Controls.Add(btnApply);
            pnlFilterCourses.CustomizableEdges = customizableEdges17;
            pnlFilterCourses.FillColor = System.Drawing.Color.White;
            pnlFilterCourses.Location = new System.Drawing.Point(592, 72);
            pnlFilterCourses.Name = "pnlFilterCourses";
            pnlFilterCourses.ShadowDecoration.BorderRadius = 20;
            pnlFilterCourses.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 0, 0, 0);
            pnlFilterCourses.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlFilterCourses.ShadowDecoration.Depth = 15;
            pnlFilterCourses.ShadowDecoration.Enabled = true;
            pnlFilterCourses.Size = new System.Drawing.Size(363, 310);
            pnlFilterCourses.TabIndex = 5;
            pnlFilterCourses.Visible = false;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(39, 39, 39);
            label1.Location = new System.Drawing.Point(16, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Filter Courses";

            // 
            // btnClose
            // 
            btnClose.CustomizableEdges = customizableEdges5;
            btnClose.FillColor = System.Drawing.Color.Transparent;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.ImageSize = new System.Drawing.Size(12, 12);
            btnClose.Location = new System.Drawing.Point(322, 10);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnClose.Size = new System.Drawing.Size(26, 26);
            btnClose.TabIndex = 1;
            btnClose.Text = "";

            // 
            // lblSY
            // 
            lblSY.AutoSize = true;
            lblSY.BackColor = System.Drawing.Color.Transparent;
            lblSY.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblSY.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
            lblSY.Location = new System.Drawing.Point(16, 42);
            lblSY.Name = "lblSY";
            lblSY.Size = new System.Drawing.Size(95, 13);
            lblSY.TabIndex = 2;
            lblSY.Text = "1. SCHOOL YEAR *";

            // 
            // cmbSchoolYear
            // 
            cmbSchoolYear.BackColor = System.Drawing.Color.Transparent;
            cmbSchoolYear.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            cmbSchoolYear.BorderRadius = 4;
            cmbSchoolYear.CustomizableEdges = customizableEdges7;
            cmbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSchoolYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbSchoolYear.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            cmbSchoolYear.ItemHeight = 28;
            cmbSchoolYear.Location = new System.Drawing.Point(16, 58);
            cmbSchoolYear.Name = "cmbSchoolYear";
            cmbSchoolYear.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbSchoolYear.Size = new System.Drawing.Size(155, 34);
            cmbSchoolYear.TabIndex = 3;

            // 
            // lblTerm
            // 
            lblTerm.AutoSize = true;
            lblTerm.BackColor = System.Drawing.Color.Transparent;
            lblTerm.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblTerm.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
            lblTerm.Location = new System.Drawing.Point(192, 42);
            lblTerm.Name = "lblTerm";
            lblTerm.Size = new System.Drawing.Size(49, 13);
            lblTerm.TabIndex = 4;
            lblTerm.Text = "2. TERM";

            // 
            // cmbTerm
            // 
            cmbTerm.BackColor = System.Drawing.Color.Transparent;
            cmbTerm.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            cmbTerm.BorderRadius = 4;
            cmbTerm.CustomizableEdges = customizableEdges9;
            cmbTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTerm.Enabled = false;
            cmbTerm.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbTerm.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            cmbTerm.ItemHeight = 28;
            cmbTerm.Location = new System.Drawing.Point(192, 58);
            cmbTerm.Name = "cmbTerm";
            cmbTerm.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmbTerm.Size = new System.Drawing.Size(155, 34);
            cmbTerm.TabIndex = 5;

            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.BackColor = System.Drawing.Color.Transparent;
            lblCourse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblCourse.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
            lblCourse.Location = new System.Drawing.Point(16, 102);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new System.Drawing.Size(95, 13);
            lblCourse.TabIndex = 6;
            lblCourse.Text = "3. COURSE CODE";

            // 
            // cmbCourse
            // 
            cmbCourse.BackColor = System.Drawing.Color.Transparent;
            cmbCourse.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            cmbCourse.BorderRadius = 4;
            cmbCourse.CustomizableEdges = customizableEdges11;
            cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCourse.Enabled = false;
            cmbCourse.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbCourse.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            cmbCourse.ItemHeight = 28;
            cmbCourse.Location = new System.Drawing.Point(16, 118);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbCourse.Size = new System.Drawing.Size(155, 34);
            cmbCourse.TabIndex = 7;

            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.BackColor = System.Drawing.Color.Transparent;
            lblSection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblSection.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
            lblSection.Location = new System.Drawing.Point(192, 102);
            lblSection.Name = "lblSection";
            lblSection.Size = new System.Drawing.Size(65, 13);
            lblSection.TabIndex = 8;
            lblSection.Text = "4. SECTION";

            // 
            // cmbSection
            // 
            cmbSection.BackColor = System.Drawing.Color.Transparent;
            cmbSection.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            cmbSection.BorderRadius = 4;
            cmbSection.CustomizableEdges = customizableEdges13;
            cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSection.Enabled = false;
            cmbSection.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbSection.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            cmbSection.ItemHeight = 28;
            cmbSection.Location = new System.Drawing.Point(192, 118);
            cmbSection.Name = "cmbSection";
            cmbSection.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cmbSection.Size = new System.Drawing.Size(155, 34);
            cmbSection.TabIndex = 9;

            // 
            // btnReset
            // 
            btnReset.BorderColor = System.Drawing.Color.FromArgb(97, 97, 97);
            btnReset.BorderRadius = 4;
            btnReset.BorderThickness = 1;
            btnReset.CustomizableEdges = customizableEdges15;
            btnReset.FillColor = System.Drawing.Color.Transparent;
            btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnReset.ForeColor = System.Drawing.Color.FromArgb(97, 97, 97);
            btnReset.Location = new System.Drawing.Point(16, 255);
            btnReset.Name = "btnReset";
            btnReset.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnReset.Size = new System.Drawing.Size(90, 34);
            btnReset.TabIndex = 10;
            btnReset.Text = "Reset";

            // 
            // btnApply
            // 
            btnApply.BorderRadius = 4;
            btnApply.FillColor = System.Drawing.Color.FromArgb(30, 64, 175);
            btnApply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnApply.ForeColor = System.Drawing.Color.White;
            btnApply.Location = new System.Drawing.Point(257, 255);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(90, 34);
            btnApply.TabIndex = 11;
            btnApply.Text = "Apply";

            // 
            // Exams
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            Controls.Add(pnlFilterCourses);
            Controls.Add(lblNoRecords);
            Controls.Add(flpActiveFiltersExams);
            Controls.Add(dgvExams);
            Controls.Add(btnFilterCourses);
            Controls.Add(txtSearchExams);
            MinimumSize = new System.Drawing.Size(640, 400);
            Name = "Exams";
            Size = new System.Drawing.Size(1000, 504);
            ((System.ComponentModel.ISupportInitialize)dgvExams).EndInit();
            pnlFilterCourses.ResumeLayout(false);
            pnlFilterCourses.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtSearchExams;
        private Guna.UI2.WinForms.Guna2Button btnFilterCourses;
        private System.Windows.Forms.FlowLayoutPanel flpActiveFiltersExams;
        private Guna.UI2.WinForms.Guna2DataGridView dgvExams;
        private System.Windows.Forms.Label lblNoRecords;
        private Guna.UI2.WinForms.Guna2Panel pnlFilterCourses;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblSY;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSchoolYear;
        private System.Windows.Forms.Label lblTerm;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTerm;
        private System.Windows.Forms.Label lblCourse;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCourse;
        private System.Windows.Forms.Label lblSection;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSection;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnApply;
    }
}
