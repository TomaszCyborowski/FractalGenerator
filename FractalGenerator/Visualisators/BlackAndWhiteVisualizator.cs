using System.Drawing;
using System.Numerics;
using System.Timers;

namespace FractalGenerator.Visualisators
{
    public class BlackAndWhiteVisualizator : AbstractVisualizator
    {        
        public override string VisualizatorDisplayName => "Black and White";
        public override bool RequiersSecondPass => false;
        public override VisualizatorParametersControl ParametersControl { get; }
               
        private Color firstColor = Color.FromArgb(0, 0, 0);
        private Color secondColor = Color.FromArgb(255, 255, 255);

        public BlackAndWhiteVisualizator(PixelCalculatedCallback pixelCalculatedCallback, DrawingPanelCallback drawingPanelCallback)
        {
                this.pixelCalculatedCallback = pixelCalculatedCallback;
                this.drawingPanelCallback = drawingPanelCallback;

                this.ParametersControl = new VisualizatorParametersControl();             
        }

        public override void PixelDidNotReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z)
        {
            this.pixelCalculatedCallback(pixelXposition, pixelYposition, firstColor);
        }

        public override void PixelReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z)
        {
            this.pixelCalculatedCallback(pixelXposition, pixelYposition, secondColor);
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


