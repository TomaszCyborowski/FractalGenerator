using System.Drawing;
using System.Numerics;
using System.Timers;

namespace FractalGenerator.Visualisators
{
    public class TwoColorsVisualizator : AbstractVisualizator
    {        
        public override string VisualizatorDisplayName => "Two colors";
        public override bool RequiersSecondPass => false;
        public override VisualizatorParametersControl ParametersControl { get; }

        private Color backColor = Color.FromArgb(0, 0, 0);
        private Color firstColor = Color.FromArgb(35, 100, 206);
        private Color secondColor = Color.FromArgb(206, 197, 35);

        public TwoColorsVisualizator(PixelCalculatedCallback pixelCalculatedCallback, DrawingPanelCallback drawingPanelCallback)
        {
                this.pixelCalculatedCallback = pixelCalculatedCallback;
                this.drawingPanelCallback = drawingPanelCallback;

                this.ParametersControl = new VisualizatorParametersControl();             
        }

        public override void PixelDidNotReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z)
        {
            this.pixelCalculatedCallback(pixelXposition, pixelYposition, backColor);
        }

        public override void PixelReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z)
        {
            var redStep = (double)(secondColor.R - firstColor.R) / maxIterations;
            var greenStep = (double)(secondColor.G - firstColor.G) / maxIterations;
            var blueStep = (double)(secondColor.B - firstColor.B) / maxIterations;
            var result = Color.FromArgb((int)(firstColor.R + (redStep * iteration)), (int)(firstColor.G + (greenStep * iteration)), (int)(firstColor.B + (blueStep * iteration)));

            this.pixelCalculatedCallback(pixelXposition, pixelYposition, result);
        }

        public override void FractalGenerationEnded()
        {
            updatedrawingPanelTimer?.Stop();
            this.drawingPanelCallback();
        }

        public override void FractalGenerationStarted(int maxIterations)
        {
            updatedrawingPanelTimer = new System.Timers.Timer();
            updatedrawingPanelTimer.Elapsed += new ElapsedEventHandler(OnUpdatedDrawingPanelTimedEvent);
            updatedrawingPanelTimer.Interval = 100;
            updatedrawingPanelTimer.Enabled = true;
        }
    }
}


