using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Text;
using System.Windows.Forms;

namespace Lytes
{
    public partial class Toast : Form
    {
        private const double FADE_AMOUNT = 0.05;
        private const double INTERVAL = 50;
        private System.Timers.Timer fadeTimer;


        public Toast(string text, double initialDelay=1000) {
            InitializeComponent();
            messageLabel.Text = text;
            fadeTimer = new System.Timers.Timer(initialDelay);
            fadeTimer.Elapsed += new ElapsedEventHandler(fadeTimer_Begin);
        }

        private void Toast_Shown(object sender, EventArgs e) {
            fadeTimer.Start();
        }

        private void fadeTimer_Begin(Object sender, ElapsedEventArgs eea) {
            fadeTimer.Stop();
            fadeTimer.Elapsed -= new ElapsedEventHandler(fadeTimer_Begin);
            fadeTimer.Elapsed += new ElapsedEventHandler(fadeTimer_Elapsed);
            fadeTimer.Interval = INTERVAL;
            fadeTimer.Start();
        }

        private void fadeTimer_Elapsed(Object sender, ElapsedEventArgs eea) {
            this.Invoke((MethodInvoker)delegate() {
                this.Opacity -= FADE_AMOUNT;
                if (Opacity <= 0) {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                    this.Dispose();
                }
                Invalidate();
            });


        }
    }
}
