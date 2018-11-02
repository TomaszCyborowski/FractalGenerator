using System;
using System.Threading;
using System.Threading.Tasks;
using FractalGenerator.Visualisators;

namespace FractalGenerator
{
    public abstract class AbstractFractal : IFractal
    {
        public IVisualizator Visualizator { set; protected get; }
        
        protected int drawingControlHeight;
        protected int drawingControlWidth;
        protected System.Timers.Timer updatedrawingPanelTimer;

        private CancellationTokenSource tokenSource;

        public abstract bool SupportsZoom { get; }
        public abstract string FractalDisplayName { get; }     
                
        protected int maxIterations;
        protected double calculateFromX;
        protected double calculateToX;
        protected double calculateFromY;
        protected double calculateToY;
        protected double stepX;
        protected double stepY;
        
        public abstract ParametersControl GetParametersControl();
        
        protected abstract void GetParametersFromControl();
        protected abstract void UpdateParametersInControl();
        protected abstract void CalculatePixelValue(double a, double b, int pixelXposition, int pixelYposition);

        public void GenerateFractal()
        {
            GetParametersFromControl();
            this.CalculateStepValues();
            this.Visualizator.FractalGenerationStarted(this.maxIterations);
            this.CalculateImage();
            this.Visualizator.FractalGenerationEnded();
        }

        private void CalculateImage()
        {
            var numberOfProcessors = Environment.ProcessorCount;

            var pixelOffest = drawingControlWidth / numberOfProcessors;
            var startPixel = 0;
            var endPixel = pixelOffest;

            this.tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;
            Task[] taskArray = new Task[numberOfProcessors];
            for (int i = 0; i < numberOfProcessors; i++)
            {
                if (i == numberOfProcessors - 1)
                {
                    endPixel = drawingControlWidth;
                }

                var startPixelTaskValue = startPixel;
                var endPixelTaskValue = endPixel;
                taskArray[i] = Task.Factory.StartNew(() => { CalculateImagePart(startPixelTaskValue, endPixelTaskValue, ct); }, ct);

                startPixel += pixelOffest;
                endPixel = startPixel + pixelOffest;
            }

            try
            {
                Task.WaitAll(taskArray);
            }
            catch (AggregateException)
            {
                ;
            }
            finally
            {
                tokenSource.Dispose();
                tokenSource = null;
            }
        }
        
        public void SetImageResolution(int height, int width)
        {
            this.drawingControlHeight = height;
            this.drawingControlWidth = width;
        }
        
        public void SetSelectionToZoomIn(int selectionStartX, int selectionStartY, int selectionEndX, int selectionEndY)
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
        
        public void CancelGeneration()
        {
            tokenSource?.Cancel();
        }

        private void CalculateImagePart(int x, int x2, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            for (int pixelXposition = x; pixelXposition <= x2; pixelXposition++)
                for (int pixelYposition = 0; pixelYposition <= drawingControlHeight; pixelYposition++)
                {
                    ct.ThrowIfCancellationRequested();
                    double currentX = calculateFromX + (stepX * (double)pixelXposition);
                    double currentY = calculateFromY + (stepY * (double)pixelYposition);
                    CalculatePixelValue(currentX, currentY, pixelXposition, pixelYposition);
                }
        }

        private void CalculateStepValues()
        {
            var calculateFromXToXSize = calculateToX - calculateFromX;
            this.stepX = calculateFromXToXSize / (double)this.drawingControlWidth;
            this.stepY = this.stepX;
        }        
    }
}
