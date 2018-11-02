namespace FractalGenerator.Fractals
{
    partial class FractalV1ParametersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStartFromX = new System.Windows.Forms.Label();
            this.lblMaxIterations = new System.Windows.Forms.Label();
            this.numericMaxIterations = new System.Windows.Forms.NumericUpDown();
            this.lblEndX = new System.Windows.Forms.Label();
            this.lblStartFromY = new System.Windows.Forms.Label();
            this.lblEndY = new System.Windows.Forms.Label();
            this.txtStartFromX = new System.Windows.Forms.TextBox();
            this.txtEndX = new System.Windows.Forms.TextBox();
            this.txtStartFromY = new System.Windows.Forms.TextBox();
            this.txtEndY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartFromX
            // 
            this.lblStartFromX.AutoSize = true;
            this.lblStartFromX.Location = new System.Drawing.Point(14, 51);
            this.lblStartFromX.Name = "lblStartFromX";
            this.lblStartFromX.Size = new System.Drawing.Size(99, 20);
            this.lblStartFromX.TabIndex = 8;
            this.lblStartFromX.Text = "Start from X:";
            // 
            // lblMaxIterations
            // 
            this.lblMaxIterations.AutoSize = true;
            this.lblMaxIterations.Location = new System.Drawing.Point(14, 19);
            this.lblMaxIterations.Name = "lblMaxIterations";
            this.lblMaxIterations.Size = new System.Drawing.Size(111, 20);
            this.lblMaxIterations.TabIndex = 7;
            this.lblMaxIterations.Text = "Max iterations:";
            // 
            // numericMaxIterations
            // 
            this.numericMaxIterations.Location = new System.Drawing.Point(129, 13);
            this.numericMaxIterations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericMaxIterations.Name = "numericMaxIterations";
            this.numericMaxIterations.Size = new System.Drawing.Size(150, 26);
            this.numericMaxIterations.TabIndex = 6;
            this.numericMaxIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblEndX
            // 
            this.lblEndX.AutoSize = true;
            this.lblEndX.Location = new System.Drawing.Point(14, 83);
            this.lblEndX.Name = "lblEndX";
            this.lblEndX.Size = new System.Drawing.Size(57, 20);
            this.lblEndX.TabIndex = 9;
            this.lblEndX.Text = "End X:";
            // 
            // lblStartFromY
            // 
            this.lblStartFromY.AutoSize = true;
            this.lblStartFromY.Location = new System.Drawing.Point(14, 115);
            this.lblStartFromY.Name = "lblStartFromY";
            this.lblStartFromY.Size = new System.Drawing.Size(104, 20);
            this.lblStartFromY.TabIndex = 10;
            this.lblStartFromY.Text = "Start From Y:";
            // 
            // lblEndY
            // 
            this.lblEndY.AutoSize = true;
            this.lblEndY.Location = new System.Drawing.Point(14, 147);
            this.lblEndY.Name = "lblEndY";
            this.lblEndY.Size = new System.Drawing.Size(57, 20);
            this.lblEndY.TabIndex = 11;
            this.lblEndY.Text = "End Y:";
            // 
            // txtStartFromX
            // 
            this.txtStartFromX.Location = new System.Drawing.Point(129, 46);
            this.txtStartFromX.Name = "txtStartFromX";
            this.txtStartFromX.ReadOnly = true;
            this.txtStartFromX.Size = new System.Drawing.Size(150, 26);
            this.txtStartFromX.TabIndex = 12;
            // 
            // txtEndX
            // 
            this.txtEndX.Location = new System.Drawing.Point(129, 79);
            this.txtEndX.Name = "txtEndX";
            this.txtEndX.ReadOnly = true;
            this.txtEndX.Size = new System.Drawing.Size(150, 26);
            this.txtEndX.TabIndex = 13;
            // 
            // txtStartFromY
            // 
            this.txtStartFromY.Location = new System.Drawing.Point(129, 112);
            this.txtStartFromY.Name = "txtStartFromY";
            this.txtStartFromY.ReadOnly = true;
            this.txtStartFromY.Size = new System.Drawing.Size(150, 26);
            this.txtStartFromY.TabIndex = 14;
            // 
            // txtEndY
            // 
            this.txtEndY.Location = new System.Drawing.Point(129, 145);
            this.txtEndY.Name = "txtEndY";
            this.txtEndY.ReadOnly = true;
            this.txtEndY.Size = new System.Drawing.Size(150, 26);
            this.txtEndY.TabIndex = 15;
            // 
            // MandelbrotParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEndY);
            this.Controls.Add(this.txtStartFromY);
            this.Controls.Add(this.txtEndX);
            this.Controls.Add(this.txtStartFromX);
            this.Controls.Add(this.lblEndY);
            this.Controls.Add(this.lblStartFromY);
            this.Controls.Add(this.lblEndX);
            this.Controls.Add(this.lblStartFromX);
            this.Controls.Add(this.lblMaxIterations);
            this.Controls.Add(this.numericMaxIterations);
            this.Name = "MandelbrotParametersControl";
            this.Size = new System.Drawing.Size(293, 386);
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxIterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartFromX;
        private System.Windows.Forms.Label lblMaxIterations;
        private System.Windows.Forms.NumericUpDown numericMaxIterations;
        private System.Windows.Forms.Label lblEndX;
        private System.Windows.Forms.Label lblStartFromY;
        private System.Windows.Forms.Label lblEndY;
        private System.Windows.Forms.TextBox txtStartFromX;
        private System.Windows.Forms.TextBox txtEndX;
        private System.Windows.Forms.TextBox txtStartFromY;
        private System.Windows.Forms.TextBox txtEndY;
    }
}
