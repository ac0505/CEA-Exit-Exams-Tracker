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

            pnlCardsContainer = new System.Windows.Forms.Panel();
            pnlCardRate = new Guna.UI2.WinForms.Guna2Panel();
            lblCardRateValue = new System.Windows.Forms.Label();
            lblCardRateTitle = new System.Windows.Forms.Label();
            pnlCardCompletion = new Guna.UI2.WinForms.Guna2Panel();
            lblCardCompletionValue = new System.Windows.Forms.Label();
            lblCardCompletionTitle = new System.Windows.Forms.Label();
            pnlCardPassed = new Guna.UI2.WinForms.Guna2Panel();
            lblCardPassedValue = new System.Windows.Forms.Label();
            lblCardPassedTitle = new System.Windows.Forms.Label();
            pnlCardTotal = new Guna.UI2.WinForms.Guna2Panel();
            lblCardTotalValue = new System.Windows.Forms.Label();
            lblCardTotalTitle = new System.Windows.Forms.Label();
            lblSectionTitle = new System.Windows.Forms.Label();
            dgvDashboard = new Guna.UI2.WinForms.Guna2DataGridView();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();

            pnlCardsContainer.SuspendLayout();
            pnlCardRate.SuspendLayout();
            pnlCardCompletion.SuspendLayout();
            pnlCardPassed.SuspendLayout();
            pnlCardTotal.SuspendLayout();
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
            pnlCardsContainer.Size = new System.Drawing.Size(960, 105);
            pnlCardsContainer.TabIndex = 0;

            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BorderRadius = 8;
            pnlCardTotal.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            pnlCardTotal.BorderThickness = 1;
            pnlCardTotal.Controls.Add(lblCardTotalValue);
            pnlCardTotal.Controls.Add(lblCardTotalTitle);
            pnlCardTotal.FillColor = System.Drawing.Color.FromArgb(240, 244, 255);
            pnlCardTotal.Location = new System.Drawing.Point(0, 0);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.ShadowDecoration.CustomizableEdges = customizableEdges1;
            pnlCardTotal.Size = new System.Drawing.Size(225, 100);
            pnlCardTotal.TabIndex = 0;

            // 
            // lblCardTotalTitle
            // 
            lblCardTotalTitle.AutoSize = true;
            lblCardTotalTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCardTotalTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblCardTotalTitle.Location = new System.Drawing.Point(18, 16);
            lblCardTotalTitle.Name = "lblCardTotalTitle";
            lblCardTotalTitle.Size = new System.Drawing.Size(107, 15);
            lblCardTotalTitle.TabIndex = 0;
            lblCardTotalTitle.Text = "TOTAL STUDENTS";

            // 
            // lblCardTotalValue
            // 
            lblCardTotalValue.AutoSize = true;
            lblCardTotalValue.BackColor = System.Drawing.Color.Transparent;
            lblCardTotalValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblCardTotalValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblCardTotalValue.Location = new System.Drawing.Point(15, 38);
            lblCardTotalValue.Name = "lblCardTotalValue";
            lblCardTotalValue.Size = new System.Drawing.Size(38, 45);
            lblCardTotalValue.TabIndex = 1;
            lblCardTotalValue.Text = "0";

            // 
            // pnlCardPassed
            // 
            pnlCardPassed.BorderRadius = 8;
            pnlCardPassed.BorderColor = System.Drawing.Color.FromArgb(167, 243, 208);
            pnlCardPassed.BorderThickness = 1;
            pnlCardPassed.Controls.Add(lblCardPassedValue);
            pnlCardPassed.Controls.Add(lblCardPassedTitle);
            pnlCardPassed.FillColor = System.Drawing.Color.FromArgb(236, 253, 245);
            pnlCardPassed.Location = new System.Drawing.Point(245, 0);
            pnlCardPassed.Name = "pnlCardPassed";
            pnlCardPassed.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlCardPassed.Size = new System.Drawing.Size(225, 100);
            pnlCardPassed.TabIndex = 1;

            // 
            // lblCardPassedTitle
            // 
            lblCardPassedTitle.AutoSize = true;
            lblCardPassedTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardPassedTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCardPassedTitle.ForeColor = System.Drawing.Color.FromArgb(4, 120, 87);
            lblCardPassedTitle.Location = new System.Drawing.Point(18, 16);
            lblCardPassedTitle.Name = "lblCardPassedTitle";
            lblCardPassedTitle.Size = new System.Drawing.Size(90, 15);
            lblCardPassedTitle.TabIndex = 0;
            lblCardPassedTitle.Text = "TOTAL PASSED";

            // 
            // lblCardPassedValue
            // 
            lblCardPassedValue.AutoSize = true;
            lblCardPassedValue.BackColor = System.Drawing.Color.Transparent;
            lblCardPassedValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblCardPassedValue.ForeColor = System.Drawing.Color.FromArgb(6, 95, 70);
            lblCardPassedValue.Location = new System.Drawing.Point(15, 38);
            lblCardPassedValue.Name = "lblCardPassedValue";
            lblCardPassedValue.Size = new System.Drawing.Size(38, 45);
            lblCardPassedValue.TabIndex = 1;
            lblCardPassedValue.Text = "0";

            // 
            // pnlCardCompletion
            // 
            pnlCardCompletion.BorderRadius = 8;
            pnlCardCompletion.BorderColor = System.Drawing.Color.FromArgb(254, 240, 138);
            pnlCardCompletion.BorderThickness = 1;
            pnlCardCompletion.Controls.Add(lblCardCompletionValue);
            pnlCardCompletion.Controls.Add(lblCardCompletionTitle);
            pnlCardCompletion.FillColor = System.Drawing.Color.FromArgb(254, 252, 232);
            pnlCardCompletion.Location = new System.Drawing.Point(490, 0);
            pnlCardCompletion.Name = "pnlCardCompletion";
            pnlCardCompletion.ShadowDecoration.CustomizableEdges = customizableEdges3;
            pnlCardCompletion.Size = new System.Drawing.Size(225, 100);
            pnlCardCompletion.TabIndex = 2;

            // 
            // lblCardCompletionTitle
            // 
            lblCardCompletionTitle.AutoSize = true;
            lblCardCompletionTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardCompletionTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCardCompletionTitle.ForeColor = System.Drawing.Color.FromArgb(161, 98, 7);
            lblCardCompletionTitle.Location = new System.Drawing.Point(18, 16);
            lblCardCompletionTitle.Name = "lblCardCompletionTitle";
            lblCardCompletionTitle.Size = new System.Drawing.Size(127, 15);
            lblCardCompletionTitle.TabIndex = 0;
            lblCardCompletionTitle.Text = "UNDER COMPLETION";

            // 
            // lblCardCompletionValue
            // 
            lblCardCompletionValue.AutoSize = true;
            lblCardCompletionValue.BackColor = System.Drawing.Color.Transparent;
            lblCardCompletionValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblCardCompletionValue.ForeColor = System.Drawing.Color.FromArgb(133, 77, 14);
            lblCardCompletionValue.Location = new System.Drawing.Point(15, 38);
            lblCardCompletionValue.Name = "lblCardCompletionValue";
            lblCardCompletionValue.Size = new System.Drawing.Size(38, 45);
            lblCardCompletionValue.TabIndex = 1;
            lblCardCompletionValue.Text = "0";

            // 
            // pnlCardRate
            // 
            pnlCardRate.BorderRadius = 8;
            pnlCardRate.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            pnlCardRate.BorderThickness = 1;
            pnlCardRate.Controls.Add(lblCardRateValue);
            pnlCardRate.Controls.Add(lblCardRateTitle);
            pnlCardRate.FillColor = System.Drawing.Color.White;
            pnlCardRate.Location = new System.Drawing.Point(735, 0);
            pnlCardRate.Name = "pnlCardRate";
            pnlCardRate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlCardRate.Size = new System.Drawing.Size(225, 100);
            pnlCardRate.TabIndex = 3;

            // 
            // lblCardRateTitle
            // 
            lblCardRateTitle.AutoSize = true;
            lblCardRateTitle.BackColor = System.Drawing.Color.Transparent;
            lblCardRateTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCardRateTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblCardRateTitle.Location = new System.Drawing.Point(18, 16);
            lblCardRateTitle.Name = "lblCardRateTitle";
            lblCardRateTitle.Size = new System.Drawing.Size(91, 15);
            lblCardRateTitle.TabIndex = 0;
            lblCardRateTitle.Text = "PASSING RATE";

            // 
            // lblCardRateValue
            // 
            lblCardRateValue.AutoSize = true;
            lblCardRateValue.BackColor = System.Drawing.Color.Transparent;
            lblCardRateValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblCardRateValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblCardRateValue.Location = new System.Drawing.Point(15, 38);
            lblCardRateValue.Name = "lblCardRateValue";
            lblCardRateValue.Size = new System.Drawing.Size(89, 45);
            lblCardRateValue.TabIndex = 1;
            lblCardRateValue.Text = "0.0%";

            // 
            // lblSectionTitle
            // 
            lblSectionTitle.AutoSize = true;
            lblSectionTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblSectionTitle.Location = new System.Drawing.Point(20, 134);
            lblSectionTitle.Name = "lblSectionTitle";
            lblSectionTitle.Size = new System.Drawing.Size(252, 21);
            lblSectionTitle.TabIndex = 1;
            lblSectionTitle.Text = "Course Exit Exams Performance";

            // 
            // txtSearch
            // 
            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSearch.BorderRadius = 4;
            txtSearch.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            txtSearch.CustomizableEdges = customizableEdges5;
            txtSearch.DefaultText = "";
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSearch.Location = new System.Drawing.Point(740, 128);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search course...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSearch.Size = new System.Drawing.Size(240, 32);
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
            dgvDashboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(48, 48, 48); // #303030
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(170, 170, 170); // #AAAAAA
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvDashboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDashboard.ColumnHeadersHeight = 35;
            dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(170, 170, 170); // #AAAAAA
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvDashboard.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDashboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgvDashboard.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgvDashboard.Location = new System.Drawing.Point(20, 168);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.ReadOnly = true;
            dgvDashboard.RowHeadersVisible = false;
            dgvDashboard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvDashboard.RowTemplate.Height = 34;
            dgvDashboard.Size = new System.Drawing.Size(960, 315);
            dgvDashboard.TabIndex = 3;
            dgvDashboard.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvDashboard.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dgvDashboard.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dgvDashboard.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvDashboard.ThemeStyle.HeaderStyle.Height = 35;
            dgvDashboard.ThemeStyle.ReadOnly = true;
            dgvDashboard.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(170, 170, 170);

            // 
            // Dashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            Controls.Add(txtSearch);
            Controls.Add(dgvDashboard);
            Controls.Add(lblSectionTitle);
            Controls.Add(pnlCardsContainer);
            MinimumSize = new System.Drawing.Size(1000, 504);
            Name = "Dashboard";
            Size = new System.Drawing.Size(1000, 504);
            pnlCardsContainer.ResumeLayout(false);
            pnlCardRate.ResumeLayout(false);
            pnlCardRate.PerformLayout();
            pnlCardCompletion.ResumeLayout(false);
            pnlCardCompletion.PerformLayout();
            pnlCardPassed.ResumeLayout(false);
            pnlCardPassed.PerformLayout();
            pnlCardTotal.ResumeLayout(false);
            pnlCardTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label lblSectionTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDashboard;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    }
}
