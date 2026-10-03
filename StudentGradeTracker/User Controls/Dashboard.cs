using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.Charts.WinForms;

namespace StudentGradeTracker.User_Controls
{
    public partial class Dashboard : UserControl
    {
        private List<ExcelDatabaseManager.CourseDashboardStat> _allStats = new List<ExcelDatabaseManager.CourseDashboardStat>();
        private bool _isStatusChartMode = true;
        private int _totalStudents = 0;
        private int _totalPassed = 0;
        private int _totalCompletion = 0;
        private double _overallRate = 0.0;

        public Dashboard()
        {
            InitializeComponent();
            SetupGridColumns();
            ApplyVisualStyle();
            WireEvents();

            ExcelDatabaseManager.Instance.DataChanged += OnDataChanged;

            this.Load += (s, e) =>
            {
                LayoutDashboard();
                LoadDashboardData();
            };
            this.Resize += (s, e) => LayoutDashboard();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => ApplySearchFilter();

            btnChartStatus.Click += (s, e) =>
            {
                if (_isStatusChartMode) return;
                _isStatusChartMode = true;
                UpdateChartToggleButtons();
                RenderCurrentChart();
            };

            btnChartCourse.Click += (s, e) =>
            {
                if (!_isStatusChartMode) return;
                _isStatusChartMode = false;
                UpdateChartToggleButtons();
                RenderCurrentChart();
            };
        }

        private void ApplyVisualStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            pnlCardsContainer.BackColor = Color.Transparent;
            pnlCardsContainer.Height = 80;

            // Search box styling
            txtSearch.IconLeft = IconHelper.CreateSearchIcon(14, Color.FromArgb(148, 163, 184));
            txtSearch.IconLeftSize = new Size(14, 14);
            txtSearch.IconLeftOffset = new Point(8, 0);

            // Chart toggle buttons with vector icons and clean spacing
            btnChartStatus.Size = new Size(95, 28);
            btnChartStatus.Image = IconHelper.CreatePieIcon(14, Color.White);
            btnChartStatus.ImageSize = new Size(14, 14);
            btnChartStatus.ImageAlign = HorizontalAlignment.Left;
            btnChartStatus.TextAlign = HorizontalAlignment.Left;
            btnChartStatus.ImageOffset = new Point(8, 0);
            btnChartStatus.TextOffset = new Point(10, 0);

            btnChartCourse.Size = new Size(95, 28);
            btnChartCourse.Image = IconHelper.CreateChartIcon(14, Color.FromArgb(71, 85, 105));
            btnChartCourse.ImageSize = new Size(14, 14);
            btnChartCourse.ImageAlign = HorizontalAlignment.Left;
            btnChartCourse.TextAlign = HorizontalAlignment.Left;
            btnChartCourse.ImageOffset = new Point(8, 0);
            btnChartCourse.TextOffset = new Point(10, 0);

            // Subtle card shadows
            pnlChartCard.ShadowDecoration.Enabled = true;
            pnlChartCard.ShadowDecoration.Depth = 6;
            pnlChartCard.ShadowDecoration.Color = Color.FromArgb(20, 0, 0, 0);

            pnlTableCard.ShadowDecoration.Enabled = true;
            pnlTableCard.ShadowDecoration.Depth = 6;
            pnlTableCard.ShadowDecoration.Color = Color.FromArgb(20, 0, 0, 0);

            // Responsive chart animation and sleek tooltip styling
            gunaChart.Animation.Duration = 150;
            gunaChart.Animation.Easing = Easing.EaseOutQuad;

            gunaChart.Tooltips.CornerRadius = 6;
            gunaChart.Tooltips.BackgroundColor = Color.FromArgb(230, 39, 39, 39);
            gunaChart.Tooltips.TitleFont.Name = "Segoe UI";
            gunaChart.Tooltips.TitleFont.Size = 9;
            gunaChart.Tooltips.BodyFont.Name = "Segoe UI";
            gunaChart.Tooltips.BodyFont.Size = 8;
            gunaChart.Tooltips.TitleForeColor = Color.White;
            gunaChart.Tooltips.BodyForeColor = Color.White;
            gunaChart.Tooltips.BorderWidth = 0;

            // Enable double buffering on chart container to prevent repaint flicker
            try
            {
                var dblProp = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                dblProp?.SetValue(gunaChart, true);
                dblProp?.SetValue(pnlChartCard, true);
            }
            catch { }
        }

