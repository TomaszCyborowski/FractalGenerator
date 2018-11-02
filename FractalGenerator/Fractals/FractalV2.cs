using System.Numerics;

namespace FractalGenerator.Fractals
{
    public sealed class FractalV2 : AbstractFractal
    {
        private readonly FractalV1ParametersControl parametersControl;
                    
        public override string FractalDisplayName { get => "Fractal V 2 - ez+c"; }
        public override bool SupportsZoom { get => true; }

        public FractalV2()
        {
            this.maxIterations = 100;
            this.calculateFromX = -2;
            this.calculateToX = 2;
            this.calculateFromY = -2;
            this.calculateToY = 2;

            this.parametersControl = new FractalV1ParametersControl();
            this.UpdateParametersInControl();
        }
        
        public override ParametersControl GetParametersControl()
        {
            return this.parametersControl;
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
        
        protected override void CalculatePixelValue(double a, double b, int pixelXposition, int pixelYposition)
        {
            double stopValue = 50;
            var C = new Complex(a, b);
            var Z0 = new Complex(a, b);
            int iteration = 0;

            while (maxIterations > iteration)
            {
                Z0 = Complex.Exp(Z0) + C; ;

                if (Complex.Abs(Z0) >= stopValue)
                {

                    this.Visualizator.PixelReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, Z0);
                    return;
                }
                else
                {
                    iteration++;
                }
            }

            this.Visualizator.PixelDidNotReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, Z0);
        }
    }
}
