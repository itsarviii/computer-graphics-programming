using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGP
{
    public partial class DoubleBuffering : Form
    {
        int x = 50;
        int y = 50;

        int dx = 5;
        int dy = 5;

        int size = 40;

        System.Windows.Forms.Timer timer;

        public DoubleBuffering()
        {
            InitializeComponent();

            // Enable double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Text = "Week 4 – Double Buffering";

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            timer.Tick += UpdateAnimation;
            timer.Start();
        }

        private void UpdateAnimation(object sender, EventArgs e)
        {
            x += dx;
            y += dy;

            if (x < 0 || x + size > ClientSize.Width)
                dx = -dx;

            if (y < 0 || y + size > ClientSize.Height)
                dy = -dy;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.LightGreen);
            Pen pen = new Pen(Color.Black);

            g.FillEllipse(brush, x, y, size, size);
            g.DrawEllipse(pen, x, y, size, size);
        }
    }
}