        private void LayoutDashboard()
        {
            if (pnlCardsContainer == null || pnlChartCard == null || pnlTableCard == null) return;

            const int margin = 20;
            const int gap = 14;
            int totalWidth = ClientSize.Width - (margin * 2);

            // 1. Layout Top 4 Metric Cards
            int cardGap = 12;
            int cardW = Math.Max(160, (totalWidth - (cardGap * 3)) / 4);
            var cards = new[] { pnlCardTotal, pnlCardPassed, pnlCardCompletion, pnlCardRate };
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Location = new Point(i * (cardW + cardGap), 0);
                cards[i].Size = new Size(i == cards.Length - 1 ? totalWidth - (i * (cardW + cardGap)) : cardW, pnlCardsContainer.Height);
            }

            // 2. Split Main Content Row
            int topH = pnlCardsContainer.Bottom;
            int contentTop = topH + 12;
            int contentH = Math.Max(300, ClientSize.Height - contentTop - 18);

            int chartWidth = Math.Max(360, (int)(totalWidth * 0.43));
            int tableWidth = Math.Max(380, totalWidth - chartWidth - gap);

            pnlChartCard.Location = new Point(margin, contentTop);
            pnlChartCard.Size = new Size(chartWidth, contentH);

            pnlTableCard.Location = new Point(margin + chartWidth + gap, contentTop);
            pnlTableCard.Size = new Size(tableWidth, contentH);

            btnChartCourse.Location = new Point(pnlChartCard.Width - 105, 10);
            btnChartStatus.Location = new Point(btnChartCourse.Left - 100, 10);

            pnlChartFooter.Location = new Point(12, pnlChartCard.Height - 34);
            pnlChartFooter.Width = pnlChartCard.Width - 24;
            gunaChart.Location = new Point(12, 44);
            gunaChart.Size = new Size(pnlChartCard.Width - 24, Math.Max(120, pnlChartFooter.Top - gunaChart.Top - 6));

