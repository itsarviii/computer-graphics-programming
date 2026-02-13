using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CGP
{
    public partial class SimpleTransformations : Form
    {
        public SimpleTransformations()
        {
            InitializeComponent();

            // Redraw form automatically when resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // Place form at top-left of screen (world origin reference)
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            // Set form size and background
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
            this.Text = "Week 7 – Simple Transformations";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Create pen for drawing outlines
            Pen blackPen = new Pen(Color.Black);

            // Font and brush for labels
            Font myFont = new Font("Helvetica", 9);
            Brush blackwriter = new SolidBrush(Color.Black);

            // 1️⃣ Original Rectangle (No Transformation)

            Rectangle rect = new Rectangle(250, 50, 50, 100);
            g.DrawRectangle(blackPen, rect);
            g.DrawString("1st pos", myFont, blackwriter, rect.Left, rect.Bottom);

            // Calculate centre of rectangle
            // This will be used for rotation about its own centre
            PointF center = new PointF(
                rect.X + (rect.Width / 2.0F),
                rect.Y + (rect.Height / 2.0F)
            );

            // Create transformation matrix
            Matrix myMatrix = new Matrix();

            // 2️⃣ Rotation Around World Origin (0,0)

            // Rotate 30 degrees clockwise around (0,0)
            myMatrix.Rotate(30);

            // Apply transformation to Graphics object
            g.Transform = myMatrix;

            // Draw rotated rectangle
            g.DrawRectangle(blackPen, rect);
            g.DrawString("2nd pos", myFont, blackwriter, rect.Right, rect.Bottom);


            // 3️⃣ Rotation Around Rectangle Centre

            // Compute where the centre moved after first rotation
            PointF newcenter = RotatePoint(30, center);

            // Rotate again 30 degrees, but around the new centre
            // MatrixOrder.Append applies transformation after previous one
            myMatrix.RotateAt(30, newcenter, MatrixOrder.Append);

            g.Transform = myMatrix;

            g.DrawRectangle(blackPen, rect);
            g.DrawString("3rd pos", myFont, blackwriter, rect.Right, rect.Top);


            // 4️⃣ Translation Transformation


            // Reset matrix (clear previous rotations)
            myMatrix.Reset();

            // Translate 100 pixels right
            myMatrix.Translate(100.0F, 0.0F);

            g.Transform = myMatrix;

            g.DrawRectangle(blackPen, rect);
            g.DrawString("4th pos", myFont, blackwriter, rect.Left, rect.Bottom);
        }


        // Manual Rotation Formula (Used to track new centre)
        public PointF RotatePoint(float angle, PointF pt)
        {
            // Convert angle from degrees to radians
            float cosa = (float)Math.Cos(angle * Math.PI / 180.0);
            float sina = (float)Math.Sin(angle * Math.PI / 180.0);

            // Apply 2D rotation matrix:
            float X = pt.X * cosa - pt.Y * sina;
            float Y = pt.X * sina + pt.Y * cosa;

            return new PointF(X, Y);
        }
    }
}
