namespace FractalGenerator
{
    public interface IFractal
    {
        bool SupportsZoom { get; }
        string FractalDisplayName { get; }

        void GenerateFractal();
        ParametersControl GetParametersControl();        
        void SetResolution(int height, int width);
        void SetSelectionToZoomIn(int selectionStartX, int selectionStartY, int selectionEndX, int selectionEndY);
    }
}