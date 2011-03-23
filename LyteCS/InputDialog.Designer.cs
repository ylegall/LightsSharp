namespace Lytes
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Button cancelButton;
            this.okButton = new System.Windows.Forms.Button();
            this.maxLevelLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(148, 13);
            label1.TabIndex = 0;
            label1.Text = "Select a level between 1 and ";
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(97, 55);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cancelButton_MouseClick);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 55);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.okButton_MouseClick);
            // 
            // maxLevelLabel
            // 
            this.maxLevelLabel.AutoSize = true;
            this.maxLevelLabel.Location = new System.Drawing.Point(159, 13);
            this.maxLevelLabel.Name = "maxLevelLabel";
            this.maxLevelLabel.Size = new System.Drawing.Size(13, 13);
            this.maxLevelLabel.TabIndex = 1;
            this.maxLevelLabel.Text = "1";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 29);
            this.textBox.MaxLength = 4;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 2;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 91);
            this.Controls.Add(cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.maxLevelLabel);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputDialog";
            this.Text = "Level Select";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        internal System.Windows.Forms.Label maxLevelLabel;
        private System.Windows.Forms.Button okButton;

    }
}