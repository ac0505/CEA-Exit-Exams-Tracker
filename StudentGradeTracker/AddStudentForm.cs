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
            this.Size = new Size(620, 700);
            this.MinimumSize = new Size(520, 620);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            var rootLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = BackColor
            };
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));

            var headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(15, 23, 42)
            };
            var lblTitle = new Label
            {
                Text = "Add New Student Record",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblTitle);

            var contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(24, 14, 24, 8),
                BackColor = BackColor
            };
            var fieldsLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 11,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = Color.Transparent
            };
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int row = 0; row < 10; row++)
                fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            fieldsLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddTextField(fieldsLayout, 0, "School ID *:", "e.g., 2021-12345", out txtSchoolID);
            AddTextField(fieldsLayout, 1, "First Name *:", "First Name", out txtFirstName);
            AddTextField(fieldsLayout, 2, "Last Name *:", "Last Name", out txtLastName);
            AddTextField(fieldsLayout, 3, "M.I:", "e.g., A.", out txtMiddleInitial, 5);

            AddFieldLabel(fieldsLayout, 4, "Program *:");
            cmbProgram = new Guna2ComboBox
            {
                Dock = DockStyle.Top,
                Height = 36,
                Margin = new Padding(0, 5, 0, 5),
                BorderRadius = 8,
                BorderColor = Color.FromArgb(203, 213, 225),
                FillColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbProgram.Items.AddRange(ExcelDatabaseManager.ValidPrograms);
            cmbProgram.SelectedIndex = 0;
            fieldsLayout.Controls.Add(cmbProgram, 1, 4);

            AddTextField(fieldsLayout, 5, "Course Code *:", "e.g., CPE 501 / CE 401", out txtCourseCode);
            AddTextField(fieldsLayout, 6, "Section:", "e.g., 4A / CPE-4A", out txtSection);

            AddFieldLabel(fieldsLayout, 7, "Status *:");
            cmbStatus = new Guna2ComboBox
            {
                Dock = DockStyle.Top,
                Height = 36,
                Margin = new Padding(0, 5, 0, 5),
                BorderRadius = 8,
                BorderColor = Color.FromArgb(203, 213, 225),
                FillColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "Passed", "Completion" });
            cmbStatus.SelectedIndex = 1; // Default to Completion
            fieldsLayout.Controls.Add(cmbStatus, 1, 7);

            AddTextField(fieldsLayout, 8, "Term:", "e.g., 1st Term / 2nd Term", out txtTerm);
            AddTextField(fieldsLayout, 9, "School Year:", "e.g., 2023-2024", out txtSchoolYear);

            lblError = new Label
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 6, 0, 0),
                ForeColor = Color.Crimson,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                Visible = false
            };
            fieldsLayout.Controls.Add(lblError, 0, 10);
            fieldsLayout.SetColumnSpan(lblError, 2);
            contentPanel.Controls.Add(fieldsLayout);

            var actionPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(241, 245, 249)
            };
            btnSave = new Guna2Button
            {
                Text = "Save Student",
                Size = new Size(145, 38),
                BorderRadius = 8,
                Animated = true,
                FillColor = Color.FromArgb(30, 64, 175),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Image = IconHelper.CreateCheckIcon(13, Color.White),
                ImageSize = new Size(13, 13),
                ImageAlign = HorizontalAlignment.Left,
                ImageOffset = new Point(8, 0),
                TextOffset = new Point(4, 0)
            };
            btnSave.Click += BtnSave_Click;
            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Size = new Size(120, 38),
                BorderRadius = 8,
                Animated = true,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(148, 163, 184),
                BorderThickness = 1,
                ForeColor = Color.FromArgb(51, 65, 85),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Image = IconHelper.CreateCloseIcon(13, Color.FromArgb(51, 65, 85)),
                ImageSize = new Size(13, 13),
                ImageAlign = HorizontalAlignment.Left,
                ImageOffset = new Point(8, 0),
                TextOffset = new Point(4, 0)
            };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            actionPanel.Controls.Add(btnSave);
            actionPanel.Controls.Add(btnCancel);
            actionPanel.Resize += (s, e) => LayoutActionButtons(actionPanel);

            rootLayout.Controls.Add(headerPanel, 0, 0);
            rootLayout.Controls.Add(contentPanel, 0, 1);
            rootLayout.Controls.Add(actionPanel, 0, 2);
            this.Controls.Add(rootLayout);
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            LayoutActionButtons(actionPanel);
        }

        private static void AddFieldLabel(TableLayoutPanel layout, int row, string text)
        {
            var lbl = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0, 0, 10, 0),
                ForeColor = Color.FromArgb(51, 65, 85),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            layout.Controls.Add(lbl, 0, row);
        }

        private static void AddTextField(TableLayoutPanel layout, int row, string label, string placeholder, out Guna2TextBox textBox, int maxLength = 0)
        {
            AddFieldLabel(layout, row, label);
            textBox = new Guna2TextBox
            {
                Dock = DockStyle.Top,
                Height = 36,
                Margin = new Padding(0, 5, 0, 5),
                BorderRadius = 8,
                BorderColor = Color.FromArgb(203, 213, 225),
                FillColor = Color.White,
                Font = new Font("Segoe UI", 9F),
                PlaceholderText = placeholder,
                MaxLength = maxLength
            };
            layout.Controls.Add(textBox, 1, row);
        }

        private void LayoutActionButtons(Panel panel)
        {
            int y = Math.Max(0, (panel.ClientSize.Height - btnSave.Height) / 2);
            btnCancel.Location = new Point(panel.ClientSize.Width - 24 - btnCancel.Width, y);
            btnSave.Location = new Point(btnCancel.Left - 12 - btnSave.Width, y);
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
