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
            this.gbxParameters = new System.Windows.Forms.GroupBox();
            this.paramsControl = new FractalGenerator.ParametersControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxFractals = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxVisualizators = new System.Windows.Forms.ComboBox();
            this.gbxVisualizatorParameters = new System.Windows.Forms.GroupBox();
            this.visualizatorParametersControl = new FractalGenerator.VisualizatorParametersControl();
            this.drawingPanel = new FractalGenerator.DrawingPanel();
            this.gbxParameters.SuspendLayout();
            this.gbxVisualizatorParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(903, 708);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(311, 51);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartClick);
            // 
            // gbxParameters
            // 
            this.gbxParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxParameters.Controls.Add(this.paramsControl);
            this.gbxParameters.Location = new System.Drawing.Point(900, 54);
            this.gbxParameters.Name = "gbxParameters";
            this.gbxParameters.Size = new System.Drawing.Size(311, 428);
            this.gbxParameters.TabIndex = 5;
            this.gbxParameters.TabStop = false;
            this.gbxParameters.Text = "Parameters";
            // 
            // paramsControl
            // 
            this.paramsControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.paramsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramsControl.Location = new System.Drawing.Point(3, 22);
            this.paramsControl.Name = "paramsControl";
            this.paramsControl.Size = new System.Drawing.Size(305, 403);
            this.paramsControl.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(903, 765);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(311, 53);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxFractals
            // 
            this.cbxFractals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFractals.FormattingEnabled = true;
            this.cbxFractals.Location = new System.Drawing.Point(903, 13);
            this.cbxFractals.Name = "cbxFractals";
            this.cbxFractals.Size = new System.Drawing.Size(311, 28);
            this.cbxFractals.TabIndex = 7;
            this.cbxFractals.SelectedIndexChanged += new System.EventHandler(this.cbxFractals_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(903, 825);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(311, 53);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxVisualizators
            // 
            this.cbxVisualizators.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxVisualizators.FormattingEnabled = true;
            this.cbxVisualizators.Location = new System.Drawing.Point(903, 489);
            this.cbxVisualizators.Name = "cbxVisualizators";
            this.cbxVisualizators.Size = new System.Drawing.Size(308, 28);
            this.cbxVisualizators.TabIndex = 10;
            this.cbxVisualizators.SelectedIndexChanged += new System.EventHandler(this.cbxVisualizators_SelectedIndexChanged);
            // 
            // gbxVisualizatorParameters
            // 
            this.gbxVisualizatorParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxVisualizatorParameters.Controls.Add(this.visualizatorParametersControl);
            this.gbxVisualizatorParameters.Location = new System.Drawing.Point(900, 524);
            this.gbxVisualizatorParameters.Name = "gbxVisualizatorParameters";
            this.gbxVisualizatorParameters.Size = new System.Drawing.Size(314, 178);
            this.gbxVisualizatorParameters.TabIndex = 11;
            this.gbxVisualizatorParameters.TabStop = false;
            this.gbxVisualizatorParameters.Text = "Visualizator parameters";
            // 
            // visualizatorParametersControl
            // 
            this.visualizatorParametersControl.BackColor = System.Drawing.Color.Lime;
            this.visualizatorParametersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizatorParametersControl.Location = new System.Drawing.Point(3, 22);
            this.visualizatorParametersControl.Name = "visualizatorParametersControl";
            this.visualizatorParametersControl.Size = new System.Drawing.Size(308, 153);
            this.visualizatorParametersControl.TabIndex = 0;
            // 
            // drawingPanel
            // 
            this.drawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingPanel.Location = new System.Drawing.Point(12, 12);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(873, 865);
            this.drawingPanel.TabIndex = 8;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 889);
            this.Controls.Add(this.gbxVisualizatorParameters);
            this.Controls.Add(this.cbxVisualizators);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.cbxFractals);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxParameters);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(1245, 945);
            this.Name = "MainWindow";
            this.Text = "Fractal generator";
            this.gbxParameters.ResumeLayout(false);
            this.gbxVisualizatorParameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbxParameters;
        private System.Windows.Forms.Button btnCancel;
        private ParametersControl paramsControl;
        private System.Windows.Forms.ComboBox cbxFractals;
        private DrawingPanel drawingPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxVisualizators;
        private System.Windows.Forms.GroupBox gbxVisualizatorParameters;
        private VisualizatorParametersControl visualizatorParametersControl;
    }
}