            dgvDashboard.Location = new Point(12, 46);
            dgvDashboard.Size = new Size(pnlTableCard.Width - 24, Math.Max(120, pnlTableCard.Height - 56));
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
                FillWeight = 130,
                ReadOnly = true,
                DefaultCellStyle = { Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(39, 39, 39) }
            };

            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalStudents",
                HeaderText = "Total",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 75,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colPassed = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Passed",
                HeaderText = "Passed",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 85,
                ReadOnly = true,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(5, 150, 105),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            };

            var colCompletion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Completion",
                HeaderText = "Completion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 95,
                ReadOnly = true,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(217, 119, 6),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            };

            var colRate = new DataGridViewTextBoxColumn
            {
                HeaderText = "Pass Rate",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 95,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            dgvDashboard.Columns.AddRange(colCourse, colTotal, colPassed, colCompletion, colRate);

            dgvDashboard.CellFormatting += (s, e) =>
            {
                if (e.CellStyle == null) return;
                e.CellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
                e.CellStyle.SelectionForeColor = Color.FromArgb(39, 39, 39);

                if (e.RowIndex >= 0 && e.ColumnIndex == colRate.Index)
                {
                    if (dgvDashboard.Rows[e.RowIndex].DataBoundItem is ExcelDatabaseManager.CourseDashboardStat item)
                    {
                        e.Value = $"{item.PassingRate:0.0}%";
                        e.FormattingApplied = true;

                        if (item.PassingRate >= 70.0)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                            e.CellStyle.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
                        }
                        else if (item.PassingRate >= 50.0)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                            e.CellStyle.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                            e.CellStyle.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
                        }
                    }
                }
            };

            dgvDashboard.SelectionChanged += (s, e) => dgvDashboard.ClearSelection();
        }

        public void LoadDashboardData()
        {
            _allStats = ExcelDatabaseManager.Instance.GetCourseDashboardStats();

            _totalStudents = _allStats.Sum(s => s.TotalStudents);
            _totalPassed = _allStats.Sum(s => s.Passed);
            _totalCompletion = _allStats.Sum(s => s.Completion);
            _overallRate = _totalStudents > 0 ? (double)_totalPassed / _totalStudents * 100.0 : 0.0;

            lblCardTotalValue.Text = _totalStudents.ToString();
            lblCardPassedValue.Text = _totalPassed.ToString();
            lblCardCompletionValue.Text = _totalCompletion.ToString();
            lblCardRateValue.Text = $"{_overallRate:0.0}%";

            lblTableCountBadge.Text = $"{_allStats.Count} Courses";

            // Footer labels on chart
            double passedPct = _totalStudents > 0 ? (double)_totalPassed / _totalStudents * 100.0 : 0.0;
            double completionPct = _totalStudents > 0 ? (double)_totalCompletion / _totalStudents * 100.0 : 0.0;
            lblChartFooterLeft.Text = $"Passed: {_totalPassed} ({passedPct:0.0}%)";
            lblChartFooterRight.Text = $"Completion: {_totalCompletion} ({completionPct:0.0}%)";

            RenderCurrentChart();
            ApplySearchFilter();
        }

        private void UpdateChartToggleButtons()
        {
            if (_isStatusChartMode)
            {
                btnChartStatus.FillColor = Color.FromArgb(39, 39, 39);
                btnChartStatus.ForeColor = Color.White;
                btnChartStatus.BorderThickness = 0;
                btnChartStatus.Image = IconHelper.CreatePieIcon(14, Color.White);

                btnChartCourse.FillColor = Color.White;
                btnChartCourse.ForeColor = Color.FromArgb(71, 85, 105);
                btnChartCourse.BorderThickness = 1;
                btnChartCourse.BorderColor = Color.FromArgb(203, 213, 225);
                btnChartCourse.Image = IconHelper.CreateChartIcon(14, Color.FromArgb(71, 85, 105));
            }
            else
            {
                btnChartCourse.FillColor = Color.FromArgb(39, 39, 39);
                btnChartCourse.ForeColor = Color.White;
                btnChartCourse.BorderThickness = 0;
                btnChartCourse.Image = IconHelper.CreateChartIcon(14, Color.White);

                btnChartStatus.FillColor = Color.White;
                btnChartStatus.ForeColor = Color.FromArgb(71, 85, 105);
                btnChartStatus.BorderThickness = 1;
                btnChartStatus.BorderColor = Color.FromArgb(203, 213, 225);
                btnChartStatus.Image = IconHelper.CreatePieIcon(14, Color.FromArgb(71, 85, 105));
            }
        }

        private void RenderCurrentChart()
        {
            gunaChart.Datasets.Clear();

            if (_isStatusChartMode)
            {
                RenderStatusDoughnutChart();
            }
            else
            {
                RenderCourseBarChart();
            }

            gunaChart.Update();
        }

        private void RenderStatusDoughnutChart()
        {
            gunaChart.Title.Text = "Examinee Overall Status";
            gunaChart.Legend.Position = LegendPosition.Bottom;

            // Fast, responsive animation so hover indications pop up instantly without lag
            gunaChart.Animation.Duration = 150;
            gunaChart.Animation.Easing = Easing.EaseOutQuad;

            // Completely remove the graph lines and axes for pie/doughnut chart section
            gunaChart.XAxes.Display = false;
            gunaChart.YAxes.Display = false;

            var doughnut = new GunaDoughnutDataset
            {
                Label = "Examinee Status",
                BorderWidth = 2
            };

            // Mapúa Blue for Passed, Mapúa Red for Completion with clean white separation border
            doughnut.FillColors.Add(Color.FromArgb(0, 36, 85));
            doughnut.FillColors.Add(Color.FromArgb(160, 1, 0));
            doughnut.BorderColors.Add(Color.White);
            doughnut.BorderColors.Add(Color.White);

            doughnut.DataPoints.Add("Passed", _totalPassed);
            doughnut.DataPoints.Add("Completion", _totalCompletion);

            gunaChart.Datasets.Add(doughnut);
        }

        private void RenderCourseBarChart()
        {
            gunaChart.Title.Text = "Passing Rate (%) by Course";
            gunaChart.Legend.Position = LegendPosition.Bottom;

            gunaChart.Animation.Duration = 300;
            gunaChart.Animation.Easing = Easing.EaseOutQuad;

            // Retain graph lines and axes for progress bar / bar chart section
            gunaChart.XAxes.Display = true;
            gunaChart.YAxes.Display = true;
            gunaChart.XAxes.GridLines.Display = false;
            gunaChart.YAxes.GridLines.Display = true;

            var barDataset = new GunaBarDataset
            {
                Label = "Passing Rate (%)"
            };

            var topCourses = _allStats.Take(8).ToList();
            foreach (var stat in topCourses)
            {
                barDataset.DataPoints.Add(stat.CourseCode, Math.Round(stat.PassingRate, 1));
                if (stat.PassingRate >= 70)
                    barDataset.FillColors.Add(Color.FromArgb(16, 185, 129)); // emerald
                else if (stat.PassingRate >= 50)
                    barDataset.FillColors.Add(Color.FromArgb(37, 99, 235)); // royal blue
                else
                    barDataset.FillColors.Add(Color.FromArgb(245, 158, 11)); // amber
            }

            gunaChart.Datasets.Add(barDataset);
        }

        private void ApplySearchFilter()
        {
            string query = txtSearch.Text.Trim();
            var filtered = string.IsNullOrEmpty(query)
                ? _allStats
                : _allStats.Where(s => s.CourseCode.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            lblTableCountBadge.Text = $"{filtered.Count} Courses";
            dgvDashboard.DataSource = null;
            dgvDashboard.DataSource = filtered;
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

