using System.Numerics;

namespace FractalGenerator.Visualisators
{
    public interface IVisualizator
    {
        string VisualizatorDisplayName { get; }
        bool RequiersSecondPass { get; }
        
        void SetImageResolution(int height, int width);                
        void FractalGenerationStarted(int maxIterations);
        void FractalGenerationEnded();
        void PixelReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z);
        void PixelDidNotReachedStopValue(int pixelXposition, int pixelYposition, int iteration, int maxIterations, Complex z);
        VisualizatorParametersControl GetParametersControl();
    }
}


