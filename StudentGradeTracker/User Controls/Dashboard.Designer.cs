namespace StudentGradeTracker.User_Controls
{
    partial class Dashboard
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

            pnlCardsContainer = new System.Windows.Forms.Panel();
            pnlCardTotal = new Guna.UI2.WinForms.Guna2Panel();
            lblCardTotalValue = new System.Windows.Forms.Label();
            lblCardTotalTitle = new System.Windows.Forms.Label();
            pnlCardPassed = new Guna.UI2.WinForms.Guna2Panel();
            lblCardPassedValue = new System.Windows.Forms.Label();
            lblCardPassedTitle = new System.Windows.Forms.Label();
            pnlCardCompletion = new Guna.UI2.WinForms.Guna2Panel();
            lblCardCompletionValue = new System.Windows.Forms.Label();
            lblCardCompletionTitle = new System.Windows.Forms.Label();
            pnlCardRate = new Guna.UI2.WinForms.Guna2Panel();
            lblCardRateValue = new System.Windows.Forms.Label();
            lblCardRateTitle = new System.Windows.Forms.Label();

            pnlChartCard = new Guna.UI2.WinForms.Guna2Panel();
            lblChartTitle = new System.Windows.Forms.Label();
            btnChartStatus = new Guna.UI2.WinForms.Guna2Button();
            btnChartCourse = new Guna.UI2.WinForms.Guna2Button();
            gunaChart = new Guna.Charts.WinForms.GunaChart();
            pnlChartFooter = new System.Windows.Forms.Panel();
            lblChartFooterLeft = new System.Windows.Forms.Label();
            lblChartFooterRight = new System.Windows.Forms.Label();

            pnlTableCard = new Guna.UI2.WinForms.Guna2Panel();
            lblTableTitle = new System.Windows.Forms.Label();
            lblTableCountBadge = new System.Windows.Forms.Label();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            dgvDashboard = new Guna.UI2.WinForms.Guna2DataGridView();

            pnlCardsContainer.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlCardPassed.SuspendLayout();
            pnlCardCompletion.SuspendLayout();
            pnlCardRate.SuspendLayout();
            pnlChartCard.SuspendLayout();
            pnlChartFooter.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            SuspendLayout();

            // 
            // pnlCardsContainer
            // 
            pnlCardsContainer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlCardsContainer.Controls.Add(pnlCardRate);
            pnlCardsContainer.Controls.Add(pnlCardCompletion);
            pnlCardsContainer.Controls.Add(pnlCardPassed);
            pnlCardsContainer.Controls.Add(pnlCardTotal);
            pnlCardsContainer.Location = new System.Drawing.Point(20, 16);
            pnlCardsContainer.Name = "pnlCardsContainer";
            pnlCardsContainer.Size = new System.Drawing.Size(960, 80);
            pnlCardsContainer.TabIndex = 0;

            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BorderRadius = 10;
            pnlCardTotal.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            pnlCardTotal.BorderThickness = 1;
            pnlCardTotal.Controls.Add(lblCardTotalValue);
            pnlCardTotal.Controls.Add(lblCardTotalTitle);
            pnlCardTotal.FillColor = System.Drawing.Color.White;
            pnlCardTotal.Location = new System.Drawing.Point(0, 0);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.ShadowDecoration.CustomizableEdges = customizableEdges1;
            pnlCardTotal.Size = new System.Drawing.Size(225, 80);
            pnlCardTotal.TabIndex = 0;

            // 
            // lblCardTotalTitle
            // 
            lblCardTotalTitle.AutoSize = true;
            lblCardTotalTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardTotalTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblCardTotalTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCardTotalTitle.Location = new System.Drawing.Point(16, 12);
            lblCardTotalTitle.Name = "lblCardTotalTitle";
            lblCardTotalTitle.Size = new System.Drawing.Size(107, 13);
            lblCardTotalTitle.TabIndex = 0;
            lblCardTotalTitle.Text = "TOTAL EXAMINEES";

            // 
            // lblCardTotalValue
            // 
            lblCardTotalValue.AutoSize = true;
            lblCardTotalValue.BackColor = System.Drawing.Color.Transparent;
            lblCardTotalValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblCardTotalValue.ForeColor = System.Drawing.Color.FromArgb(39, 39, 39);
            lblCardTotalValue.Location = new System.Drawing.Point(14, 30);
            lblCardTotalValue.Name = "lblCardTotalValue";
            lblCardTotalValue.Size = new System.Drawing.Size(35, 41);
            lblCardTotalValue.TabIndex = 1;
            lblCardTotalValue.Text = "0";

            // 
            // pnlCardPassed
            // 
            pnlCardPassed.BorderRadius = 10;
            pnlCardPassed.BorderColor = System.Drawing.Color.FromArgb(187, 247, 208);
            pnlCardPassed.BorderThickness = 1;
            pnlCardPassed.Controls.Add(lblCardPassedValue);
            pnlCardPassed.Controls.Add(lblCardPassedTitle);
            pnlCardPassed.FillColor = System.Drawing.Color.FromArgb(240, 253, 244);
            pnlCardPassed.Location = new System.Drawing.Point(245, 0);
            pnlCardPassed.Name = "pnlCardPassed";
            pnlCardPassed.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlCardPassed.Size = new System.Drawing.Size(225, 80);
            pnlCardPassed.TabIndex = 1;

            // 
            // lblCardPassedTitle
            // 
            lblCardPassedTitle.AutoSize = true;
            lblCardPassedTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardPassedTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblCardPassedTitle.ForeColor = System.Drawing.Color.FromArgb(5, 150, 105);
            lblCardPassedTitle.Location = new System.Drawing.Point(16, 12);
            lblCardPassedTitle.Name = "lblCardPassedTitle";
            lblCardPassedTitle.Size = new System.Drawing.Size(86, 13);
            lblCardPassedTitle.TabIndex = 0;
            lblCardPassedTitle.Text = "TOTAL PASSED";

            // 
            // lblCardPassedValue
            // 
            lblCardPassedValue.AutoSize = true;
            lblCardPassedValue.BackColor = System.Drawing.Color.Transparent;
            lblCardPassedValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblCardPassedValue.ForeColor = System.Drawing.Color.FromArgb(6, 95, 70);
            lblCardPassedValue.Location = new System.Drawing.Point(14, 30);
            lblCardPassedValue.Name = "lblCardPassedValue";
            lblCardPassedValue.Size = new System.Drawing.Size(35, 41);
            lblCardPassedValue.TabIndex = 1;
            lblCardPassedValue.Text = "0";

            // 
            // pnlCardCompletion
            // 
            pnlCardCompletion.BorderRadius = 10;
            pnlCardCompletion.BorderColor = System.Drawing.Color.FromArgb(254, 230, 138);
            pnlCardCompletion.BorderThickness = 1;
            pnlCardCompletion.Controls.Add(lblCardCompletionValue);
            pnlCardCompletion.Controls.Add(lblCardCompletionTitle);
            pnlCardCompletion.FillColor = System.Drawing.Color.FromArgb(255, 251, 235);
            pnlCardCompletion.Location = new System.Drawing.Point(490, 0);
            pnlCardCompletion.Name = "pnlCardCompletion";
            pnlCardCompletion.ShadowDecoration.CustomizableEdges = customizableEdges3;
            pnlCardCompletion.Size = new System.Drawing.Size(225, 80);
            pnlCardCompletion.TabIndex = 2;

            // 
            // lblCardCompletionTitle
            // 
            lblCardCompletionTitle.AutoSize = true;
            lblCardCompletionTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardCompletionTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblCardCompletionTitle.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            lblCardCompletionTitle.Location = new System.Drawing.Point(16, 12);
            lblCardCompletionTitle.Name = "lblCardCompletionTitle";
            lblCardCompletionTitle.Size = new System.Drawing.Size(122, 13);
            lblCardCompletionTitle.TabIndex = 0;
            lblCardCompletionTitle.Text = "UNDER COMPLETION";

            // 
            // lblCardCompletionValue
            // 
            lblCardCompletionValue.AutoSize = true;
            lblCardCompletionValue.BackColor = System.Drawing.Color.Transparent;
            lblCardCompletionValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblCardCompletionValue.ForeColor = System.Drawing.Color.FromArgb(146, 64, 14);
            lblCardCompletionValue.Location = new System.Drawing.Point(14, 30);
            lblCardCompletionValue.Name = "lblCardCompletionValue";
            lblCardCompletionValue.Size = new System.Drawing.Size(35, 41);
            lblCardCompletionValue.TabIndex = 1;
            lblCardCompletionValue.Text = "0";

            // 
            // pnlCardRate
            // 
            pnlCardRate.BorderRadius = 10;
            pnlCardRate.BorderColor = System.Drawing.Color.FromArgb(191, 219, 254);
            pnlCardRate.BorderThickness = 1;
            pnlCardRate.Controls.Add(lblCardRateValue);
            pnlCardRate.Controls.Add(lblCardRateTitle);
            pnlCardRate.FillColor = System.Drawing.Color.FromArgb(239, 246, 255);
            pnlCardRate.Location = new System.Drawing.Point(735, 0);
            pnlCardRate.Name = "pnlCardRate";
            pnlCardRate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlCardRate.Size = new System.Drawing.Size(225, 80);
            pnlCardRate.TabIndex = 3;

            // 
            // lblCardRateTitle
            // 
            lblCardRateTitle.AutoSize = true;
            lblCardRateTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardRateTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblCardRateTitle.ForeColor = System.Drawing.Color.FromArgb(0, 36, 85);
            lblCardRateTitle.Location = new System.Drawing.Point(16, 12);
            lblCardRateTitle.Name = "lblCardRateTitle";
            lblCardRateTitle.Size = new System.Drawing.Size(117, 13);
            lblCardRateTitle.TabIndex = 0;
            lblCardRateTitle.Text = "OVERALL PASS RATE";

            // 
            // lblCardRateValue
            // 
            lblCardRateValue.AutoSize = true;
            lblCardRateValue.BackColor = System.Drawing.Color.Transparent;
            lblCardRateValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblCardRateValue.ForeColor = System.Drawing.Color.FromArgb(0, 36, 85);
            lblCardRateValue.Location = new System.Drawing.Point(14, 30);
            lblCardRateValue.Name = "lblCardRateValue";
            lblCardRateValue.Size = new System.Drawing.Size(95, 41);
            lblCardRateValue.TabIndex = 1;
            lblCardRateValue.Text = "0.0%";

            // 
            // pnlChartCard
            // 
            pnlChartCard.BorderRadius = 12;
            pnlChartCard.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            pnlChartCard.BorderThickness = 1;
            pnlChartCard.Controls.Add(pnlChartFooter);
            pnlChartCard.Controls.Add(gunaChart);
            pnlChartCard.Controls.Add(btnChartCourse);
            pnlChartCard.Controls.Add(btnChartStatus);
            pnlChartCard.Controls.Add(lblChartTitle);
            pnlChartCard.FillColor = System.Drawing.Color.White;
            pnlChartCard.Location = new System.Drawing.Point(20, 118);
            pnlChartCard.Name = "pnlChartCard";
            pnlChartCard.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pnlChartCard.Size = new System.Drawing.Size(415, 368);
            pnlChartCard.TabIndex = 1;

            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.BackColor = System.Drawing.Color.Transparent;
            lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(39, 39, 39);
            lblChartTitle.Location = new System.Drawing.Point(16, 14);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new System.Drawing.Size(147, 19);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Exit Exam Analytics";

            // 
            // btnChartStatus
            // 
            btnChartStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChartStatus.Animated = true;
            btnChartStatus.BorderRadius = 7;
            btnChartStatus.CustomizableEdges = customizableEdges6;
            btnChartStatus.FillColor = System.Drawing.Color.FromArgb(39, 39, 39);
            btnChartStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnChartStatus.ForeColor = System.Drawing.Color.White;
            btnChartStatus.Location = new Point(210, 10);
            btnChartStatus.Name = "btnChartStatus";
            btnChartStatus.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnChartStatus.Size = new Size(95, 28);
            btnChartStatus.TabIndex = 1;
            btnChartStatus.Text = "Status";

            // 
            // btnChartCourse
            // 
            btnChartCourse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChartCourse.Animated = true;
            btnChartCourse.BorderColor = Color.FromArgb(203, 213, 225);
            btnChartCourse.BorderRadius = 7;
            btnChartCourse.BorderThickness = 1;
            btnChartCourse.CustomizableEdges = customizableEdges8;
            btnChartCourse.FillColor = Color.White;
            btnChartCourse.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnChartCourse.ForeColor = Color.FromArgb(71, 85, 105);
            btnChartCourse.Location = new Point(310, 10);
            btnChartCourse.Name = "btnChartCourse";
            btnChartCourse.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnChartCourse.Size = new Size(95, 28);
            btnChartCourse.TabIndex = 2;
            btnChartCourse.Text = "Courses";

            // 
            // gunaChart
            // 
            gunaChart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gunaChart.BackColor = System.Drawing.Color.White;
            gunaChart.Location = new System.Drawing.Point(12, 46);
            gunaChart.Name = "gunaChart";
            gunaChart.Size = new System.Drawing.Size(391, 280);
            gunaChart.TabIndex = 3;

            // 
            // pnlChartFooter
            // 
            pnlChartFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlChartFooter.BackColor = System.Drawing.Color.Transparent;
            pnlChartFooter.Controls.Add(lblChartFooterRight);
            pnlChartFooter.Controls.Add(lblChartFooterLeft);
            pnlChartFooter.Location = new System.Drawing.Point(12, 330);
            pnlChartFooter.Name = "pnlChartFooter";
            pnlChartFooter.Size = new System.Drawing.Size(391, 30);
            pnlChartFooter.TabIndex = 4;

            // 
            // lblChartFooterLeft
            // 
            lblChartFooterLeft.AutoSize = true;
            lblChartFooterLeft.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblChartFooterLeft.ForeColor = System.Drawing.Color.FromArgb(0, 36, 85);
            lblChartFooterLeft.Location = new System.Drawing.Point(4, 8);
            lblChartFooterLeft.Name = "lblChartFooterLeft";
            lblChartFooterLeft.Size = new System.Drawing.Size(53, 13);
            lblChartFooterLeft.TabIndex = 0;
            lblChartFooterLeft.Text = "0 Passed";

            // 
            // lblChartFooterRight
            // 
            lblChartFooterRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblChartFooterRight.AutoSize = true;
            lblChartFooterRight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblChartFooterRight.ForeColor = System.Drawing.Color.FromArgb(160, 1, 0);
            lblChartFooterRight.Location = new System.Drawing.Point(260, 8);
            lblChartFooterRight.Name = "lblChartFooterRight";
            lblChartFooterRight.Size = new System.Drawing.Size(84, 13);
            lblChartFooterRight.TabIndex = 1;
            lblChartFooterRight.Text = "0 Completion";

            // 
            // pnlTableCard
            // 
            pnlTableCard.BorderRadius = 12;
            pnlTableCard.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            pnlTableCard.BorderThickness = 1;
            pnlTableCard.Controls.Add(dgvDashboard);
            pnlTableCard.Controls.Add(txtSearch);
            pnlTableCard.Controls.Add(lblTableCountBadge);
            pnlTableCard.Controls.Add(lblTableTitle);
            pnlTableCard.FillColor = System.Drawing.Color.White;
            pnlTableCard.Location = new System.Drawing.Point(445, 118);
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlTableCard.Size = new System.Drawing.Size(535, 368);
            pnlTableCard.TabIndex = 2;

            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.BackColor = System.Drawing.Color.Transparent;
            lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(39, 39, 39);
            lblTableTitle.Location = new System.Drawing.Point(16, 14);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Size = new System.Drawing.Size(142, 19);
            lblTableTitle.TabIndex = 0;
            lblTableTitle.Text = "Course Performance";

            // 
            // lblTableCountBadge
            // 
            lblTableCountBadge.AutoSize = true;
            lblTableCountBadge.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            lblTableCountBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            lblTableCountBadge.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblTableCountBadge.Location = new System.Drawing.Point(166, 17);
            lblTableCountBadge.Name = "lblTableCountBadge";
            lblTableCountBadge.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            lblTableCountBadge.Size = new System.Drawing.Size(69, 17);
            lblTableCountBadge.TabIndex = 1;
            lblTableCountBadge.Text = "0 Courses";

            // 
            // txtSearch
            // 
            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSearch.Animated = true;
            txtSearch.BorderRadius = 8;
            txtSearch.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            txtSearch.CustomizableEdges = customizableEdges11;
            txtSearch.DefaultText = "";
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            txtSearch.Location = new System.Drawing.Point(325, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search course...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtSearch.Size = new System.Drawing.Size(195, 30);
            txtSearch.TabIndex = 2;

            // 
            // dgvDashboard
            // 
            dgvDashboard.AllowUserToAddRows = false;
            dgvDashboard.AllowUserToDeleteRows = false;
            dgvDashboard.AllowUserToResizeColumns = false;
            dgvDashboard.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvDashboard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDashboard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDashboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvDashboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDashboard.ColumnHeadersHeight = 32;
            dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvDashboard.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDashboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgvDashboard.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgvDashboard.Location = new System.Drawing.Point(12, 48);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.ReadOnly = true;
            dgvDashboard.RowHeadersVisible = false;
            dgvDashboard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvDashboard.RowTemplate.Height = 32;
            dgvDashboard.Size = new System.Drawing.Size(510, 308);
            dgvDashboard.TabIndex = 3;
            dgvDashboard.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvDashboard.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(39, 39, 39);
            dgvDashboard.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvDashboard.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvDashboard.ThemeStyle.HeaderStyle.Height = 32;
            dgvDashboard.ThemeStyle.ReadOnly = true;
            dgvDashboard.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(239, 246, 255);

            // 
            // Dashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlChartCard);
            Controls.Add(pnlCardsContainer);
            MinimumSize = new System.Drawing.Size(760, 480);
            Name = "Dashboard";
            Size = new System.Drawing.Size(1000, 504);
            pnlCardsContainer.ResumeLayout(false);
            pnlCardTotal.ResumeLayout(false);
            pnlCardTotal.PerformLayout();
            pnlCardPassed.ResumeLayout(false);
            pnlCardPassed.PerformLayout();
            pnlCardCompletion.ResumeLayout(false);
            pnlCardCompletion.PerformLayout();
            pnlCardRate.ResumeLayout(false);
            pnlCardRate.PerformLayout();
            pnlChartCard.ResumeLayout(false);
            pnlChartCard.PerformLayout();
            pnlChartFooter.ResumeLayout(false);
            pnlChartFooter.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCardsContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlCardTotal;
        private System.Windows.Forms.Label lblCardTotalTitle;
        private System.Windows.Forms.Label lblCardTotalValue;

        private Guna.UI2.WinForms.Guna2Panel pnlCardPassed;
        private System.Windows.Forms.Label lblCardPassedTitle;
        private System.Windows.Forms.Label lblCardPassedValue;

        private Guna.UI2.WinForms.Guna2Panel pnlCardCompletion;
        private System.Windows.Forms.Label lblCardCompletionTitle;
        private System.Windows.Forms.Label lblCardCompletionValue;

        private Guna.UI2.WinForms.Guna2Panel pnlCardRate;
        private System.Windows.Forms.Label lblCardRateTitle;
        private System.Windows.Forms.Label lblCardRateValue;

        private Guna.UI2.WinForms.Guna2Panel pnlChartCard;
        private System.Windows.Forms.Label lblChartTitle;
        private Guna.UI2.WinForms.Guna2Button btnChartStatus;
        private Guna.UI2.WinForms.Guna2Button btnChartCourse;
        private Guna.Charts.WinForms.GunaChart gunaChart;
        private System.Windows.Forms.Panel pnlChartFooter;
        private System.Windows.Forms.Label lblChartFooterLeft;
        private System.Windows.Forms.Label lblChartFooterRight;

        private Guna.UI2.WinForms.Guna2Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.Label lblTableCountBadge;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDashboard;
    }
}

