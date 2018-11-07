using System;
using System.Drawing;
using System.Numerics;
using System.Timers;

namespace FractalGenerator.Visualisators
{
    public class SmoothVisualizator : AbstractVisualizator
    {
        public override string VisualizatorDisplayName => "Smooth - two colors";
        public override bool RequiersSecondPass => true;
        private TwoColorsVisualizatorParametersControl parametersControl;


        private int[] histogram; 
        private int[,] image;
        private double[,] imageZValues;
        private Color backColor = Color.FromArgb(0, 0, 0);
        private Color firstColor = Color.FromArgb(35, 100, 206);
        private Color secondColor = Color.FromArgb(206, 197, 35);
        private int maxIterations;

        public SmoothVisualizator(PixelCalculatedCallback pixelCalculatedCallback, DrawingPanelCallback drawingPanelCallback)
        {
            this.pixelCalculatedCallback = pixelCalculatedCallback;
            this.drawingPanelCallback = drawingPanelCallback;

            this.parametersControl = new TwoColorsVisualizatorParametersControl();
            this.UpdateParametersInControl();
        }

        public override void FractalGenerationEnded()
        {
            this.ExecuteSecondPass();
            updatedrawingPanelTimer?.Stop();
            this.drawingPanelCallback();
        }

        public override void FractalGenerationStarted(int maxIterations)
        {
            this.GetParametersFromControl();
            this.maxIterations = maxIterations;
            histogram = new int[maxIterations];
            image = new int[drawingControlWidth+1, drawingControlHeight+1];
            imageZValues = new double[drawingControlWidth+1, drawingControlHeight+1];

            updatedrawingPanelTimer = new System.Timers.Timer();
            updatedrawingPanelTimer.Elapsed += new ElapsedEventHandler(OnUpdatedDrawingPanelTimedEvent);
            updatedrawingPanelTimer.Interval = 100;
            updatedrawingPanelTimer.Enabled = true;
        }

        public override void PixelDidNotReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z)
        {
            this.pixelCalculatedCallback(pixelXposition, pixelYposition, this.backColor);
            image[pixelXposition, pixelYposition] = maxIterations;
            imageZValues[pixelXposition,pixelYposition] = (iteration + 1.0 - (Math.Log(Math.Log(Complex.Abs(z), 2)))) / (double)maxIterations;
        }

        public override void PixelReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z)
        {
            this.pixelCalculatedCallback(pixelXposition, pixelYposition, this.firstColor);
            histogram[iteration]++;
            image[pixelXposition, pixelYposition] = iteration;
            imageZValues[pixelXposition, pixelYposition] = (iteration + 1.0 - (Math.Log(Math.Log(Complex.Abs(z), 2)))) / (double)maxIterations;
        }

        private void ExecuteSecondPass()
        {
            var total = 0;
            for (int i = 0; i < maxIterations; i++)
            {
                total += histogram[i];
            }

            var steps = new double[maxIterations];
            double hueValue = 0;
            for (int i = 0; i < maxIterations; i++)
            {
                hueValue += (double)histogram[i] / (double)total;
                steps[i] = hueValue;
            }

            var redStep = (double)(secondColor.R - firstColor.R);
            var greenStep = (double)(secondColor.G - firstColor.G);
            var blueStep = (double)(secondColor.B - firstColor.B);

            for (int pixelXposition = 0; pixelXposition <= drawingControlWidth; pixelXposition++)
                for (int pixelYposition = 0; pixelYposition <= drawingControlHeight; pixelYposition++)
                {
                    if (image[pixelXposition, pixelYposition] == maxIterations)
                    {
                        this.pixelCalculatedCallback(pixelXposition, pixelYposition, this.backColor);                            
                    }
                    else
                    {
                        var red = (int)(firstColor.R + (redStep * steps[image[pixelXposition, pixelYposition]]) * imageZValues[pixelXposition, pixelYposition]);
                        var green = (int)(firstColor.G + (greenStep * steps[image[pixelXposition, pixelYposition]]) * imageZValues[pixelXposition, pixelYposition]);
                        var blue = (int)(firstColor.B + (blueStep * steps[image[pixelXposition, pixelYposition]]) * imageZValues[pixelXposition, pixelYposition]);
                        var result = Color.FromArgb(red, green, blue);                        
                        this.pixelCalculatedCallback(pixelXposition, pixelYposition, result);
                    }
                }
        }

        public override VisualizatorParametersControl GetParametersControl()
        {
            return this.parametersControl;
        }

        protected override void GetParametersFromControl()
        {
            this.backColor = this.parametersControl.FractalBackColor;
            this.firstColor = this.parametersControl.FractalFirstColor;
            this.secondColor = this.parametersControl.FractalSecondColor;
        }

        protected override void UpdateParametersInControl()
        {
            this.parametersControl.FractalBackColor = this.backColor;
            this.parametersControl.FractalFirstColor = this.firstColor;
            this.parametersControl.FractalSecondColor = this.secondColor;
        }
    }
}
