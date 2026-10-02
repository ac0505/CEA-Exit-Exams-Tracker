using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Bitmap? _maximizeIcon;
        private Bitmap? _restoreIcon;
        private Rectangle _restoreBounds;
        private bool _isWindowMaximized;

        // Native methods for smooth borderless window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int WM_NCHITTEST = 0x84;
        private const int ResizeBorderSize = 8;

        public Form1()
        {
            InitializeComponent();
            CreateWindowControlIcons();
            SetupWindowDragging();
            panel2.Resize += (s, e) => LayoutNavigationButtons();
            LayoutNavigationButtons();
            SetActiveTab(btnDashboard, dashboard);
            FormClosed += (s, e) =>
            {
                _maximizeIcon?.Dispose();
                _restoreIcon?.Dispose();
            };
        }

        private void CreateWindowControlIcons()
        {
            _maximizeIcon = CreateWindowIcon(false);
            _restoreIcon = CreateWindowIcon(true);
            btnMaximize.Text = string.Empty;
            btnMaximize.ImageSize = new Size(16, 16);
            btnMaximize.ImageAlign = HorizontalAlignment.Center;
            UpdateMaximizeButtonIcon();
        }

        private static Bitmap CreateWindowIcon(bool restore)
        {
            var icon = new Bitmap(16, 16);
            using var graphics = Graphics.FromImage(icon);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.White, 1.4F);

            if (restore)
            {
                graphics.DrawRectangle(pen, 5, 2, 9, 9);
                graphics.DrawRectangle(pen, 2, 5, 9, 9);
            }
            else
            {
                graphics.DrawRectangle(pen, 3, 3, 10, 10);
            }

            return icon;
        }

        private void LayoutNavigationButtons()
        {
            int tabWidth = panel2.ClientSize.Width / 3;
            var buttons = new[] { btnDashboard, btnStudents, btnExams };

            for (int index = 0; index < buttons.Length; index++)
            {
                buttons[index].Bounds = new Rectangle(index * tabWidth, 0,
                    index == buttons.Length - 1 ? panel2.ClientSize.Width - index * tabWidth : tabWidth,
                    panel2.ClientSize.Height);
            }
        }

        private void SetupWindowDragging()
        {
            panel1.MouseDown += DragPanel_MouseDown;
            label1.MouseDown += DragPanel_MouseDown;
            pictureBox1.MouseDown += DragPanel_MouseDown;
        }

        private void DragPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_isWindowMaximized)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST && WindowState == FormWindowState.Normal && !_isWindowMaximized)
            {
                long coordinates = m.LParam.ToInt64();
                int screenX = unchecked((short)(coordinates & 0xFFFF));
                int screenY = unchecked((short)((coordinates >> 16) & 0xFFFF));
                Point point = PointToClient(new Point(screenX, screenY));
                bool left = point.X < ResizeBorderSize;
                bool right = point.X >= ClientSize.Width - ResizeBorderSize;
                bool top = point.Y < ResizeBorderSize;
                bool bottom = point.Y >= ClientSize.Height - ResizeBorderSize;

                int hitTest = (left, right, top, bottom) switch
                {
                    (true, _, true, _) => HTTOPLEFT,
                    (_, true, true, _) => HTTOPRIGHT,
                    (true, _, _, true) => HTBOTTOMLEFT,
                    (_, true, _, true) => HTBOTTOMRIGHT,
                    (true, _, _, _) => HTLEFT,
                    (_, true, _, _) => HTRIGHT,
                    (_, _, true, _) => HTTOP,
                    (_, _, _, true) => HTBOTTOM,
                    _ => 0
                };

                if (hitTest != 0)
                {
                    m.Result = (IntPtr)hitTest;
                    return;
                }
            }

            base.WndProc(ref m);
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
            Rectangle workingArea = Screen.FromControl(this).WorkingArea;
            int width = Math.Min(1200, workingArea.Width - 48);
            int height = Math.Min(700, workingArea.Height - 48);
            Size = new Size(Math.Max(MinimumSize.Width, width), Math.Max(MinimumSize.Height, height));
            Location = new Point(
                workingArea.Left + (workingArea.Width - Width) / 2,
                workingArea.Top + (workingArea.Height - Height) / 2);

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
            if (_isWindowMaximized)
            {
                _isWindowMaximized = false;
                Bounds = _restoreBounds;
            }
            else
            {
                _restoreBounds = Bounds;
                _isWindowMaximized = true;
                Bounds = Screen.FromControl(this).WorkingArea;
            }

            UpdateMaximizeButtonIcon();
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            UpdateMaximizeButtonIcon();
        }

        private void UpdateMaximizeButtonIcon()
        {
            if (btnMaximize != null && _maximizeIcon != null && _restoreIcon != null)
            {
                btnMaximize.Image = _isWindowMaximized ? _restoreIcon : _maximizeIcon;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
