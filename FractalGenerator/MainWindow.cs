using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

using FractalGenerator.Visualisators;
using FractalGenerator.Fractals;

namespace FractalGenerator
{
    public delegate void PixelCalculatedCallback(int x, int y, Color color);
    public delegate void DrawingPanelCallback();

    public partial class MainWindow : Form
    {
        private IList<IFractal> fractals = new List<IFractal>();
        private IList<IVisualizator> visualizators = new List<IVisualizator>();
        private IFractal selectedFractal;
        private IVisualizator selectedVisualizator;
        private Thread fractalThread;
        private Graphics graphics;

        private bool selectionChanged;
        private bool zoomOut;
        private Point mouseDownPoint;
        private Point mouseUpPoint;
        private object lockObject = new object();

        public MainWindow()
        {
            InitializeComponent();    
            this.fractals.Add(new MandelbrotFractal());
            this.fractals.Add(new JuliaFractal());
            this.fractals.Add(new MultiJuliaFractal());            
            this.fractals.Add(new FractalV1());
            this.fractals.Add(new FractalV2());
            this.fractals.Add(new FractalV3());
            this.fractals.Add(new MagnetFractal2());
            this.fractals.Add(new MagnetFractal3());
            this.visualizators.Add(new TwoColorsVisualizator(OnPixelCalculated, OnUpdateDrawingPanel));
            this.visualizators.Add(new BlackAndWhiteVisualizator(OnPixelCalculated, OnUpdateDrawingPanel));
            this.visualizators.Add(new TwoColorsWithReturnVisualizator(OnPixelCalculated, OnUpdateDrawingPanel));
            this.visualizators.Add(new HistogramVisualizator(OnPixelCalculated, OnUpdateDrawingPanel));
            this.visualizators.Add(new SmoothVisualizator(OnPixelCalculated, OnUpdateDrawingPanel));
            this.cbxFractals.DataSource = this.fractals;
            this.cbxFractals.DisplayMember = "FractalDisplayName";
            this.cbxVisualizators.DataSource = this.visualizators;
            this.cbxVisualizators.DisplayMember = "VisualizatorDisplayName";
        }

        private void OnPixelCalculated(int x, int y, Color color)
        {
            Brush brush = new SolidBrush(color);
            lock (lockObject)
            {
                graphics.FillRectangle(brush, x, y, 1, 1);
            }
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
            selectedFractal.CancelGeneration();
            fractalThread?.Abort();            
            selectedFractal.SetImageResolution(this.drawingPanel.Height, this.drawingPanel.Width);
            selectedVisualizator.SetImageResolution(this.drawingPanel.Height, this.drawingPanel.Width);
            selectedFractal.Visualizator = selectedVisualizator;

            if (selectionChanged)
            {
                var startX = mouseDownPoint.X;
                var endX = mouseUpPoint.X;
                var startY = mouseDownPoint.Y;
                var endY = mouseUpPoint.Y;
                if (mouseDownPoint.X > mouseUpPoint.X)
                {
                    startX = mouseUpPoint.X;
                    endX = mouseDownPoint.X;
                }

                if (mouseDownPoint.Y > mouseUpPoint.Y)
                {
                    startY = mouseUpPoint.Y;
                    endY = mouseDownPoint.Y;
                }

                selectedFractal.SetSelectionToZoomIn(startX, startY, endX, endY);
                selectionChanged = false;
            }
            else if (zoomOut)
            {
                selectedFractal.SetSelectionToZoomIn(-this.drawingPanel.Width, -this.drawingPanel.Height, this.drawingPanel.Width+this.drawingPanel.Width, this.drawingPanel.Height+this.drawingPanel.Height);
                zoomOut = false;
            }

            fractalThread = new Thread(new ThreadStart(selectedFractal.GenerateFractal));
            fractalThread.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedFractal.CancelGeneration();
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
                this.paramsControl.Dock = DockStyle.Fill;
                this.gbxParameters.Controls.Add(this.paramsControl);
                this.gbxParameters.ResumeLayout();
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.selectedFractal.SupportsZoom && e.Button == System.Windows.Forms.MouseButtons.Left)
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

        private void cbxVisualizators_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedVisualizator = (IVisualizator)this.cbxVisualizators.SelectedItem;

            if (selectedVisualizator != null)
            {
                this.gbxVisualizatorParameters.SuspendLayout();
                this.gbxVisualizatorParameters.Controls.Remove(this.visualizatorParametersControl);
                this.visualizatorParametersControl = selectedVisualizator.GetParametersControl();
                this.visualizatorParametersControl.Dock = DockStyle.Fill;
                this.gbxVisualizatorParameters.Controls.Add(this.visualizatorParametersControl);
                this.gbxVisualizatorParameters.ResumeLayout();
            }
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                zoomOut = true;
                StartFractalGeneration();
            }
        }
    }
}


// TODO       
// visualizatory zrobic gui parametrów
// julia obsluga niedzialajacego visualizatora