using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGP
{
    public partial class Triangles : Form
    {
        public Triangles()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Text = "Recursive Triangles";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            // Starting triangle coordinates (given in the brief)
            Point p1 = new Point(100, 100);
            Point p2 = new Point(500, 100);
            Point p3 = new Point(300, 446);

            DrawTriangleRecursive(g, pen, p1, p2, p3);
        }

        private void DrawTriangleRecursive(Graphics g, Pen pen, Point a, Point b, Point c)
        {
            // Draw the current triangle
            g.DrawPolygon(pen, new Point[] { a, b, c });

            // Find midpoints of each side
            Point ab = MidPoint(a, b);
            Point bc = MidPoint(b, c);
            Point ca = MidPoint(c, a);

            // Stop recursion when triangle is smaller than 1 pixel
            if (Distance(ab, bc) < 1)
                return;

            // Recursive call using the midpoints
            DrawTriangleRecursive(g, pen, ab, bc, ca);
        }

        private Point MidPoint(Point p1, Point p2)
        {
            return new Point(
                (p1.X + p2.X) / 2,
                (p1.Y + p2.Y) / 2
            );
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(
                Math.Pow(p1.X - p2.X, 2) +
                Math.Pow(p1.Y - p2.Y, 2)
            );
        }
    }
}
