using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lytes
{
    public partial class InputDialog : Form
    {
        private string text;

        public InputDialog() {
            InitializeComponent();
            text = "";
        }

        public string InputText {
            get { return text; }
        }

        public string maxLevel {
            set { this.maxLevelLabel.Text = value; }
        }

        private void okButton_MouseClick(object sender, MouseEventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.text = textBox.Text;
            this.Dispose();
        }

        private void cancelButton_MouseClick(object sender, MouseEventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.text = "";
            this.Dispose();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) {
            string inputText = this.textBox.Text;
            if (string.IsNullOrEmpty(inputText)) {
                this.okButton.Enabled = false;
            } else {
                try {
                    Convert.ToInt32(inputText);
                } catch (System.FormatException) {
                    this.okButton.Enabled = false;
                }
            }
            this.okButton.Enabled = true;
        }
    }
}
