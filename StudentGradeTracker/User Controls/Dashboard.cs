using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StudentGradeTracker.User_Controls
{
    public partial class Dashboard : UserControl
    {
        private List<ExcelDatabaseManager.CourseDashboardStat> _allStats = new List<ExcelDatabaseManager.CourseDashboardStat>();

        public Dashboard()
        {
            InitializeComponent();
            SetupGridColumns();
            ApplyVisualStyle();
            LayoutSummaryCards();

            txtSearch.TextChanged += TxtSearch_TextChanged;
            ExcelDatabaseManager.Instance.DataChanged += OnDataChanged;

            this.Load += (s, e) => LoadDashboardData();
            this.Resize += (s, e) => LayoutSummaryCards();
        }

        private void LayoutSummaryCards()
        {
            if (pnlCardsContainer == null) return;

            int gap = 12;
            int cardWidth = Math.Max(150, (pnlCardsContainer.ClientSize.Width - (gap * 3)) / 4);
            var cards = new[] { pnlCardTotal, pnlCardPassed, pnlCardCompletion, pnlCardRate };

            for (int index = 0; index < cards.Length; index++)
            {
                cards[index].Location = new Point(index * (cardWidth + gap), 0);
                cards[index].Size = new Size(cardWidth, pnlCardsContainer.ClientSize.Height - 5);
            }
        }

        private void ApplyVisualStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            pnlCardsContainer.BackColor = Color.Transparent;

            var cards = new[] { pnlCardTotal, pnlCardPassed, pnlCardCompletion, pnlCardRate };
            foreach (var card in cards)
            {
                card.BorderRadius = 12;
                card.BorderThickness = 1;
                card.ShadowDecoration.Enabled = true;
                card.ShadowDecoration.Depth = 8;
            }

            pnlCardTotal.FillColor = Color.FromArgb(255, 255, 255);
            pnlCardPassed.FillColor = Color.FromArgb(240, 253, 250);
            pnlCardCompletion.FillColor = Color.FromArgb(255, 251, 235);
            pnlCardRate.FillColor = Color.FromArgb(255, 255, 255);
            dgvDashboard.BorderStyle = BorderStyle.None;
            dgvDashboard.GridColor = Color.FromArgb(226, 232, 240);
        }

        private void SetupGridColumns()
        {
            dgvDashboard.AutoGenerateColumns = false;
            dgvDashboard.Columns.Clear();

            var colCourse = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CourseCode",
                HeaderText = "Course Code",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 140,
                ReadOnly = true
            };

            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalStudents",
                HeaderText = "Total Students",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colPassed = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Passed",
                HeaderText = "Total Passed",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(4, 120, 87), Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };

            var colCompletion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Completion",
                HeaderText = "Under Completion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 100,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(161, 98, 7), Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };

            var colRate = new DataGridViewTextBoxColumn
            {
                HeaderText = "Passing Rate",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            dgvDashboard.Columns.AddRange(colCourse, colTotal, colPassed, colCompletion, colRate);

            dgvDashboard.CellFormatting += (s, e) =>
            {
                if (e.CellStyle != null)
                {
                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                    e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == colRate.Index)
                {
                    if (dgvDashboard.Rows[e.RowIndex].DataBoundItem is ExcelDatabaseManager.CourseDashboardStat item)
                    {
                        e.Value = $"{item.PassingRate:0.0}%";
                        e.FormattingApplied = true;
                    }
                }
            };

            dgvDashboard.SelectionChanged += (s, e) => dgvDashboard.ClearSelection();
        }

        public void LoadDashboardData()
        {
            _allStats = ExcelDatabaseManager.Instance.GetCourseDashboardStats();

            int overallTotal = _allStats.Sum(s => s.TotalStudents);
            int overallPassed = _allStats.Sum(s => s.Passed);
            int overallCompletion = _allStats.Sum(s => s.Completion);
            double overallRate = overallTotal > 0 ? (double)overallPassed / overallTotal * 100.0 : 0.0;

            lblCardTotalValue.Text = overallTotal.ToString();
            lblCardPassedValue.Text = overallPassed.ToString();
            lblCardCompletionValue.Text = overallCompletion.ToString();
            lblCardRateValue.Text = $"{overallRate:0.0}%";

            ApplySearchFilter();
        }

        private void ApplySearchFilter()
        {
            string query = txtSearch.Text.Trim();
            var filtered = string.IsNullOrEmpty(query)
                ? _allStats
                : _allStats.Where(s => s.CourseCode.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            dgvDashboard.DataSource = null;
            dgvDashboard.DataSource = filtered;
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void OnDataChanged()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(LoadDashboardData));
            }
            else
            {
                LoadDashboardData();
            }
        }
    }
}
