using System;

namespace FractalGenerator.Fractals
{
    public partial class FractalV1ParametersControl : ParametersControl
    {
        public FractalV1ParametersControl()
        {
            InitializeComponent();
        }

        public int MaxIterations
        {
            get
            {
                return (int)this.numericMaxIterations.Value;
            }

            set
            {
                this.numericMaxIterations.Value = (decimal)value;
            }
        }

        public double StartFromX
        {
            get
            {
                return Double.Parse(this.txtStartFromX.Text);
            }

            set
            {
                this.txtStartFromX.Text = value.ToString();
            }
        }
        public double EndX
        {
            get
            {
                return Double.Parse(this.txtEndX.Text);
            }

            set
            {
                this.txtEndX.Text = value.ToString();
            }
        }
        public double StartFromY
        {
            get
            {
                return Double.Parse(this.txtStartFromY.Text);
            }

            set
            {
                this.txtStartFromY.Text = value.ToString();
            }
        }
        public double EndY
        {
            get
            {
                return Double.Parse(this.txtEndY.Text);
            }

            set
            {
                this.txtEndY.Text = value.ToString();
            }
        }        
    }
}
