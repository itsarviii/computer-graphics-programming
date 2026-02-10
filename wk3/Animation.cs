using System;
using System.Drawing;
using System.Windows.Forms;


namespace CGP
{
    public partial class Animation : Form
    {
        // Position of the circle
        int x = 50;
        int y = 50;

        // Movement speed
        int dx = 4;
        int dy = 4;

        // Size of the circle
        int radius = 40;

        System.Windows.Forms.Timer timer;

        public Animation()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Text = "Week 3 – Animation";

            // Create and start timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // milliseconds
            timer.Tick += new EventHandler(UpdateAnimation);
            timer.Start();
        }

        private void UpdateAnimation(object sender, EventArgs e)
        {
            // Update position
            x += dx;
            y += dy;

            // Bounce off edges
            if (x < 0 || x + radius > this.ClientSize.Width)
                dx = -dx;

            if (y < 0 || y + radius > this.ClientSize.Height)
                dy = -dy;

            // Trigger repaint
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.LightBlue);

            // Draw animated circle
            g.FillEllipse(brush, x, y, radius, radius);
            g.DrawEllipse(pen, x, y, radius, radius);
        }
    }
}
