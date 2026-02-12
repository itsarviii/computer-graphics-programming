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

            this.DoubleBuffered = true;
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.White;
            this.Text = "Week 5 – Geometical Shapes";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int centerX = 300;
            int centerY = 300;
            int radius = 150;

            DrawCircle(g, centerX, centerY, radius);
        }

        private void DrawCircle(Graphics g, int xc, int yc, int r)
        {
            int x = 0;
            int y = r;
            int d = 3 - 2 * r;

            while (x <= y)
            {
                PlotCirclePoints(g, xc, yc, x, y);

                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }

                x++;
            }
        }

        private void PlotCirclePoints(Graphics g, int xc, int yc, int x, int y)
        {
            Brush brush = Brushes.Black;

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
