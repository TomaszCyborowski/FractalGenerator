namespace FractalGenerator.Visualisators
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
            this.lblSecondColor = new System.Windows.Forms.Label();
            this.lblFirstColor = new System.Windows.Forms.Label();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.lblColorReturnPoint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericColorReturnPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSecondColor
            // 
            this.btnSecondColor.Location = new System.Drawing.Point(111, 87);
            this.btnSecondColor.Name = "btnSecondColor";
            this.btnSecondColor.Size = new System.Drawing.Size(41, 36);
            this.btnSecondColor.TabIndex = 2;
            this.btnSecondColor.UseVisualStyleBackColor = true;
            this.btnSecondColor.Click += new System.EventHandler(this.btnSecondColor_Click);
            // 
            // btnFirstColor
            // 
            this.btnFirstColor.Location = new System.Drawing.Point(111, 45);
            this.btnFirstColor.Name = "btnFirstColor";
            this.btnFirstColor.Size = new System.Drawing.Size(41, 36);
            this.btnFirstColor.TabIndex = 1;
            this.btnFirstColor.UseVisualStyleBackColor = true;
            this.btnFirstColor.Click += new System.EventHandler(this.btnFirstColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(111, 3);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(41, 36);
            this.btnBackColor.TabIndex = 0;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // numericColorReturnPoint
            // 
            this.numericColorReturnPoint.Location = new System.Drawing.Point(7, 161);
            this.numericColorReturnPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericColorReturnPoint.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColorReturnPoint.Name = "numericColorReturnPoint";
            this.numericColorReturnPoint.Size = new System.Drawing.Size(139, 26);
            this.numericColorReturnPoint.TabIndex = 7;
            this.numericColorReturnPoint.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblSecondColor
            // 
            this.lblSecondColor.AutoSize = true;
            this.lblSecondColor.Location = new System.Drawing.Point(3, 95);
            this.lblSecondColor.Name = "lblSecondColor";
            this.lblSecondColor.Size = new System.Drawing.Size(106, 20);
            this.lblSecondColor.TabIndex = 10;
            this.lblSecondColor.Text = "Second color:";
            // 
            // lblFirstColor
            // 
            this.lblFirstColor.AutoSize = true;
            this.lblFirstColor.Location = new System.Drawing.Point(3, 53);
            this.lblFirstColor.Name = "lblFirstColor";
            this.lblFirstColor.Size = new System.Drawing.Size(82, 20);
            this.lblFirstColor.TabIndex = 9;
            this.lblFirstColor.Text = "First color:";
            // 
            // lblBackColor
            // 
            this.lblBackColor.AutoSize = true;
            this.lblBackColor.Location = new System.Drawing.Point(3, 11);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(87, 20);
            this.lblBackColor.TabIndex = 8;
            this.lblBackColor.Text = "Back color:";
            // 
            // lblColorReturnPoint
            // 
            this.lblColorReturnPoint.AutoSize = true;
            this.lblColorReturnPoint.Location = new System.Drawing.Point(3, 131);
            this.lblColorReturnPoint.Name = "lblColorReturnPoint";
            this.lblColorReturnPoint.Size = new System.Drawing.Size(143, 20);
            this.lblColorReturnPoint.TabIndex = 11;
            this.lblColorReturnPoint.Text = "Switch colors after:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "iterations:";
            // 
            // TwoColorsWithReturnVisualizatorParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblColorReturnPoint);
            this.Controls.Add(this.lblSecondColor);
            this.Controls.Add(this.lblFirstColor);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.numericColorReturnPoint);
            this.Controls.Add(this.btnSecondColor);
            this.Controls.Add(this.btnFirstColor);
            this.Controls.Add(this.btnBackColor);
            this.Name = "TwoColorsWithReturnVisualizatorParametersControl";
            this.Size = new System.Drawing.Size(440, 322);
            ((System.ComponentModel.ISupportInitialize)(this.numericColorReturnPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnFirstColor;
        private System.Windows.Forms.Button btnSecondColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown numericColorReturnPoint;
        private System.Windows.Forms.Label lblSecondColor;
        private System.Windows.Forms.Label lblFirstColor;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Label lblColorReturnPoint;
        private System.Windows.Forms.Label label1;
    }
}
