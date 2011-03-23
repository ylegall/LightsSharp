namespace Lytes
{
    partial class MainForm
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
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
            System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
            System.Windows.Forms.ToolStripMenuItem loadGameMenuItem;
            System.Windows.Forms.ToolStripMenuItem quitMenuItem;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.currentLevelLabel = new System.Windows.Forms.Label();
            this.totalClicksLabel = new System.Windows.Forms.Label();
            this.parLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem1});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(384, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newGameMenuItem,
            loadGameMenuItem,
            this.toolStripSeparator1,
            quitMenuItem});
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            toolStripMenuItem1.Text = "Menu";
            // 
            // newGameMenuItem
            // 
            newGameMenuItem.Name = "newGameMenuItem";
            newGameMenuItem.Size = new System.Drawing.Size(134, 22);
            newGameMenuItem.Text = "New Game";
            newGameMenuItem.Click += new System.EventHandler(this.newGameMenuItem_Click);
            // 
            // loadGameMenuItem
            // 
            loadGameMenuItem.Name = "loadGameMenuItem";
            loadGameMenuItem.Size = new System.Drawing.Size(134, 22);
            loadGameMenuItem.Text = "Load Game";
            loadGameMenuItem.Click += new System.EventHandler(this.loadGameMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // quitMenuItem
            // 
            quitMenuItem.Name = "quitMenuItem";
            quitMenuItem.Size = new System.Drawing.Size(134, 22);
            quitMenuItem.Text = "Quit";
            quitMenuItem.Click += new System.EventHandler(this.quitMenuItem_Click);
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 361);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 13);
            label1.TabIndex = 4;
            label1.Text = "Current Level:";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 378);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 13);
            label3.TabIndex = 6;
            label3.Text = "Total Clicks:";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(296, 361);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(26, 13);
            label2.TabIndex = 9;
            label2.Text = "Par:";
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridPanel.BackColor = System.Drawing.SystemColors.Control;
            this.gridPanel.Location = new System.Drawing.Point(12, 28);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(360, 326);
            this.gridPanel.TabIndex = 3;
            this.gridPanel.SizeChanged += new System.EventHandler(this.gridPanel_SizeChanged);
            // 
            // currentLevelLabel
            // 
            this.currentLevelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentLevelLabel.AutoSize = true;
            this.currentLevelLabel.Location = new System.Drawing.Point(90, 361);
            this.currentLevelLabel.Name = "currentLevelLabel";
            this.currentLevelLabel.Size = new System.Drawing.Size(13, 13);
            this.currentLevelLabel.TabIndex = 5;
            this.currentLevelLabel.Text = "0";
            // 
            // totalClicksLabel
            // 
            this.totalClicksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalClicksLabel.AutoSize = true;
            this.totalClicksLabel.Location = new System.Drawing.Point(90, 378);
            this.totalClicksLabel.Name = "totalClicksLabel";
            this.totalClicksLabel.Size = new System.Drawing.Size(13, 13);
            this.totalClicksLabel.TabIndex = 7;
            this.totalClicksLabel.Text = "0";
            // 
            // parLabel
            // 
            this.parLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.parLabel.AutoSize = true;
            this.parLabel.Location = new System.Drawing.Point(337, 361);
            this.parLabel.Name = "parLabel";
            this.parLabel.Size = new System.Drawing.Size(13, 13);
            this.parLabel.TabIndex = 8;
            this.parLabel.Text = "0";
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(297, 378);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 10;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetButton_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 412);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(label2);
            this.Controls.Add(this.parLabel);
            this.Controls.Add(this.totalClicksLabel);
            this.Controls.Add(label3);
            this.Controls.Add(this.currentLevelLabel);
            this.Controls.Add(label1);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = menuStrip1;
            this.Name = "MainForm";
            this.Text = "Lytes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Label currentLevelLabel;
        private System.Windows.Forms.Label totalClicksLabel;
        private System.Windows.Forms.Label parLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

