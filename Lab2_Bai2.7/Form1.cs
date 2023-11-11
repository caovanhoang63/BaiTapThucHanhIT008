using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab2_Bai2._7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadStatusBar();
        }
        decimal downTime=0;
        StatusBarPanel barPanel = new StatusBarPanel();
        StatusBarPanel downTimePanel = new StatusBarPanel();

        void LoadStatusBar()
        {
            StatusBar bar = new StatusBar();
            bar.ShowPanels = true;
            bar.Panels.Add(barPanel);
            bar.Panels.Add(downTimePanel);
            barPanel.Text = "Waiting...";
            downTimePanel.Text = "";
            this.Controls.Add(bar);
        }

        private void nmGiay_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown box = sender as NumericUpDown;
            
            while (box.Value >= 60) 
            {
                nmPhut.Value++;
                box.Value -= 60;
            }
        }

        private void nmPhut_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown box = sender as NumericUpDown;

            if (box.Value >= 60)
            {
                nmGio.Value++;
                box.Value -= 60;
            }

        }

        void ShutDown(string command)
        {
            System.Diagnostics.Process.Start("shutdown",command);
        }

        void calculateDownTime()
        {
            downTime = nmGiay.Value + nmPhut.Value * 60 + nmGio.Value * 3600;
        }
        private void buttonShutDown_Click(object sender, EventArgs e)
        {
            calculateDownTime();
            ShutDown("-s -t " + downTime.ToString());
            barPanel.Text = "Shutting down...";
            timer1.Start();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            calculateDownTime();
            ShutDown("-r -t " + downTime.ToString());
            barPanel.Text = "Restarting...";
            timer1.Start();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ShutDown("-a");
            nmGio.Value = 0;
            nmGiay.Value = 0;
            nmPhut.Value = 0;
            barPanel.Text = "Waiting...";
            timer1.Stop();
            downTimePanel.Text = "";
        }

        private void nmGio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            downTime--;
            downTimePanel.Text= downTime.ToString();
        }
       
    }
}
