﻿namespace FractalGenerator.Visualisators
{
    partial class TwoColorsWithReturnVisualizatorParametersControl
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnSecondColor = new System.Windows.Forms.Button();
            this.btnFirstColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.numericColorReturnPoint = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericColorReturnPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSecondColor
            // 
            this.btnSecondColor.Location = new System.Drawing.Point(16, 99);
            this.btnSecondColor.Name = "btnSecondColor";
            this.btnSecondColor.Size = new System.Drawing.Size(41, 36);
            this.btnSecondColor.TabIndex = 2;
            this.btnSecondColor.UseVisualStyleBackColor = true;
            this.btnSecondColor.Click += new System.EventHandler(this.btnSecondColor_Click);
            // 
            // btnFirstColor
            // 
            this.btnFirstColor.Location = new System.Drawing.Point(16, 57);
            this.btnFirstColor.Name = "btnFirstColor";
            this.btnFirstColor.Size = new System.Drawing.Size(41, 36);
            this.btnFirstColor.TabIndex = 1;
            this.btnFirstColor.UseVisualStyleBackColor = true;
            this.btnFirstColor.Click += new System.EventHandler(this.btnFirstColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(16, 15);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(41, 36);
            this.btnBackColor.TabIndex = 0;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // numericMaxIterations
            // 
            this.numericColorReturnPoint.Location = new System.Drawing.Point(16, 141);
            this.numericColorReturnPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericColorReturnPoint.Name = "numericMaxIterations";
            this.numericColorReturnPoint.Size = new System.Drawing.Size(150, 26);
            this.numericColorReturnPoint.TabIndex = 7;
            this.numericColorReturnPoint.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // TwoColorsWithReturnVisualizatorParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericColorReturnPoint);
            this.Controls.Add(this.btnSecondColor);
            this.Controls.Add(this.btnFirstColor);
            this.Controls.Add(this.btnBackColor);
            this.Name = "TwoColorsWithReturnVisualizatorParametersControl";
            this.Size = new System.Drawing.Size(440, 322);
            ((System.ComponentModel.ISupportInitialize)(this.numericColorReturnPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnFirstColor;
        private System.Windows.Forms.Button btnSecondColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown numericColorReturnPoint;
    }
}
