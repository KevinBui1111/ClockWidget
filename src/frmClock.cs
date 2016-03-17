using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ClockWidget.Properties;
using Win32APIHelper;

namespace ClockWidget
{
    public partial class frmClock : Form
    {
        Bitmap photo = null;
        bool showSecond = true;
        byte opacity = 255;
        Color mainColor = Color.FromArgb(0, 168, 255);

        public frmClock()
        {
            InitializeComponent();
        }

        private void frmClock_Load(object sender, EventArgs e)
        {
            int oldExStyle = Win32API.GetWindowLong(Handle, Win32API.GWL_EXSTYLE);
            Win32API.SetWindowLong(Handle, Win32API.GWL_EXSTYLE, oldExStyle | Win32API.WS_EX_LAYERED);

            this.Location = new Point(Settings.Default.left, Settings.Default.top);
            this.Size = new Size(Settings.Default.width, Settings.Default.height);
        }
        private void frmClock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.left = this.Left;
            Settings.Default.top = this.Top;
            Settings.Default.width = this.Width;
            Settings.Default.height = this.Height;

            Settings.Default.Save();
        }
        private void frmClock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32API.ReleaseCapture();
                Win32API.SendMessage(this.Handle, Win32API.WM_NCLBUTTONDOWN, Win32API.HT_CAPTION, 0);
            }
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            DrawClock();
        }
        private void mnOpacity_Click(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            opacity = (byte)(255 * byte.Parse(m.Text.Substring(0, 3)) / 100);

            Win32API.SetBitmap(this, photo, opacity);
        }
        private void mnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnSecond_Click(object sender, EventArgs e)
        {
            showSecond = !showSecond;
            mnSecond.Checked = showSecond;
        }

        private void DrawClock()
        {
            Size region = this.Size;
            photo = new Bitmap(region.Width, region.Height, PixelFormat.Format32bppArgb);

            //Graphics g = e.Graphics;
            Graphics g = Graphics.FromImage(photo);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Translate to center the drawing.
            g.TranslateTransform(region.Width / 2, region.Height / 2);
            g.ScaleTransform(region.Width / 240f, region.Height / 240f);

            DrawClockFace(g);
            DrawClockHands(g);
            DrawCenterDot(g);

            g.Dispose();

            Win32API.SetBitmap(this, photo, opacity);
        }
        private void DrawClockFace(Graphics gr)
        {
            int width = 240 - 20;
            int height = 240 - 20;
            
            using (Pen thick_pen = new Pen(mainColor, 10))
            using (Pen med_pen = new Pen(mainColor, 7))
            using (Pen thin_pen = new Pen(mainColor, 1))
            using (Pen glow_pen = new Pen(Color.FromArgb(60, Color.Black), 12))
            using (Pen glow_pen2 = new Pen(Color.FromArgb(30, Color.Black), 16))
            {
                med_pen.StartCap = thick_pen.StartCap = LineCap.Round;

                // Shadow effect
                gr.DrawEllipse(glow_pen2, -width / 2, -height / 2, width, height);
                gr.DrawEllipse(glow_pen, -width / 2, -height / 2, width, height);
                // Outline.
                gr.FillEllipse(new SolidBrush(Color.Azure), -width / 2, -height / 2, width, height);
                // Fill face
                gr.DrawEllipse(thick_pen, -width / 2, -height / 2, width, height);

                // Get scale factors.
                float outer_x_factor = 0.5f * width;
                float outer_y_factor = 0.5f * height;
                float inner_x_factor = 0.45f * width;
                float inner_y_factor = 0.45f * height;
                float big_x_factor = 0.43f * width;
                float big_y_factor = 0.43f * height;

                // Draw the tick marks.
                for (int minute = 1; minute <= 60; minute++)
                {
                    double angle = Math.PI * minute / 30.0;
                    float cos_angle = (float)Math.Cos(angle);
                    float sin_angle = (float)Math.Sin(angle);
                    PointF outer_pt = new PointF(outer_x_factor * cos_angle, outer_y_factor * sin_angle);
                    if (minute % 15 == 0)
                    {
                        PointF inner_pt = new PointF(big_x_factor * cos_angle, big_y_factor * sin_angle);
                        gr.DrawLine(thick_pen, inner_pt, outer_pt);
                    }
                    if (minute % 5 == 0)
                    {
                        PointF inner_pt = new PointF(inner_x_factor * cos_angle, inner_x_factor * sin_angle);
                        gr.DrawLine(med_pen, inner_pt, outer_pt);
                    }
                    else
                    {
                        PointF inner_pt = new PointF(inner_x_factor * cos_angle, inner_y_factor * sin_angle);
                        gr.DrawLine(thin_pen, inner_pt, outer_pt);
                    }
                }
            }
        }
        private void DrawClockHands(Graphics gr)
        {
            using (Pen thick_pen = new Pen(mainColor))
            using (Pen shadow_pen = new Pen(Color.FromArgb(30, Color.Black)))
            {
                shadow_pen.StartCap = shadow_pen.EndCap = thick_pen.StartCap = thick_pen.EndCap = LineCap.Round;

                // Get the hour and minute plus any fraction that has elapsed.
                DateTime date = new DateTime(1, 1, 1, 10, 9, 31);
                date = DateTime.Now;
                float hour = date.Hour + date.Minute / 60f + date.Second / 3600f;
                float minute = date.Minute + date.Second / 60f;
                float second = date.Second;

                // Draw the hour hand.
                thick_pen.Width = 10;
                shadow_pen.Width = thick_pen.Width + 2;
                float hour_angle = hour * 30;
                Matrix old_trans = gr.Transform;
                gr.RotateTransform(hour_angle);
                gr.DrawLine(shadow_pen, 0, 20, 0, -50);
                gr.DrawLine(thick_pen, 0, 20, 0, -50);
                gr.Transform = old_trans;

                // Draw the minute hand.
                thick_pen.Width = 7;
                shadow_pen.Width = thick_pen.Width + 2;
                float minute_angle = minute * 6;
                gr.RotateTransform(minute_angle);
                gr.DrawLine(shadow_pen, 0, 20, 0, -85);
                gr.DrawLine(thick_pen, 0, 20, 0, -85);
                gr.Transform = old_trans;

                if (showSecond)
                {
                    // Draw the second hand.
                    thick_pen.Width = 3;
                    shadow_pen.Width = thick_pen.Width + 2;
                    thick_pen.Color = Color.Red;
                    float second_angle = second * 6;
                    gr.RotateTransform(second_angle);
                    gr.DrawLine(shadow_pen, 0, 20, 0, -95);
                    gr.DrawLine(thick_pen, 0, 20, 0, -95);
                    gr.Transform = old_trans;
                }
            }
        }
        private void DrawCenterDot(Graphics gr)
        {
            gr.DrawEllipse(new Pen(Color.FromArgb(50, Color.Black), 7), -5, -5, 10, 10);
            gr.DrawEllipse(new Pen(Color.White, 3), -5, -5, 10, 10);
            gr.FillEllipse(Brushes.Red, -4, -4, 8, 8);
        }

    }
}
