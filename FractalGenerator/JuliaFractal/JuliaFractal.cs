﻿using System.Drawing;

namespace FractalGenerator.Julia
{
    public sealed class JuliaFractal : AbstractFractal
    {
        private readonly JuliaParametersControl parametersControl;
                
        private int maxIterations = 100;
        private double calculateFromX = -2;
        private double calculateToX = 2;
        private double calculateFromY = -1.5;
        private double calculateToY = 1;
        private double cx = -0.70176;
        private double cy = -0.3842;
        private double stepX;
        private double stepY;
                
        public override string FractalDisplayName { get => "Julia"; }
        public override bool SupportsZoom { get => true; }

        public JuliaFractal(PixelCalculatedCallback pixelCalculatedCallback, DrawingPanelCallback drawingPanelCallback)
        {
            this.pixelCalculatedCallback = pixelCalculatedCallback;
            this.drawingPanelCallback = drawingPanelCallback;

            this.parametersControl = new JuliaParametersControl();
            this.UpdateParametersInControl();
        }

        public override void GenerateFractal()
        {
            GetParametersFromControl();
            this.CalculateStepValues();
            this.StartUpdatedDrawingPanelTimer();
            this.CalculateImage();
            this.StopUpdateDrawingPanelTimer();
            this.drawingPanelCallback();
        }

        private void CalculateImage()
        {
            for (int pixelXposition = 0; pixelXposition < drawingControlWidth; pixelXposition++)
                for (int pixelYposition = 0; pixelYposition < drawingControlHeight; pixelYposition++)
                {
                    double currentX = calculateFromX + (stepX * (double)pixelXposition);
                    double currentY = calculateFromY + (stepY * (double)pixelYposition);
                    CalculatePixelValue(currentX, currentY, pixelXposition, pixelYposition);
                }
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

                var xtemp = zx * zx - zy * zy;
                zy = 2 * zx * zy + cy;
                zx = xtemp + cx;
                                             
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
