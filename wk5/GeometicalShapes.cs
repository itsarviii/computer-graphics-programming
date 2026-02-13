using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGP
{
    public partial class GeometicalShapes : Form
    {
        public GeometicalShapes()
        {
            InitializeComponent();

            // Enable double buffering for smoother rendering
            this.DoubleBuffered = true;

            // Set form properties
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Text = "Week 5 – Geometical Shapes";
        }

        // Called whenever the form needs to be redrawn
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Define circle centre and radius
            int centerX = 300;
            int centerY = 300;
            int radius = 150;

            // Draw circle using Bresenham algorithm
            DrawCircle(g, centerX, centerY, radius);
        }

        // Implements Bresenham's (Midpoint) Circle Algorithm
        private void DrawCircle(Graphics g, int xc, int yc, int r)
        {
            // Start at top of circle
            int x = 0;
            int y = r;

            // Decision parameter
            int d = 3 - 2 * r;

            // Continue while x is less than or equal to y
            // (only calculate one octant due to symmetry)
            while (x <= y)
            {
                // Plot the 8 symmetrical points
                PlotCirclePoints(g, xc, yc, x, y);

                if (d < 0)
                {
                    // Choose East pixel
                    d = d + 4 * x + 6;
                }
                else
                {
                    // Choose South-East pixel
                    d = d + 4 * (x - y) + 10;
                    y--;
                }

                x++;
            }
        }

        // Plots the 8 symmetric points of the circle
        private void PlotCirclePoints(Graphics g, int xc, int yc, int x, int y)
        {
            Brush brush = Brushes.Black;

            // Each point is mirrored across axes
            g.FillRectangle(brush, xc + x, yc + y, 1, 1);
            g.FillRectangle(brush, xc - x, yc + y, 1, 1);
            g.FillRectangle(brush, xc + x, yc - y, 1, 1);
            g.FillRectangle(brush, xc - x, yc - y, 1, 1);
            g.FillRectangle(brush, xc + y, yc + x, 1, 1);
            g.FillRectangle(brush, xc - y, yc + x, 1, 1);
            g.FillRectangle(brush, xc + y, yc - x, 1, 1);
            g.FillRectangle(brush, xc - y, yc - x, 1, 1);
        }
    }
}
