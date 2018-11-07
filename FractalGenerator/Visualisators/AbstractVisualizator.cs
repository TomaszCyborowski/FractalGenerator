using System.Numerics;
using System.Timers;

namespace FractalGenerator.Visualisators
{
    public abstract class AbstractVisualizator : IVisualizator
    {
        protected int drawingControlHeight;
        protected int drawingControlWidth;
        protected Timer updatedrawingPanelTimer;
        protected PixelCalculatedCallback pixelCalculatedCallback;
        protected DrawingPanelCallback drawingPanelCallback;
        
        public abstract string VisualizatorDisplayName { get; }
        public abstract bool RequiersSecondPass { get; }
        
        public abstract void FractalGenerationEnded();        
        public abstract void FractalGenerationStarted(int maxIterations);

        public abstract void PixelDidNotReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z);  
        public abstract void PixelReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z);
        public abstract VisualizatorParametersControl GetParametersControl();
        protected abstract void GetParametersFromControl();
        protected abstract void UpdateParametersInControl();

        public void SetImageResolution(int height, int width)
        {
            this.drawingControlHeight = height;
            this.drawingControlWidth = width;
        }

        protected void OnUpdatedDrawingPanelTimedEvent(object source, ElapsedEventArgs e)
        {
            this.drawingPanelCallback();
        }
    }
}


