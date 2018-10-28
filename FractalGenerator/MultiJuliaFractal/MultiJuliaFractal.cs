using System;
using System.Drawing;

namespace FractalGenerator.MultiJulia
{
    public sealed class MultiJuliaFractal : AbstractFractal
    {
        private readonly MultiJuliaParametersControl parametersControl;
                
        private int maxIterations = 100;
        private double calculateFromX = -2;
        private double calculateToX = 2;
        private double calculateFromY = -1.5;
        private double calculateToY = 1;
        private double n = 6;
        private double cx = 0.626;
        private double cy = 0;
        private double stepX;
        private double stepY;
                
        public override string FractalDisplayName { get => "Multi Julia"; }
        public override bool SupportsZoom { get => true; }

        public MultiJuliaFractal(PixelCalculatedCallback pixelCalculatedCallback, DrawingPanelCallback drawingPanelCallback)
        {
            this.pixelCalculatedCallback = pixelCalculatedCallback;
            this.drawingPanelCallback = drawingPanelCallback;

            this.parametersControl = new MultiJuliaParametersControl();
            this.UpdateParametersInControl();
        }

        public override void GenerateFractal()
        {
            GetParametersFromControl();
            this.CalculateStepValues();
            this.StartUpdatedDrawingPanelTimer();

            for (int pixelXposition = 0; pixelXposition < drawingControlWidth; pixelXposition++)
                for (int pixelYposition = 0; pixelYposition < drawingControlHeight; pixelYposition++)
                {
                    double currentX = calculateFromX + (stepX * (double)pixelXposition);
                    double currentY = calculateFromY + (stepY * (double)pixelYposition);
                    CalculatePixelValue(currentX, currentY, pixelXposition, pixelYposition);
                }

            this.StopUpdateDrawingPanelTimer();
            this.drawingPanelCallback();
        }

        public override ParametersControl GetParametersControl()
        {
            return this.parametersControl;
        }
        
        public override void SetSelectionToZoomIn(int selectionStartX, int selectionStartY, int selectionEndX, int selectionEndY)
        {
            GetParametersFromControl();
            this.CalculateStepValues();

            double oldFromx = this.calculateFromX;
            double oldFromy = this.calculateFromY;
            calculateFromX = oldFromx + (stepX * (double)selectionStartX);
            calculateFromY = oldFromy + (stepY * (double)selectionStartY);
            calculateToX = oldFromx + (stepX * (double)selectionEndX);
            calculateToY = oldFromy + (stepY * (double)selectionEndY);
            UpdateParametersInControl();
        }
                
        protected override void GetParametersFromControl()
        {
            this.maxIterations = this.parametersControl.MaxIterations;
            this.calculateFromX = this.parametersControl.StartFromX;
            this.calculateFromY = this.parametersControl.StartFromY;
            this.calculateToX = this.parametersControl.EndX;
            this.calculateToY = this.parametersControl.EndY;
            this.cx = this.parametersControl.CX;
            this.cy = this.parametersControl.CY;
            this.n = this.parametersControl.N;
        }

        protected override void UpdateParametersInControl()
        {
            this.parametersControl.MaxIterations = maxIterations;
            this.parametersControl.StartFromX = this.calculateFromX;
            this.parametersControl.StartFromY = this.calculateFromY;
            this.parametersControl.EndX = this.calculateToX;
            this.parametersControl.EndY = this.calculateToY;
            this.parametersControl.CX = this.cx;
            this.parametersControl.CY = this.cy;
            this.parametersControl.N = this.n;
        }
        
        private void CalculateStepValues()
        {            
            var calculateFromXToXSize = calculateToX - calculateFromX;
            this.stepX = calculateFromXToXSize / (double)this.drawingControlWidth;
            this.stepY = this.stepX;
        }
        
        private void CalculatePixelValue(double a, double b, int pixelXposition, int pixelYposition)
        {
            const double stopValue = 4;       
            int iteration = 0;

            var zx = a;
            var zy = b;
            
            while (maxIterations > iteration)
            {
                double xtmp = Math.Pow((zx * zx + zy * zy),(n / 2)) * Math.Cos(n * Math.Atan2(zy, zx)) + cx;
                zy = Math.Pow((zx * zx + zy * zy), (n / 2)) * Math.Sin(n * Math.Atan2(zy, zx)) + cy;
                zx = xtmp;
                                                             
                if (zx * zx + zy * zy >= stopValue)
                {
                    var color = GetColor(iteration, maxIterations);
                    this.pixelCalculatedCallback(pixelXposition, pixelYposition, color);
                    return;
                }
                else
                {
                    iteration++;
                }
            }

            this.pixelCalculatedCallback(pixelXposition, pixelYposition, Color.FromArgb(0,0,0));
        }

        private Color GetColor(int iteration, int maxIterations)
        {
            int valueType = 0;
            //var valueType = (int)(iteration * (255.0 / maxIterations));
            if (maxIterations >= 255)
            {
                valueType = iteration % 255;
            }
            else
            {
                valueType = iteration;
            }
            return Color.FromArgb(255 - valueType, 255 - valueType, 255 - valueType);
            
            //return Color.FromArgb(255, 255, 255);
        }       
    }
}
