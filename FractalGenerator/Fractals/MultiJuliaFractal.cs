using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace FractalGenerator.Fractals
{
    public sealed class MultiJuliaFractal : AbstractFractal
    {
        private readonly MultiJuliaParametersControl parametersControl;
        
        private double n;
        private double cx;
        private double cy;
        
        public override string FractalDisplayName { get => "Multi Julia"; }
        public override bool SupportsZoom { get => true; }

        public MultiJuliaFractal()
        {
            this.maxIterations = 100;
            this.calculateFromX = -2;
            this.calculateToX = 2;
            this.calculateFromY = -1.5;
            this.calculateToY = 1;
            this.n = 6;
            this.cx = 0.626;
            this.cy = 0;

            this.parametersControl = new MultiJuliaParametersControl();
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
            this.cx = this.parametersControl.CX;
            this.cy = this.parametersControl.CY;
            this.n = this.parametersControl.N;
        }

        protected override void UpdateParametersInControl()
        {
            this.parametersControl.MaxIterations = maxIterations;
            this.parametersControl.StartFromX = this.calculateFromX;
            this.parametersControl.StartFromY = this.calculateFromY;
            this.parametersControl.EndX = this.calculateToX;
            this.parametersControl.EndY = this.calculateToY;
            this.parametersControl.CX = this.cx;
            this.parametersControl.CY = this.cy;
            this.parametersControl.N = this.n;
        }
        
        protected override void CalculatePixelValue(double a, double b, int pixelXposition, int pixelYposition)
        {
            const double stopValue = 4;       
            int iteration = 0;

            var z1 = new Complex(a, b);
            var c = new Complex(cx, cy);

            while (maxIterations > iteration)
            {
                z1 = Complex.Pow(z1, new Complex(n, 0)) + c;

                if (Complex.Abs(z1) >= stopValue)
                {
                    this.Visualizator.PixelReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, new System.Numerics.Complex(0, 0));
                    return;
                }
                else
                {
                    iteration++;
                }
            }

            this.Visualizator.PixelDidNotReachedStopValue(pixelXposition, pixelYposition, iteration, maxIterations, new System.Numerics.Complex(0, 0));            
        }
    }
}
