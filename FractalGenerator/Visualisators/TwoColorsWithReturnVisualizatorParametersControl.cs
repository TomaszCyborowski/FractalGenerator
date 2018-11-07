using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalGenerator.Visualisators
{
    public partial class TwoColorsWithReturnVisualizatorParametersControl : VisualizatorParametersControl
    {
        public TwoColorsWithReturnVisualizatorParametersControl()
        {
            InitializeComponent();
        }

        public Color FractalBackColor
        {
            get
            {
                return this.btnBackColor.BackColor;
            }

            set
            {
                this.btnBackColor.BackColor = value;
            }
        }

        public Color FractalFirstColor
        {
            get
            {
                return this.btnFirstColor.BackColor;
            }

            set
            {
                this.btnFirstColor.BackColor = value;
            }
        }

        public Color FractalSecondColor
        {
            get
            {
                return this.btnSecondColor.BackColor;
            }

            set
            {
                this.btnSecondColor.BackColor = value;
            }
        }

        public int ColorReturnPoint
        {
            get
            {
                return (int)this.numericColorReturnPoint.Value;
            }

            set
            {
                this.numericColorReturnPoint.Value = (decimal)value;
            }
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                this.btnBackColor.BackColor =  colorDialog.Color;
            }
        }

        private void btnFirstColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                this.btnFirstColor.BackColor = colorDialog.Color;
            }
        }

        private void btnSecondColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                this.btnSecondColor.BackColor = colorDialog.Color;
            }
        }
    }
}
