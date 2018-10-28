using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using FractalGenerator.Julia;
using FractalGenerator.MultiJulia;
using FractalGenerator.Mandelbrot;
using System.Drawing.Imaging;

namespace FractalGenerator
{
    public delegate void PixelCalculatedCallback(int x, int y, Color color);
    public delegate void DrawingPanelCallback();

    public partial class MainWindow : Form
    {
        private IList<IFractal> fractals = new List<IFractal>();
        private IFractal selectedFractal;
        private Thread fractalThread;
        private Graphics graphics;

        private bool selectionChanged;
        private Point mouseDownPoint;
        private Point mouseUpPoint;

        public MainWindow()
        {
            InitializeComponent();    
            this.fractals.Add(new MandelbrotFractal(OnPixelCalculated, OnUpdateDrawingPanel));
            this.fractals.Add(new JuliaFractal(OnPixelCalculated, OnUpdateDrawingPanel));
            this.fractals.Add(new MultiJuliaFractal(OnPixelCalculated, OnUpdateDrawingPanel));
            this.cbxFractals.DataSource = this.fractals;
            this.cbxFractals.DisplayMember = "FractalDisplayName";
        }

        private void OnPixelCalculated(int x, int y, Color color)
        {
            Brush brush = new SolidBrush(color);            
            graphics.FillRectangle(brush, x, y, 1, 1);
        }

        private void OnUpdateDrawingPanel()
        {
            this.drawingPanel.Invalidate();
        }

        private void btnStartClick(object sender, EventArgs e)
        {
            StartFractalGeneration();
        }

        private void StartFractalGeneration()
        {
            graphics = this.drawingPanel.GetGraphics();            
            fractalThread?.Abort();            
            selectedFractal.SetResolution(this.drawingPanel.Height, this.drawingPanel.Width);
            if (selectionChanged)
            {
                selectedFractal.SetSelectionToZoomIn(mouseDownPoint.X, mouseDownPoint.Y, mouseUpPoint.X, mouseUpPoint.Y);
                selectionChanged = false;
            }
            fractalThread = new Thread(new ThreadStart(selectedFractal.GenerateFractal));
            fractalThread.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fractalThread?.Abort();
        }

        private void cbxFractals_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFractal = (IFractal)this.cbxFractals.SelectedItem;

            if (selectedFractal != null)
            {                
                this.gbxParameters.SuspendLayout();
                this.gbxParameters.Controls.Remove(this.paramsControl);
                this.paramsControl = selectedFractal.GetParametersControl();                
                this.paramsControl.Dock = System.Windows.Forms.DockStyle.Fill;
                this.gbxParameters.Controls.Add(this.paramsControl);
                this.gbxParameters.ResumeLayout();
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.selectedFractal.SupportsZoom)
            {    
                mouseDownPoint = this.drawingPanel.GetMouseDownPoint();
                mouseUpPoint = this.drawingPanel.GetMouseUpPoint();
                selectionChanged = true;
                StartFractalGeneration();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            var bitmap = drawingPanel.GetBitmap();
            if (bitmap == null)
            {
                MessageBox.Show("No image to save yet.", "Error");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg";
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var format = ImageFormat.Bmp;
                switch (dialog.FilterIndex)
                {
                    case 1:
                        format = ImageFormat.Bmp;
                        break;
                    case 2:
                        format = ImageFormat.Jpeg;
                        break;                    
                }
                bitmap.Save(dialog.FileName, format);
            }
        }
    }
}


// TODO       
// refaktoryzacja

// zoom out
// kolorowania rózne metody do wyboru            
// liczenie na kilku wątkach            
// var test = Environment.ProcessorCount;
// hilber, trojkat siempinskiego
