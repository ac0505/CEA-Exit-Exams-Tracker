using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace StudentGradeTracker
{
    public class AddStudentForm : Form
    {
        private Guna2TextBox txtSchoolID = null!;
        private Guna2TextBox txtFirstName = null!;
        private Guna2TextBox txtLastName = null!;
        private Guna2TextBox txtMiddleInitial = null!;
        private Guna2ComboBox cmbProgram = null!;
        private Guna2TextBox txtCourseCode = null!;
        private Guna2TextBox txtSection = null!;
        private Guna2ComboBox cmbStatus = null!;
        private Guna2TextBox txtTerm = null!;
        private Guna2TextBox txtSchoolYear = null!;
        private Guna2Button btnSave = null!;
        private Guna2Button btnCancel = null!;
        private Label lblError = null!;

        public StudentRecord? CreatedRecord { get; private set; }

        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Add Student Record";
            this.Size = new Size(520, 620);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(248, 249, 252);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(39, 39, 39)
            };

            var lblTitle = new Label
            {
                Text = "Add New Student Record",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 16),
                AutoSize = true
            };
            headerPanel.Controls.Add(lblTitle);
            this.Controls.Add(headerPanel);

            int startY = 75;
            int rowHeight = 44;
            int labelWidth = 110;
            int inputWidth = 340;
            int leftCol = 25;

            // School ID
            CreateRow("School ID *:", ref startY, rowHeight, labelWidth, leftCol, out txtSchoolID);
            txtSchoolID.PlaceholderText = "e.g., 2021-12345";

            // First Name
            CreateRow("First Name *:", ref startY, rowHeight, labelWidth, leftCol, out txtFirstName);
            txtFirstName.PlaceholderText = "First Name";

            // Last Name
            CreateRow("Last Name *:", ref startY, rowHeight, labelWidth, leftCol, out txtLastName);
            txtLastName.PlaceholderText = "Last Name";

            // Middle Initial
            CreateRow("M.I:", ref startY, rowHeight, labelWidth, leftCol, out txtMiddleInitial);
            txtMiddleInitial.MaxLength = 5;
            txtMiddleInitial.PlaceholderText = "e.g., A.";

            // Program
            var lblProg = new Label
            {
                Text = "Program *:",
                Location = new Point(leftCol, startY + 6),
                Size = new Size(labelWidth, 24),
                ForeColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            this.Controls.Add(lblProg);

            cmbProgram = new Guna2ComboBox
            {
                Location = new Point(leftCol + labelWidth, startY),
                Size = new Size(inputWidth, 36),
                BorderRadius = 4,
                BorderColor = Color.FromArgb(200, 200, 200),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbProgram.Items.AddRange(ExcelDatabaseManager.ValidPrograms);
            cmbProgram.SelectedIndex = 0;
            this.Controls.Add(cmbProgram);
            startY += rowHeight;

            // Course Code
            CreateRow("Course Code *:", ref startY, rowHeight, labelWidth, leftCol, out txtCourseCode);
            txtCourseCode.PlaceholderText = "e.g., CPE 501 / CE 401";

            // Section
            CreateRow("Section:", ref startY, rowHeight, labelWidth, leftCol, out txtSection);
            txtSection.PlaceholderText = "e.g., 4A / CPE-4A";

            // Status
            var lblStatus = new Label
            {
                Text = "Status *:",
                Location = new Point(leftCol, startY + 6),
                Size = new Size(labelWidth, 24),
                ForeColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            this.Controls.Add(lblStatus);

            cmbStatus = new Guna2ComboBox
            {
                Location = new Point(leftCol + labelWidth, startY),
                Size = new Size(inputWidth, 36),
                BorderRadius = 4,
                BorderColor = Color.FromArgb(200, 200, 200),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "Passed", "Completion" });
            cmbStatus.SelectedIndex = 1; // Default to Completion
            this.Controls.Add(cmbStatus);
            startY += rowHeight;

            // Term
            CreateRow("Term:", ref startY, rowHeight, labelWidth, leftCol, out txtTerm);
            txtTerm.PlaceholderText = "e.g., 1st Term / 2nd Term";

            // School Year
            CreateRow("School Year:", ref startY, rowHeight, labelWidth, leftCol, out txtSchoolYear);
            txtSchoolYear.PlaceholderText = "e.g., 2023-2024";

            // Error Label
            lblError = new Label
            {
                Location = new Point(leftCol + labelWidth, startY),
                Size = new Size(inputWidth, 30),
                ForeColor = Color.Crimson,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                Visible = false
            };
            this.Controls.Add(lblError);
            startY += 30;

            // Action Buttons
            btnSave = new Guna2Button
            {
                Text = "Save Student",
                Location = new Point(leftCol + labelWidth, startY),
                Size = new Size(160, 38),
                BorderRadius = 4,
                FillColor = Color.FromArgb(39, 39, 39), // #272727
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(leftCol + labelWidth + 175, startY),
                Size = new Size(160, 38),
                BorderRadius = 4,
                FillColor = Color.FromArgb(220, 220, 220),
                ForeColor = Color.FromArgb(50, 50, 50),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancel);
        }

        private void CreateRow(string labelText, ref int currentY, int height, int labelWidth, int leftCol, out Guna2TextBox textBox)
        {
            var lbl = new Label
            {
                Text = labelText,
                Location = new Point(leftCol, currentY + 6),
                Size = new Size(labelWidth, 24),
                ForeColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            this.Controls.Add(lbl);

            textBox = new Guna2TextBox
            {
                Location = new Point(leftCol + labelWidth, currentY),
                Size = new Size(340, 36),
                BorderRadius = 4,
                BorderColor = Color.FromArgb(200, 200, 200),
                Font = new Font("Segoe UI", 9F)
            };
            this.Controls.Add(textBox);

            currentY += height;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblError.Visible = false;

            var rec = new StudentRecord
            {
                SchoolID      = txtSchoolID.Text.Trim(),
                FirstName     = txtFirstName.Text.Trim(),
                LastName      = txtLastName.Text.Trim(),
                MiddleInitial = txtMiddleInitial.Text.Trim(),
                Program       = cmbProgram.SelectedItem?.ToString() ?? "",
                CourseCode    = txtCourseCode.Text.Trim().ToUpperInvariant(),
                Section       = txtSection.Text.Trim().ToUpperInvariant(),
                Status        = cmbStatus.SelectedItem?.ToString() ?? "Completion",
                Term          = txtTerm.Text.Trim(),
                SchoolYear    = txtSchoolYear.Text.Trim()
            };

            if (ExcelDatabaseManager.Instance.AddStudent(rec, out string err))
            {
                CreatedRecord = rec;
                MessageBox.Show("Student record successfully added and saved to Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = err;
                lblError.Visible = true;
            }
        }
    }
}
