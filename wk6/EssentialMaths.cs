using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGP
{
    public partial class EssentialMaths : Form
    {
        // Array of points representing a triangle in model space
        PointF[] triangle;

        // Current rotation angle (in radians)
        float angle = 0;

        // Timer used to animate rotation
        System.Windows.Forms.Timer timer;

        public EssentialMaths()
        {
            InitializeComponent();

            // Enable smooth rendering
            this.DoubleBuffered = true;

            // Set form properties
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Text = "Week 6 – Essential Maths";

            // Define triangle relative to origin (0,0)
            // This is model space (not screen space)
            triangle = new PointF[]
            {
                new PointF(0, -100),
                new PointF(-100, 100),
                new PointF(100, 100)
            };

            // Create animation timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;   // 30ms between frames
            timer.Tick += Rotate;  // Call Rotate() on each tick
            timer.Start();
        }

        // Called every timer tick to update rotation angle
        private void Rotate(object sender, EventArgs e)
        {
            // Increase rotation angle slightly
            angle += 0.05f;

            // Trigger redraw
            Invalidate();
        }

        // Handles drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Create array for transformed points
            PointF[] transformed = new PointF[triangle.Length];

            for (int i = 0; i < triangle.Length; i++)
            {
                // Apply rotation matrix to each point
                transformed[i] = RotatePoint(triangle[i], angle);

                // Translate triangle to centre of screen
                transformed[i].X += 300;
                transformed[i].Y += 300;
            }

            // Draw the rotated triangle
            g.DrawPolygon(Pens.Black, transformed);
        }

        // Applies 2D rotation matrix to a single point
        private PointF RotatePoint(PointF p, float theta)
        {
            // Compute sine and cosine once
            float cos = (float)Math.Cos(theta);
            float sin = (float)Math.Sin(theta);

            // Apply rotation matrix:
            float x = p.X * cos - p.Y * sin;
            float y = p.X * sin + p.Y * cos;

            return new PointF(x, y);
        }
    }
}
