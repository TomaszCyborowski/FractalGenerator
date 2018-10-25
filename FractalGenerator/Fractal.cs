namespace FractalGenerator
{
    public delegate void PixelCalculatedCallback(int x, int y, int color);

    public class Fractal
    {
        private int controlHeight;
        private int controlWidth;
        private double calculateFromX;
        private double calculateToX;
        private double calculateFromY;
        private double calculateToY;
        private double stepX;
        private double stepY;
        private double stopValue;
        protected PixelCalculatedCallback responseCallback;
        
        public Fractal(PixelCalculatedCallback responseCallback, int height, int width)
        {
            this.responseCallback = responseCallback;
            this.controlHeight = height;
            this.controlWidth = width;                        

            this.stopValue = 10;
            this.calculateFromX = -2;
            this.calculateFromY = -2;
            this.calculateToX = 2;
            this.calculateToY = 2;
        }

        public void GenerateFractal()
        {
            const int interation = 0;
            this.CalculateStepValues(calculateFromX, calculateFromY, calculateToX, calculateToY);

            for (int pixelXposition = 0; pixelXposition < controlWidth; pixelXposition++)
                for (int pixelYposition = 0; pixelYposition < controlHeight; pixelYposition++)
                {

                    double a = calculateFromX + (stepX * (double)pixelXposition);
                    double b = calculateFromY + (stepY * (double)pixelYposition);
                    CalculatePixelValue(a, b, interation, pixelXposition, pixelYposition);
                }            
        }
        /*
        public void countStartPos(double x1, double x2, double y1, double y2)
        {
            double oldFromx = this.calculateFromX;
            double oldFromy = this.calculateFromY;
            calculateFromX = oldFromx + (stepX * (double)x1);
            calculateFromY = oldFromy + (stepY * (double)y1);
            calculateToX = oldFromx + (stepX * (double)x2);
            calculateToY = oldFromy + (stepY * (double)y2);
        }*/

        public void SetStopValue(double stopValue)
        {
            this.stopValue = stopValue;
        }

        public void SetResolution(int height, int width)
        {
            this.controlHeight = height;
            this.controlWidth = width;
        }

        private void CalculateStepValues(double startx, double starty, double endx, double endy)
        {            
            var calculateFromXToXSize = calculateToX - calculateFromX;
            this.stepX = calculateFromXToXSize / (double)this.controlWidth;
            this.stepY = this.stepX;
        }
        
        private void CalculatePixelValue(double a, double b, int iteration, int pixelXposition, int pixelYposition)
        {
            double pomx;
            double pomy;
            double x = 0;
            double y = 0;

            while (100 > iteration)
            {
                pomx = x;
                pomy = y;
                x = ((pomx * pomx)) - ((pomy * pomy)) + a;
                y = (2 * pomx * pomy) + b;

                if ((x * x) + (y * y) >= stopValue)
                {
                    this.responseCallback(pixelXposition, pixelYposition, 0);
                    return;
                }
                else
                {
                    iteration++;
                }
            }

            this.responseCallback(pixelXposition, pixelYposition, 1);
        }
    }
}
