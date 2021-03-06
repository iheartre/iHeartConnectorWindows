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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.oxiListPanel = new System.Windows.Forms.Panel();
            this.redrawTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.mimimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.exportMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCSVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lastExportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.exportMenu.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // oxiListPanel
            // 
            this.oxiListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.oxiListPanel.Location = new System.Drawing.Point(0, 0);
            this.oxiListPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.oxiListPanel.Name = "oxiListPanel";
            this.oxiListPanel.Size = new System.Drawing.Size(460, 88);
            this.oxiListPanel.TabIndex = 0;
            // 
            // redrawTimer
            // 
            this.redrawTimer.Interval = 10;
            this.redrawTimer.Tick += new System.EventHandler(this.redrawTimer_Tick);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.mimimizeButton);
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Controls.Add(this.exportButton);
            this.topPanel.Controls.Add(this.stopButton);
            this.topPanel.Controls.Add(this.recordButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(460, 40);
            this.topPanel.TabIndex = 1;
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // mimimizeButton
            // 
            this.mimimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.mimimizeButton.FlatAppearance.BorderSize = 0;
            this.mimimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mimimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("mimimizeButton.Image")));
            this.mimimizeButton.Location = new System.Drawing.Point(380, 0);
            this.mimimizeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mimimizeButton.Name = "mimimizeButton";
            this.mimimizeButton.Size = new System.Drawing.Size(40, 40);
            this.mimimizeButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.mimimizeButton, "Minimize");
            this.mimimizeButton.UseVisualStyleBackColor = true;
            this.mimimizeButton.Click += new System.EventHandler(this.mimimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(420, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(40, 40);
            this.closeButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.closeButton, "Close");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.exportButton.Enabled = false;
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Image = ((System.Drawing.Image)(resources.GetObject("exportButton.Image")));
            this.exportButton.Location = new System.Drawing.Point(80, 0);
            this.exportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(40, 40);
            this.exportButton.TabIndex = 4;
            this.toolTip.SetToolTip(this.exportButton, "Export data");
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.stopButton.Enabled = false;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.Location = new System.Drawing.Point(40, 0);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(40, 40);
            this.stopButton.TabIndex = 1;
            this.toolTip.SetToolTip(this.stopButton, "Stop Recording");
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.recordButton.FlatAppearance.BorderSize = 0;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordButton.Image = ((System.Drawing.Image)(resources.GetObject("recordButton.Image")));
            this.recordButton.Location = new System.Drawing.Point(0, 0);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(40, 40);
            this.recordButton.TabIndex = 0;
            this.toolTip.SetToolTip(this.recordButton, "Start Recording");
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.statusLabel.Size = new System.Drawing.Size(460, 40);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.statusLabel_MouseDown);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.oxiListPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 40);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(460, 88);
            this.mainPanel.TabIndex = 2;
            // 
            // exportMenu
            // 
            this.exportMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelMenuItem,
            this.exportToCSVMenuItem,
            this.separator1,
            this.lastExportMenuItem});
            this.exportMenu.Name = "exportMenu";
            this.exportMenu.Size = new System.Drawing.Size(153, 76);
            // 
            // exportToExcelMenuItem
            // 
            this.exportToExcelMenuItem.Name = "exportToExcelMenuItem";
            this.exportToExcelMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToExcelMenuItem.Text = "Export to Excel";
            this.exportToExcelMenuItem.Click += new System.EventHandler(this.exportToExcelMenuItem_Click);
            // 
            // exportToCSVMenuItem
            // 
            this.exportToCSVMenuItem.Name = "exportToCSVMenuItem";
            this.exportToCSVMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToCSVMenuItem.Text = "Export to CSV";
            this.exportToCSVMenuItem.Click += new System.EventHandler(this.exportToCSVMenuItem_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(149, 6);
            // 
            // lastExportMenuItem
            // 
            this.lastExportMenuItem.Enabled = false;
            this.lastExportMenuItem.Name = "lastExportMenuItem";
            this.lastExportMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lastExportMenuItem.Text = "No last export";
            this.lastExportMenuItem.Click += new System.EventHandler(this.lastExportMenuItem_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.statusLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 128);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(460, 40);
            this.bottomPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(460, 168);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 168);
            this.MinimumSize = new System.Drawing.Size(460, 168);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oximeter Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.topPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.exportMenu.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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