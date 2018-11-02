using System;
using System.Globalization;

namespace FractalGenerator.Fractals
{
    public partial class JuliaParametersControl : ParametersControl
    {
        public JuliaParametersControl()
        {
            InitializeComponent();
            this.cbxExampleParameters.SelectedIndex = 0;
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

        public double CX
        {
            get
            {
                return Double.Parse(this.txtCX.Text);
            }

            set
            {
                this.txtCX.Text = value.ToString();
            }
        }

        public double CY
        {
            get
            {
                return Double.Parse(this.txtCY.Text);
            }

            set
            {
                this.txtCY.Text = value.ToString();
            }
        }

        private void exampleParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parameters = ((string)this.cbxExampleParameters.SelectedItem).Split(';');

            CX = Double.Parse(parameters[0], CultureInfo.InvariantCulture);
            CY = Double.Parse(parameters[1], CultureInfo.InvariantCulture);
        }
    }
}
