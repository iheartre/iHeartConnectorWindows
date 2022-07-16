namespace OximeterControls
{
    partial class OximeterPanel
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
            this.separator = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.pulsePanel = new System.Windows.Forms.Panel();
            this.pulseLabel = new System.Windows.Forms.Label();
            this.pulseTitleLabel = new System.Windows.Forms.Label();
            this.spO2Panel = new System.Windows.Forms.Panel();
            this.spO2Label = new System.Windows.Forms.Label();
            this.spO2TitleLabel = new System.Windows.Forms.Label();
            this.macLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.pulsePanel.SuspendLayout();
            this.spO2Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.separator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator.Location = new System.Drawing.Point(0, 89);
            this.separator.Margin = new System.Windows.Forms.Padding(4);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(500, 1);
            this.separator.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.chartPanel);
            this.mainPanel.Controls.Add(this.dataPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(500, 89);
            this.mainPanel.TabIndex = 1;
            // 
            // chartPanel
            // 
            this.chartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel.Location = new System.Drawing.Point(150, 0);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(350, 89);
            this.chartPanel.TabIndex = 2;
            this.chartPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chartPanel_Paint);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.pulsePanel);
            this.dataPanel.Controls.Add(this.spO2Panel);
            this.dataPanel.Controls.Add(this.panel1);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataPanel.Location = new System.Drawing.Point(0, 0);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(150, 89);
            this.dataPanel.TabIndex = 0;
            // 
            // pulsePanel
            // 
            this.pulsePanel.Controls.Add(this.pulseLabel);
            this.pulsePanel.Controls.Add(this.pulseTitleLabel);
            this.pulsePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulsePanel.Location = new System.Drawing.Point(75, 0);
            this.pulsePanel.Name = "pulsePanel";
            this.pulsePanel.Padding = new System.Windows.Forms.Padding(5);
            this.pulsePanel.Size = new System.Drawing.Size(75, 66);
            this.pulsePanel.TabIndex = 1;
            // 
            // pulseLabel
            // 
            this.pulseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pulseLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pulseLabel.Location = new System.Drawing.Point(5, 25);
            this.pulseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(65, 37);
            this.pulseLabel.TabIndex = 2;
            this.pulseLabel.Text = "‒";
            this.pulseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pulseTitleLabel
            // 
            this.pulseTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pulseTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pulseTitleLabel.Location = new System.Drawing.Point(5, 5);
            this.pulseTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulseTitleLabel.Name = "pulseTitleLabel";
            this.pulseTitleLabel.Size = new System.Drawing.Size(65, 20);
            this.pulseTitleLabel.TabIndex = 1;
            this.pulseTitleLabel.Text = "Pulse";
            // 
            // spO2Panel
            // 
            this.spO2Panel.Controls.Add(this.spO2Label);
            this.spO2Panel.Controls.Add(this.spO2TitleLabel);
            this.spO2Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.spO2Panel.Location = new System.Drawing.Point(0, 0);
            this.spO2Panel.Margin = new System.Windows.Forms.Padding(4);
            this.spO2Panel.Name = "spO2Panel";
            this.spO2Panel.Padding = new System.Windows.Forms.Padding(5);
            this.spO2Panel.Size = new System.Drawing.Size(75, 66);
            this.spO2Panel.TabIndex = 0;
            // 
            // spO2Label
            // 
            this.spO2Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.spO2Label.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spO2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.spO2Label.Location = new System.Drawing.Point(5, 25);
            this.spO2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spO2Label.Name = "spO2Label";
            this.spO2Label.Size = new System.Drawing.Size(65, 37);
            this.spO2Label.TabIndex = 1;
            this.spO2Label.Text = "‒";
            this.spO2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spO2TitleLabel
            // 
            this.spO2TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.spO2TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.spO2TitleLabel.Location = new System.Drawing.Point(5, 5);
            this.spO2TitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spO2TitleLabel.Name = "spO2TitleLabel";
            this.spO2TitleLabel.Size = new System.Drawing.Size(65, 20);
            this.spO2TitleLabel.TabIndex = 0;
            this.spO2TitleLabel.Text = "SpO₂";
            // 
            // macLabel
            // 
            this.macLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macLabel.ForeColor = System.Drawing.Color.Orange;
            this.macLabel.Location = new System.Drawing.Point(0, 0);
            this.macLabel.Name = "macLabel";
            this.macLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.macLabel.Size = new System.Drawing.Size(125, 23);
            this.macLabel.TabIndex = 2;
            this.macLabel.Text = "‒";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.macLabel);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 23);
            this.panel1.TabIndex = 3;
            // 
            // idLabel
            // 
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.idLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.idLabel.Location = new System.Drawing.Point(125, 0);
            this.idLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(25, 23);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "-";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OximeterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.separator);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OximeterPanel";
            this.Size = new System.Drawing.Size(500, 90);
            this.mainPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            this.pulsePanel.ResumeLayout(false);
            this.spO2Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel pulsePanel;
        private System.Windows.Forms.Label pulseLabel;
        private System.Windows.Forms.Label pulseTitleLabel;
        private System.Windows.Forms.Panel spO2Panel;
        private System.Windows.Forms.Label spO2Label;
        private System.Windows.Forms.Label spO2TitleLabel;
        private System.Windows.Forms.Label macLabel;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label idLabel;
    }
}
