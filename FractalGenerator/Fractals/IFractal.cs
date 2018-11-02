using FractalGenerator.Visualisators;

namespace FractalGenerator
{
    public interface IFractal
    {
        bool SupportsZoom { get; }
        string FractalDisplayName { get; }
        IVisualizator Visualizator { set; }

        void GenerateFractal();
        void CancelGeneration();
        ParametersControl GetParametersControl();        
        void SetImageResolution(int height, int width);
        void SetSelectionToZoomIn(int selectionStartX, int selectionStartY, int selectionEndX, int selectionEndY);        
    }
}