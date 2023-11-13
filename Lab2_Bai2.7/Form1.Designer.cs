namespace Lab2_Bai2._7
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nmGio = new System.Windows.Forms.NumericUpDown();
            this.nmGiay = new System.Windows.Forms.NumericUpDown();
            this.nmPhut = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonShutDown = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPhut)).BeginInit();
            this.SuspendLayout();
            // 
            // nmGio
            // 
            resources.ApplyResources(this.nmGio, "nmGio");
            this.nmGio.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.nmGio.Name = "nmGio";
            this.nmGio.ValueChanged += new System.EventHandler(this.nmGio_ValueChanged);
            // 
            // nmGiay
            // 
            resources.ApplyResources(this.nmGiay, "nmGiay");
            this.nmGiay.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.nmGiay.Name = "nmGiay";
            this.nmGiay.ValueChanged += new System.EventHandler(this.nmGiay_ValueChanged);
            // 
            // nmPhut
            // 
            resources.ApplyResources(this.nmPhut, "nmPhut");
            this.nmPhut.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.nmPhut.Name = "nmPhut";
            this.nmPhut.ValueChanged += new System.EventHandler(this.nmPhut_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // buttonShutDown
            // 
            resources.ApplyResources(this.buttonShutDown, "buttonShutDown");
            this.buttonShutDown.Name = "buttonShutDown";
            this.buttonShutDown.UseVisualStyleBackColor = true;
            this.buttonShutDown.Click += new System.EventHandler(this.buttonShutDown_Click);
            // 
            // buttonRestart
            // 
            resources.ApplyResources(this.buttonRestart, "buttonRestart");
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonShutDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmPhut);
            this.Controls.Add(this.nmGiay);
            this.Controls.Add(this.nmGio);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nmGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPhut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmGio;
        private System.Windows.Forms.NumericUpDown nmGiay;
        private System.Windows.Forms.NumericUpDown nmPhut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonShutDown;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Timer timer1;
    }
}

