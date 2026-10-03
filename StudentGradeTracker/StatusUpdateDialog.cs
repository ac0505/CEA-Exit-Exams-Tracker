using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace StudentGradeTracker
{
    public class StatusUpdateDialog : Form
    {
        private Guna2ComboBox cmbStatus;
        private Guna2Button btnConfirm;
        private Guna2Button btnCancel;

        public string SelectedStatus => cmbStatus.SelectedItem?.ToString() ?? "Passed";

        public StatusUpdateDialog(int selectedCount)
        {
            this.Text = "Update Status";
            this.Size = new Size(380, 230);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(248, 249, 252);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            var lblPrompt = new Label
            {
                Text = $"Update status for {selectedCount} selected student(s):",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                Location = new Point(25, 25),
                AutoSize = true
            };
            this.Controls.Add(lblPrompt);

            cmbStatus = new Guna2ComboBox
            {
                Location = new Point(25, 60),
                Size = new Size(310, 36),
                BorderRadius = 8,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5F)
            };
            cmbStatus.Items.AddRange(new object[] { "Passed", "Completion" });
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            btnConfirm = new Guna2Button
            {
                Text = "Update",
                Location = new Point(25, 120),
                Size = new Size(145, 36),
                BorderRadius = 8,
                Animated = true,
                FillColor = Color.FromArgb(39, 39, 39),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Image = IconHelper.CreateCheckIcon(13, Color.White),
                ImageSize = new Size(13, 13),
                ImageAlign = HorizontalAlignment.Left,
                ImageOffset = new Point(10, 0),
                TextOffset = new Point(4, 0)
            };
            btnConfirm.Click += (s, e) =>
            {
                var res = MessageBox.Show(
                    $"Are you sure you want to set the status of {selectedCount} student(s) to '{SelectedStatus}'?",
                    "Confirm Status Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
            this.Controls.Add(btnConfirm);

            btnCancel = new Guna2Button
            {
                Text = "Cancel",
                Location = new Point(190, 120),
                Size = new Size(145, 36),
                BorderRadius = 8,
                Animated = true,
                FillColor = Color.Transparent,
                BorderColor = Color.FromArgb(148, 163, 184),
                BorderThickness = 1,
                ForeColor = Color.FromArgb(51, 65, 85),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Image = IconHelper.CreateCloseIcon(13, Color.FromArgb(51, 65, 85)),
                ImageSize = new Size(13, 13),
                ImageAlign = HorizontalAlignment.Left,
                ImageOffset = new Point(10, 0),
                TextOffset = new Point(4, 0)
            };
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancel);
        }
    }
}
