using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using StudentGradeTracker.User_Controls;

namespace StudentGradeTracker
{
    public partial class Form1 : Form
    {
        private readonly Dashboard dashboard = new Dashboard();
        private readonly Students students = new Students();
        private readonly Exams exams = new Exams();

        // Native methods for smooth borderless window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();
            SetupWindowDragging();
            SetActiveTab(btnDashboard, dashboard);
        }

        private void SetupWindowDragging()
        {
            panel1.MouseDown += DragPanel_MouseDown;
            label1.MouseDown += DragPanel_MouseDown;
            pictureBox1.MouseDown += DragPanel_MouseDown;
        }

        private void DragPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void SetActiveTab(Guna2Button activeButton, UserControl control)
        {
            // Update button styles
            ResetTabButton(btnDashboard);
            ResetTabButton(btnStudents);
            ResetTabButton(btnExams);

            activeButton.CustomBorderThickness = new Padding(0, 0, 0, 4);
            activeButton.CustomBorderColor = Color.FromArgb(37, 99, 235);
            activeButton.ForeColor = Color.FromArgb(30, 64, 175);
            activeButton.FillColor = Color.FromArgb(239, 246, 255);

            // Switch view
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
            control.BringToFront();
        }

        private void ResetTabButton(Guna2Button btn)
        {
            btn.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btn.CustomBorderColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(71, 85, 105);
            btn.FillColor = Color.FromArgb(248, 250, 252);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initial load of students data into memory and Excel
            ExcelDatabaseManager.Instance.Load();
            dashboard.LoadDashboardData();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard.LoadDashboardData();
            SetActiveTab(btnDashboard, dashboard);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            students.LoadStudentData();
            SetActiveTab(btnStudents, students);
        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            exams.LoadExamsData();
            SetActiveTab(btnExams, exams);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
            UpdateMaximizeButtonIcon();
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            UpdateMaximizeButtonIcon();
        }

        private void UpdateMaximizeButtonIcon()
        {
            if (btnMaximize != null)
            {
                btnMaximize.Text = WindowState == FormWindowState.Maximized ? "\uE923" : "\uE922";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
