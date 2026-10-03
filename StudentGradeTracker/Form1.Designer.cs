namespace StudentGradeTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            panel1 = new Panel();
            btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            btnMaximize = new Guna.UI2.WinForms.Guna2Button();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnExams = new Guna.UI2.WinForms.Guna2Button();
            btnStudents = new Guna.UI2.WinForms.Guna2Button();
            btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            pnlContainer = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(39, 39, 39);
            panel1.Controls.Add(btnMinimize);
            panel1.Controls.Add(btnMaximize);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 56);
            panel1.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.CustomizableEdges = customizableEdges1;
            btnMinimize.DisabledState.BorderColor = Color.DarkGray;
            btnMinimize.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMinimize.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMinimize.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMinimize.FillColor = Color.Transparent;
            btnMinimize.Font = new Font("Segoe UI", 9F);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.HoverState.FillColor = Color.FromArgb(58, 58, 58);
            btnMinimize.Image = (Image)resources.GetObject("btnMinimize.Image");
            btnMinimize.ImageSize = new Size(15, 15);
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.Location = new Point(880, 16);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnMinimize.Size = new Size(28, 24);
            btnMinimize.TabIndex = 4;
            btnMinimize.Click += btnMinimize_Click;
            //
            // btnMaximize
            // 
            btnMaximize.CustomizableEdges = customizableEdges11;
            btnMaximize.FillColor = Color.Transparent;
            btnMaximize.Font = new Font("Segoe UI", 9F);
            btnMaximize.ForeColor = Color.White;
            btnMaximize.HoverState.FillColor = Color.FromArgb(58, 58, 58);
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.Location = new Point(916, 16);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnMaximize.Size = new Size(28, 24);
            btnMaximize.TabIndex = 5;
            btnMaximize.Text = "";
            btnMaximize.Click += btnMaximize_Click;
            //
            // btnClose
            // 
            btnClose.CustomizableEdges = customizableEdges3;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(952, 16);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClose.Size = new Size(28, 24);
            btnClose.TabIndex = 6;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(69, 7);
            label1.Name = "label1";
            label1.Size = new Size(209, 39);
            label1.TabIndex = 1;
            label1.Text = "CEA Exit Exams Tracker";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(248, 250, 252);
            panel2.Controls.Add(btnExams);
            panel2.Controls.Add(btnStudents);
            panel2.Controls.Add(btnDashboard);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 56);
            panel2.Name = "panel2";
            panel2.Size = new Size(1000, 48);
            panel2.TabIndex = 1;
            // 
            // btnExams
            // 
            btnExams.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnExams.CustomBorderColor = Color.FromArgb(5, 11, 112);
            btnExams.CustomBorderThickness = new Padding(0, 0, 0, 4);
            btnExams.CustomizableEdges = customizableEdges5;
            btnExams.DisabledState.BorderColor = Color.DarkGray;
            btnExams.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExams.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExams.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExams.FillColor = Color.White;
            btnExams.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExams.ForeColor = Color.FromArgb(39, 39, 39);
            btnExams.HoverState.CustomBorderColor = Color.FromArgb(5, 11, 112);
            btnExams.Location = new Point(312, 0);
            btnExams.Name = "btnExams";
            btnExams.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnExams.Size = new Size(150, 48);
            btnExams.TabIndex = 2;
            btnExams.Text = "Exams";
            btnExams.Click += btnExams_Click;
            // 
            // btnStudents
            // 
            btnStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnStudents.CustomBorderColor = Color.FromArgb(5, 11, 112);
            btnStudents.CustomBorderThickness = new Padding(0, 0, 0, 4);
            btnStudents.CustomizableEdges = customizableEdges7;
            btnStudents.DisabledState.BorderColor = Color.DarkGray;
            btnStudents.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStudents.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStudents.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStudents.FillColor = Color.White;
            btnStudents.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudents.ForeColor = Color.FromArgb(39, 39, 39);
            btnStudents.HoverState.CustomBorderColor = Color.FromArgb(5, 11, 112);
            btnStudents.Location = new Point(156, 0);
            btnStudents.Name = "btnStudents";
            btnStudents.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnStudents.Size = new Size(150, 48);
            btnStudents.TabIndex = 1;
            btnStudents.Text = "Students";
            btnStudents.Click += btnStudents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnDashboard.CustomBorderColor = Color.FromArgb(5, 11, 112);
            btnDashboard.CustomBorderThickness = new Padding(0, 0, 0, 4);
            btnDashboard.CustomizableEdges = customizableEdges9;
            btnDashboard.DisabledState.BorderColor = Color.DarkGray;
            btnDashboard.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDashboard.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDashboard.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDashboard.FillColor = Color.White;
            btnDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.FromArgb(39, 39, 39);
            btnDashboard.HoverState.CustomBorderColor = Color.FromArgb(5, 11, 112);
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnDashboard.Size = new Size(150, 48);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 104);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1000, 520);
            pnlContainer.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1260, 750);
            Controls.Add(pnlContainer);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(980, 620);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel2;
        private Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnExams;
        private Guna.UI2.WinForms.Guna2Button btnStudents;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnMaximize;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
