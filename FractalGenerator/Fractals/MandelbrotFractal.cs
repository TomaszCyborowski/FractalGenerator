using System.Numerics;

namespace FractalGenerator.Fractals
{
    public sealed class MandelbrotFractal : AbstractFractal
    {
        private readonly MandelbrotParametersControl parametersControl;
                
        public override string FractalDisplayName { get => "Mandelbort"; }
        public override bool SupportsZoom { get => true; }

        public MandelbrotFractal()
        {
            this.maxIterations = 100;
            this.calculateFromX = -2;
            this.calculateToX = 1;
            this.calculateFromY = -1.5;
            this.calculateToY = 1;

            this.parametersControl = new MandelbrotParametersControl();
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
            const double stopValue = 4;            
            int iteration = 0;
            var z1 = new Complex(0, 0);            
            var c = new Complex(a, b);

            while (maxIterations > iteration)
            {                
                z1 = Complex.Pow(z1,new Complex(2,0)) + c;

                if ( Complex.Abs(z1) >= stopValue)
                {                    
                    this.Visualizator.PixelReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, z1);
                    return;
                }
                else
                {
                    iteration++;
                }
            }

            this.Visualizator.PixelDidNotReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, z1);            
        }

    }
}
