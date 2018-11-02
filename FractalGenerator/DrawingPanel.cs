using System;
using System.Drawing;
using System.Windows.Forms;

namespace FractalGenerator
{
    public partial class DrawingPanel : UserControl
    {
        bool mouseDown = false;
        Point mouseDownPoint = Point.Empty;
        Point mousePoint = Point.Empty;
        Bitmap bitmap;

        public DrawingPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;            
        }

        public Graphics GetGraphics()
        {
            this.bitmap = new Bitmap(this.Width, this.Height);
            var graphics = Graphics.FromImage(bitmap);
            return graphics;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (bitmap != null)
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }

            if (mouseDown)
            {
                Region r = new Region(this.ClientRectangle);
                Rectangle window = new Rectangle(
                    Math.Min(mouseDownPoint.X, mousePoint.X),
                    Math.Min(mouseDownPoint.Y, mousePoint.Y),
                    Math.Abs(mouseDownPoint.X - mousePoint.X),
                    Math.Abs(mouseDownPoint.Y - mousePoint.Y));                          
                Pen pen = new Pen(Color.Red, 1);
                e.Graphics.DrawRectangle(pen, window);
                pen.Dispose();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDown = true;
                mousePoint = mouseDownPoint = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mousePoint = e.Location;
            Invalidate();
        }

        public Point GetMouseDownPoint()
        {
            return mouseDownPoint;
        }

        public Point GetMouseUpPoint()
        {
            return mousePoint;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }
    }
}
