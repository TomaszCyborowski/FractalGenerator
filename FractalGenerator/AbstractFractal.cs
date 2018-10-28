using System;
using System.Timers;

namespace FractalGenerator
{
    public abstract class AbstractFractal : IFractal
    {
        protected int drawingControlHeight;
        protected int drawingControlWidth;
        protected PixelCalculatedCallback pixelCalculatedCallback;
        protected DrawingPanelCallback drawingPanelCallback;
        protected Timer updatedrawingPanelTimer;

        public abstract bool SupportsZoom { get; }
        public abstract string FractalDisplayName { get; }

        public abstract void GenerateFractal();        
        public abstract ParametersControl GetParametersControl();
        public abstract void SetSelectionToZoomIn(int selectionStartX, int selectionStartY, int selectionEndX, int selectionEndY);

        protected abstract void GetParametersFromControl();
        protected abstract void UpdateParametersInControl();

        public void SetResolution(int height, int width)
        {
            this.drawingControlHeight = height;
            this.drawingControlWidth = width;
        }

        protected void StartUpdatedDrawingPanelTimer()
        {
            updatedrawingPanelTimer = new System.Timers.Timer();
            updatedrawingPanelTimer.Elapsed += new ElapsedEventHandler(OnUpdatedDrawingPanelTimedEvent);
            updatedrawingPanelTimer.Interval = 100;
            updatedrawingPanelTimer.Enabled = true;
        }

        protected void StopUpdateDrawingPanelTimer()
        {
            updatedrawingPanelTimer?.Stop();
        }

        protected void OnUpdatedDrawingPanelTimedEvent(object source, ElapsedEventArgs e)
        {
            this.drawingPanelCallback();
        }
    }
}
