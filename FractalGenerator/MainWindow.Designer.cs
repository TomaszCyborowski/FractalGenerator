namespace FractalGenerator
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.numericStopValue = new System.Windows.Forms.NumericUpDown();
            this.lblStopValue = new System.Windows.Forms.Label();
            this.bgxParameters = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericStopValue)).BeginInit();
            this.bgxParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(900, 749);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(311, 51);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartClick);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(12, 12);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(863, 866);
            this.drawingPanel.TabIndex = 2;
            // 
            // numericStopValue
            // 
            this.numericStopValue.DecimalPlaces = 2;
            this.numericStopValue.Location = new System.Drawing.Point(176, 30);
            this.numericStopValue.Name = "numericStopValue";
            this.numericStopValue.Size = new System.Drawing.Size(120, 26);
            this.numericStopValue.TabIndex = 3;
            this.numericStopValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblStopValue
            // 
            this.lblStopValue.AutoSize = true;
            this.lblStopValue.Location = new System.Drawing.Point(16, 36);
            this.lblStopValue.Name = "lblStopValue";
            this.lblStopValue.Size = new System.Drawing.Size(88, 20);
            this.lblStopValue.TabIndex = 4;
            this.lblStopValue.Text = "Stop value:";
            // 
            // bgxParameters
            // 
            this.bgxParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bgxParameters.Controls.Add(this.lblStopValue);
            this.bgxParameters.Controls.Add(this.numericStopValue);
            this.bgxParameters.Location = new System.Drawing.Point(900, 12);
            this.bgxParameters.Name = "bgxParameters";
            this.bgxParameters.Size = new System.Drawing.Size(311, 718);
            this.bgxParameters.TabIndex = 5;
            this.bgxParameters.TabStop = false;
            this.bgxParameters.Text = "Parameters";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(900, 807);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(311, 53);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 889);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bgxParameters);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(1245, 945);
            this.Name = "MainWindow";
            this.Text = "Fractal generator";
            ((System.ComponentModel.ISupportInitialize)(this.numericStopValue)).EndInit();
            this.bgxParameters.ResumeLayout(false);
            this.bgxParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.NumericUpDown numericStopValue;
        private System.Windows.Forms.Label lblStopValue;
        private System.Windows.Forms.GroupBox bgxParameters;
        private System.Windows.Forms.Button btnCancel;
    }
}

