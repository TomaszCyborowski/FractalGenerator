using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalGenerator
{   
    public partial class MainWindow : Form
    {
        private Fractal fractal;
        private Thread fractalThread;
        private Graphics graphics;

        public MainWindow()
        {
            InitializeComponent();
            fractal = new Fractal(OnResponse, this.drawingPanel.Height, this.drawingPanel.Width);

            // TODO 
            // refaktoryzacja
            // liczenie na kilku wątkach            
            // var test = Environment.ProcessorCount;
            // kolorowanie
            // powiększanie
            // julia
        }

        protected void OnResponse(int x, int y, int color)
        {            
            Brush aBrush = color == 1 ? (Brush)Brushes.Black : (Brush)Brushes.White;            
            graphics.FillRectangle(aBrush, x, y, 1, 1);            
        }

        private void btnStartClick(object sender, EventArgs e)
        {            
            graphics = this.drawingPanel.CreateGraphics();
            fractal.SetStopValue((double)this.numericStopValue.Value);
            fractal.SetResolution(this.drawingPanel.Height, this.drawingPanel.Width);
            fractalThread = new Thread(new ThreadStart(fractal.GenerateFractal));
            fractalThread.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fractalThread.Abort();
        }
    }
}
