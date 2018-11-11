namespace FractalGenerator.Visualisators
{
    partial class TwoColorsVisualizatorParametersControl
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
            this.lblBackColor = new System.Windows.Forms.Label();
            this.lblFirstColor = new System.Windows.Forms.Label();
            this.lblSecondColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSecondColor
            // 
            this.btnSecondColor.Location = new System.Drawing.Point(153, 92);
            this.btnSecondColor.Name = "btnSecondColor";
            this.btnSecondColor.Size = new System.Drawing.Size(41, 36);
            this.btnSecondColor.TabIndex = 2;
            this.btnSecondColor.UseVisualStyleBackColor = true;
            this.btnSecondColor.Click += new System.EventHandler(this.btnSecondColor_Click);
            // 
            // btnFirstColor
            // 
            this.btnFirstColor.Location = new System.Drawing.Point(153, 50);
            this.btnFirstColor.Name = "btnFirstColor";
            this.btnFirstColor.Size = new System.Drawing.Size(41, 36);
            this.btnFirstColor.TabIndex = 1;
            this.btnFirstColor.UseVisualStyleBackColor = true;
            this.btnFirstColor.Click += new System.EventHandler(this.btnFirstColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(153, 8);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(41, 36);
            this.btnBackColor.TabIndex = 0;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // lblBackColor
            // 
            this.lblBackColor.AutoSize = true;
            this.lblBackColor.Location = new System.Drawing.Point(3, 16);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(87, 20);
            this.lblBackColor.TabIndex = 3;
            this.lblBackColor.Text = "Back color:";
            // 
            // lblFirstColor
            // 
            this.lblFirstColor.AutoSize = true;
            this.lblFirstColor.Location = new System.Drawing.Point(3, 58);
            this.lblFirstColor.Name = "lblFirstColor";
            this.lblFirstColor.Size = new System.Drawing.Size(82, 20);
            this.lblFirstColor.TabIndex = 4;
            this.lblFirstColor.Text = "First color:";
            // 
            // lblSecondColor
            // 
            this.lblSecondColor.AutoSize = true;
            this.lblSecondColor.Location = new System.Drawing.Point(3, 100);
            this.lblSecondColor.Name = "lblSecondColor";
            this.lblSecondColor.Size = new System.Drawing.Size(106, 20);
            this.lblSecondColor.TabIndex = 5;
            this.lblSecondColor.Text = "Second color:";
            // 
            // TwoColorsVisualizatorParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSecondColor);
            this.Controls.Add(this.lblFirstColor);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.btnSecondColor);
            this.Controls.Add(this.btnFirstColor);
            this.Controls.Add(this.btnBackColor);
            this.Name = "TwoColorsVisualizatorParametersControl";
            this.Size = new System.Drawing.Size(440, 322);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnFirstColor;
        private System.Windows.Forms.Button btnSecondColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Label lblFirstColor;
        private System.Windows.Forms.Label lblSecondColor;
    }
}
