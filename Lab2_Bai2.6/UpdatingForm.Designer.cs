namespace QLSV_GUI
{
    partial class UpdatingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.classId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.math = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.physic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chemistry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sửa thông tin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 1;
            // 
            // classId
            // 
            this.classId.FormattingEnabled = true;
            this.classId.Items.AddRange(new object[] {
            "KTPM2022.1",
            "KTPM2022.2",
            "KTPM2022.3",
            "KTPM2022.4"});
            this.classId.Location = new System.Drawing.Point(276, 174);
            this.classId.Name = "classId";
            this.classId.Size = new System.Drawing.Size(320, 32);
            this.classId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lớp";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(276, 254);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(320, 29);
            this.name.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Họ và tên";
            // 
            // math
            // 
            this.math.Location = new System.Drawing.Point(200, 380);
            this.math.Name = "math";
            this.math.Size = new System.Drawing.Size(80, 29);
            this.math.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điểm toán:";
            // 
            // physic
            // 
            this.physic.Location = new System.Drawing.Point(439, 384);
            this.physic.Name = "physic";
            this.physic.Size = new System.Drawing.Size(80, 29);
            this.physic.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Điểm lý:";
            // 
            // chemistry
            // 
            this.chemistry.Location = new System.Drawing.Point(705, 384);
            this.chemistry.Name = "chemistry";
            this.chemistry.Size = new System.Drawing.Size(80, 29);
            this.chemistry.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(583, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Điểm hóa:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(251, 488);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(320, 46);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Cập nhật";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // UpdatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 754);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.chemistry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.physic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.math);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.classId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdatingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox classId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox math;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox physic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox chemistry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSubmit;
    }
}