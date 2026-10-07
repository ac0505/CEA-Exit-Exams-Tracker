using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StudentGradeTracker
{
    /// <summary>
    /// Generates crisp, resolution-independent vector icons for UI buttons and input fields.
    /// Eliminates emojis and ensures clean, modern, minimalist styling.
    /// </summary>
    public static class IconHelper
    {
        public static Bitmap CreateSearchIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                float radius = size * 0.32f;
                float cx = size * 0.40f;
                float cy = size * 0.40f;
                g.DrawEllipse(pen, cx - radius, cy - radius, radius * 2, radius * 2);

                float handleStart = size * 0.63f;
                float handleEnd = size * 0.88f;
                g.DrawLine(pen, handleStart, handleStart, handleEnd, handleEnd);
            }
            return bmp;
        }

        public static Bitmap CreatePlusIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.8f, size / 8f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                float pad = size * 0.22f;
                float mid = size * 0.50f;
                g.DrawLine(pen, mid, pad, mid, size - pad);
                g.DrawLine(pen, pad, mid, size - pad, mid);
            }
            return bmp;
        }

        public static Bitmap CreateUploadIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                float midX = size * 0.5f;
                float topY = size * 0.22f;
                float botArrowY = size * 0.62f;
                float arrowHead = size * 0.24f;

                // Vertical shaft
                g.DrawLine(pen, midX, topY, midX, botArrowY);
                // Arrowhead
                g.DrawLine(pen, midX - arrowHead, topY + arrowHead, midX, topY);
                g.DrawLine(pen, midX + arrowHead, topY + arrowHead, midX, topY);

                // Tray base
                float trayY = size * 0.78f;
                float trayLeft = size * 0.22f;
                float trayRight = size * 0.78f;
                float trayLip = size * 0.14f;
                g.DrawLine(pen, trayLeft, trayY - trayLip, trayLeft, trayY);
                g.DrawLine(pen, trayLeft, trayY, trayRight, trayY);
                g.DrawLine(pen, trayRight, trayY, trayRight, trayY - trayLip);
            }
            return bmp;
        }

        public static Bitmap CreateFilterIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                // Funnel lines
                PointF[] points = {
                    new PointF(size * 0.18f, size * 0.24f),
                    new PointF(size * 0.82f, size * 0.24f),
                    new PointF(size * 0.58f, size * 0.54f),
                    new PointF(size * 0.58f, size * 0.82f),
                    new PointF(size * 0.42f, size * 0.74f),
                    new PointF(size * 0.42f, size * 0.54f)
                };
                g.DrawPolygon(pen, points);
            }
            return bmp;
        }

        public static Bitmap CreateCheckIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.8f, size / 8f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                g.DrawLines(pen, new[] {
                    new PointF(size * 0.22f, size * 0.52f),
                    new PointF(size * 0.44f, size * 0.74f),
                    new PointF(size * 0.80f, size * 0.28f)
                });
            }
            return bmp;
        }

        public static Bitmap CreateCloseIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 8f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                float pad = size * 0.26f;
                g.DrawLine(pen, pad, pad, size - pad, size - pad);
                g.DrawLine(pen, size - pad, pad, pad, size - pad);
            }
            return bmp;
        }

        public static Bitmap CreateResetIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                float pad = size * 0.20f;
                g.DrawArc(pen, pad, pad, size - (pad * 2), size - (pad * 2), 45, 270);
                // Arrow head at top
                float ax = size * 0.52f;
                float ay = pad;
                g.DrawLine(pen, ax, ay - size * 0.12f, ax + size * 0.14f, ay);
                g.DrawLine(pen, ax, ay + size * 0.12f, ax + size * 0.14f, ay);
            }
            return bmp;
        }

        public static Bitmap CreateEditIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                // Pencil body angled
                g.DrawLine(pen, size * 0.65f, size * 0.20f, size * 0.80f, size * 0.35f);
                g.DrawLine(pen, size * 0.26f, size * 0.59f, size * 0.65f, size * 0.20f);
                g.DrawLine(pen, size * 0.41f, size * 0.74f, size * 0.80f, size * 0.35f);
                g.DrawLine(pen, size * 0.20f, size * 0.80f, size * 0.26f, size * 0.59f);
                g.DrawLine(pen, size * 0.20f, size * 0.80f, size * 0.41f, size * 0.74f);
            }
            return bmp;
        }

        public static Bitmap CreateDeleteIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                // Lid
                g.DrawLine(pen, size * 0.22f, size * 0.30f, size * 0.78f, size * 0.30f);
                g.DrawLine(pen, size * 0.40f, size * 0.22f, size * 0.60f, size * 0.22f);
                // Body
                g.DrawLine(pen, size * 0.28f, size * 0.30f, size * 0.32f, size * 0.80f);
                g.DrawLine(pen, size * 0.32f, size * 0.80f, size * 0.68f, size * 0.80f);
                g.DrawLine(pen, size * 0.68f, size * 0.80f, size * 0.72f, size * 0.30f);
                // Inner ribs
                g.DrawLine(pen, size * 0.43f, size * 0.38f, size * 0.43f, size * 0.72f);
                g.DrawLine(pen, size * 0.57f, size * 0.38f, size * 0.57f, size * 0.72f);
            }
            return bmp;
        }

        public static Bitmap CreateChartIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var brush = new SolidBrush(color);
                using var pen = new Pen(color, Math.Max(1.4f, size / 10f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                // Coordinate lines
                g.DrawLine(pen, size * 0.18f, size * 0.18f, size * 0.18f, size * 0.82f);
                g.DrawLine(pen, size * 0.18f, size * 0.82f, size * 0.84f, size * 0.82f);

                // 3 bars
                float barW = size * 0.14f;
                g.FillRectangle(brush, size * 0.28f, size * 0.52f, barW, size * 0.28f);
                g.FillRectangle(brush, size * 0.48f, size * 0.32f, barW, size * 0.48f);
                g.FillRectangle(brush, size * 0.68f, size * 0.42f, barW, size * 0.38f);
            }
            return bmp;
        }

        public static Bitmap CreatePieIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.6f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                using var brush = new SolidBrush(Color.FromArgb(140, color));

                float pad = size * 0.18f;
                float diam = size - (pad * 2);
                g.DrawEllipse(pen, pad, pad, diam, diam);
                g.FillPie(brush, pad, pad, diam, diam, 210, 100);
            }
            return bmp;
        }

        public static Bitmap CreateDashboardIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.5f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                float pad = size * 0.16f;
                float half = size * 0.46f;
                float w = half - pad;
                g.DrawRectangle(pen, pad, pad, w, w);
                g.DrawRectangle(pen, size - pad - w, pad, w, w);
                g.DrawRectangle(pen, pad, size - pad - w, w, w);
                g.DrawRectangle(pen, size - pad - w, size - pad - w, w, w);
            }
            return bmp;
        }

        public static Bitmap CreateStudentsIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.5f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                float cx = size * 0.5f;
                float headR = size * 0.18f;
                g.DrawEllipse(pen, cx - headR, size * 0.18f, headR * 2, headR * 2);

                // Shoulders arc
                g.DrawArc(pen, size * 0.20f, size * 0.56f, size * 0.60f, size * 0.38f, 180, 180);
            }
            return bmp;
        }

        public static Bitmap CreateExamsIcon(int size, Color color)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var pen = new Pen(color, Math.Max(1.5f, size / 9f)) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };

                float left = size * 0.24f;
                float right = size * 0.76f;
                float top = size * 0.20f;
                float bot = size * 0.82f;
                g.DrawRectangle(pen, left, top, right - left, bot - top);

                // Document lines
                g.DrawLine(pen, size * 0.36f, size * 0.40f, size * 0.64f, size * 0.40f);
                g.DrawLine(pen, size * 0.36f, size * 0.54f, size * 0.64f, size * 0.54f);
                g.DrawLine(pen, size * 0.36f, size * 0.68f, size * 0.54f, size * 0.68f);
            }
            return bmp;
        }
    }
}
