using System;
using System.Drawing;
using System.Threading.Tasks;

namespace FractalGenerator.MultiThreadedMandelbrot
{
    public sealed class MultiThreadedMandelbrotFractal : AbstractFractal
    {
        private readonly MandelbrotParametersControl parametersControl;
        
        private int maxIterations = 100;
        private double calculateFromX = -2;
        private double calculateToX = 1;
        private double calculateFromY = -1.5;
        private double calculateToY = 1;
        private double stepX;
        private double stepY;
                
        public override string FractalDisplayName { get => "Mandelbort multithreaded"; }
        public override bool SupportsZoom { get => true; }

        public MultiThreadedMandelbrotFractal(PixelCalculatedCallback pixelCalculatedCallback, DrawingPanelCallback drawingPanelCallback)
        {
            this.pixelCalculatedCallback = pixelCalculatedCallback;
            this.drawingPanelCallback = drawingPanelCallback;

            this.parametersControl = new MandelbrotParametersControl();
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
            var numberOfProcessors = Environment.ProcessorCount;

            var pixelOffest = drawingControlWidth / numberOfProcessors;
            var startPixel = 1;
            var endPixel = pixelOffest;

            Task[] taskArray = new Task[numberOfProcessors];
            for (int i = 0; i < numberOfProcessors; i++)
            {
                if (i == numberOfProcessors - 1)
                {
                    endPixel = drawingControlWidth;
                }

                var startPixelTaskValue = startPixel;
                var endPixelTaskValue = endPixel;
                taskArray[i] = Task.Factory.StartNew(() => { CalculateImagePart(startPixelTaskValue, endPixelTaskValue); });

                startPixel += pixelOffest;
                endPixel = startPixel + pixelOffest;

            }

            Task.WaitAll(taskArray);
        }

        private void CalculateImagePart(int x, int x2)
        {
            for (int pixelXposition = x; pixelXposition <= x2; pixelXposition++)
                for (int pixelYposition = 0; pixelYposition <= drawingControlHeight; pixelYposition++)
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
        }

        protected override void UpdateParametersInControl()
        {
            this.parametersControl.MaxIterations = maxIterations;
            this.parametersControl.StartFromX = this.calculateFromX;
            this.parametersControl.StartFromY = this.calculateFromY;
            this.parametersControl.EndX = this.calculateToX;
            this.parametersControl.EndY = this.calculateToY;
        }
        
        private void CalculateStepValues()
        {            
            var calculateFromXToXSize = calculateToX - calculateFromX;
            this.stepX = calculateFromXToXSize / (double)this.drawingControlWidth;
            this.stepY = this.stepX;
        }
        
        private void CalculatePixelValue(double a, double b, int pixelXposition, int pixelYposition)
        {
            const double stopValue = 2;
            double realPart = 0;
            double imaginaryPart = 0;
            double previousRealPart;
            double previosuImaginaryPart;
            int iteration = 0;

            while (maxIterations > iteration)
            {
                previousRealPart = realPart;
                previosuImaginaryPart = imaginaryPart;
                realPart = ((previousRealPart * previousRealPart) - (previosuImaginaryPart * previosuImaginaryPart)) + a;
                imaginaryPart = (2 * previousRealPart * previosuImaginaryPart) + b;
                                
                if ((realPart * realPart) + (imaginaryPart * imaginaryPart) >= stopValue)
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
        }
    }
}
