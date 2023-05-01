namespace OximeterServer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            oxiListPanel = new Panel();
            redrawTimer = new System.Windows.Forms.Timer(components);
            topPanel = new Panel();
            mimimizeButton = new Button();
            closeButton = new Button();
            exportButton = new Button();
            stopButton = new Button();
            recordButton = new Button();
            statusLabel = new Label();
            mainPanel = new Panel();
            toolTip = new ToolTip(components);
            exportMenu = new ContextMenuStrip(components);
            exportToExcelMenuItem = new ToolStripMenuItem();
            exportToCSVMenuItem = new ToolStripMenuItem();
            separator1 = new ToolStripSeparator();
            lastExportMenuItem = new ToolStripMenuItem();
            bottomPanel = new Panel();
            topPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            exportMenu.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // oxiListPanel
            // 
            oxiListPanel.Dock = DockStyle.Left;
            oxiListPanel.Location = new Point(0, 0);
            oxiListPanel.Margin = new Padding(4, 3, 4, 3);
            oxiListPanel.Name = "oxiListPanel";
            oxiListPanel.Size = new Size(460, 170);
            oxiListPanel.TabIndex = 0;
            // 
            // redrawTimer
            // 
            redrawTimer.Interval = 10;
            redrawTimer.Tick += redrawTimer_Tick;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(mimimizeButton);
            topPanel.Controls.Add(closeButton);
            topPanel.Controls.Add(exportButton);
            topPanel.Controls.Add(stopButton);
            topPanel.Controls.Add(recordButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(4, 3, 4, 3);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(460, 40);
            topPanel.TabIndex = 1;
            topPanel.MouseMove += topPanel_MouseMove;
            // 
            // mimimizeButton
            // 
            mimimizeButton.Dock = DockStyle.Right;
            mimimizeButton.FlatAppearance.BorderSize = 0;
            mimimizeButton.FlatStyle = FlatStyle.Flat;
            mimimizeButton.Image = (Image)resources.GetObject("mimimizeButton.Image");
            mimimizeButton.Location = new Point(380, 0);
            mimimizeButton.Margin = new Padding(4, 3, 4, 3);
            mimimizeButton.Name = "mimimizeButton";
            mimimizeButton.Size = new Size(40, 40);
            mimimizeButton.TabIndex = 6;
            toolTip.SetToolTip(mimimizeButton, "Minimize");
            mimimizeButton.UseVisualStyleBackColor = true;
            mimimizeButton.Click += mimimizeButton_Click;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Image = (Image)resources.GetObject("closeButton.Image");
            closeButton.Location = new Point(420, 0);
            closeButton.Margin = new Padding(4, 3, 4, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(40, 40);
            closeButton.TabIndex = 5;
            toolTip.SetToolTip(closeButton, "Close");
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // exportButton
            // 
            exportButton.Dock = DockStyle.Left;
            exportButton.Enabled = false;
            exportButton.FlatAppearance.BorderSize = 0;
            exportButton.FlatStyle = FlatStyle.Flat;
            exportButton.Image = (Image)resources.GetObject("exportButton.Image");
            exportButton.Location = new Point(80, 0);
            exportButton.Margin = new Padding(4, 3, 4, 3);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(40, 40);
            exportButton.TabIndex = 4;
            toolTip.SetToolTip(exportButton, "Export data");
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // stopButton
            // 
            stopButton.Dock = DockStyle.Left;
            stopButton.Enabled = false;
            stopButton.FlatAppearance.BorderSize = 0;
            stopButton.FlatStyle = FlatStyle.Flat;
            stopButton.Image = (Image)resources.GetObject("stopButton.Image");
            stopButton.Location = new Point(40, 0);
            stopButton.Margin = new Padding(4, 3, 4, 3);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(40, 40);
            stopButton.TabIndex = 1;
            toolTip.SetToolTip(stopButton, "Stop Recording");
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // recordButton
            // 
            recordButton.Dock = DockStyle.Left;
            recordButton.FlatAppearance.BorderSize = 0;
            recordButton.FlatStyle = FlatStyle.Flat;
            recordButton.Image = (Image)resources.GetObject("recordButton.Image");
            recordButton.Location = new Point(0, 0);
            recordButton.Margin = new Padding(4, 3, 4, 3);
            recordButton.Name = "recordButton";
            recordButton.Size = new Size(40, 40);
            recordButton.TabIndex = 0;
            toolTip.SetToolTip(recordButton, "Start Recording");
            recordButton.UseVisualStyleBackColor = true;
            recordButton.Click += recordButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoEllipsis = true;
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statusLabel.ForeColor = Color.FromArgb(168, 168, 168);
            statusLabel.Location = new Point(0, 0);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(12, 0, 0, 0);
            statusLabel.Size = new Size(460, 40);
            statusLabel.TabIndex = 7;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.MouseDown += statusLabel_MouseDown;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(oxiListPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 40);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(460, 170);
            mainPanel.TabIndex = 2;
            // 
            // exportMenu
            // 
            exportMenu.Items.AddRange(new ToolStripItem[] { exportToExcelMenuItem, exportToCSVMenuItem, separator1, lastExportMenuItem });
            exportMenu.Name = "exportMenu";
            exportMenu.Size = new Size(153, 76);
            // 
            // exportToExcelMenuItem
            // 
            exportToExcelMenuItem.Name = "exportToExcelMenuItem";
            exportToExcelMenuItem.Size = new Size(152, 22);
            exportToExcelMenuItem.Text = "Export to Excel";
            exportToExcelMenuItem.Click += exportToExcelMenuItem_Click;
            // 
            // exportToCSVMenuItem
            // 
            exportToCSVMenuItem.Name = "exportToCSVMenuItem";
            exportToCSVMenuItem.Size = new Size(152, 22);
            exportToCSVMenuItem.Text = "Export to CSV";
            exportToCSVMenuItem.Click += exportToCSVMenuItem_Click;
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(149, 6);
            // 
            // lastExportMenuItem
            // 
            lastExportMenuItem.Enabled = false;
            lastExportMenuItem.Name = "lastExportMenuItem";
            lastExportMenuItem.Size = new Size(152, 22);
            lastExportMenuItem.Text = "No last export";
            lastExportMenuItem.Click += lastExportMenuItem_Click;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(statusLabel);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 210);
            bottomPanel.Margin = new Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(460, 40);
            bottomPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(460, 250);
            Controls.Add(mainPanel);
            Controls.Add(topPanel);
            Controls.Add(bottomPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(460, 250);
            MinimumSize = new Size(460, 250);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oximeter Server";
            FormClosing += MainForm_FormClosing;
            topPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            exportMenu.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel oxiListPanel;
        private System.Windows.Forms.Timer redrawTimer;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.ToolTip toolTip;
        private Button closeButton;
        private Button mimimizeButton;
        private ContextMenuStrip exportMenu;
        private ToolStripMenuItem exportToExcelMenuItem;
        private ToolStripMenuItem exportToCSVMenuItem;
        private Label statusLabel;
        private Panel bottomPanel;
        private ToolStripSeparator separator1;
        private ToolStripMenuItem lastExportMenuItem;
    }
}