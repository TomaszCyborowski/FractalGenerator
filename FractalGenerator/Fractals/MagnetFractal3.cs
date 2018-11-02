using System.Numerics;

namespace FractalGenerator.Fractals
{
    public sealed class MagnetFractal3 : AbstractFractal
    {
        private readonly FractalV1ParametersControl parametersControl;
                        
        public override string FractalDisplayName { get => "Magnet Fractal 3"; }
        public override bool SupportsZoom { get => true; }

        public MagnetFractal3()
        {
            this.maxIterations = 100;
            this.calculateFromX = -1;
            this.calculateToX = 3;
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
            var C = new Complex(a,b);           
            var Z = new Complex(0,0);
            
            int iteration = 0;

            while (maxIterations > iteration)
            {             
                Z = Complex.Pow(

                    (Complex.Pow(Z, new Complex(3,0)) + 3 *(C - 1) * Z + (C-1) * (C -2 ))
                    /
                    (3* Complex.Pow(Z, new Complex(2, 0)) +3 * (C - 2) * Z + (C - 1) * (C - 2)+1)

                    , new Complex(2, 0));

                if (Complex.Abs(Z) >= 30)
                {
                    this.Visualizator.PixelReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, Z);
                    return;
                }
                else
                {
                    iteration++;
                }
            }

            this.Visualizator.PixelDidNotReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, Z);
        }
    }
}
