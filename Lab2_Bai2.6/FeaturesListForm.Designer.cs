namespace QLSV_GUI
{
    partial class FeaturesListForm
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
            this.btnAddNewStudent = new System.Windows.Forms.Button();
            this.btnSearchStudent = new System.Windows.Forms.Button();
            this.btnDeletingStudent = new System.Windows.Forms.Button();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.btnShowClassList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách tính năng";
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.Location = new System.Drawing.Point(112, 159);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(242, 71);
            this.btnAddNewStudent.TabIndex = 1;
            this.btnAddNewStudent.Text = "Nhập sinh viên";
            this.btnAddNewStudent.UseVisualStyleBackColor = true;
            this.btnAddNewStudent.Click += new System.EventHandler(this.btnAddNewStudent_Click);
            // 
            // btnSearchStudent
            // 
            this.btnSearchStudent.Location = new System.Drawing.Point(112, 258);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(242, 71);
            this.btnSearchStudent.TabIndex = 2;
            this.btnSearchStudent.Text = "Tìm sinh viên";
            this.btnSearchStudent.UseVisualStyleBackColor = true;
            this.btnSearchStudent.Click += new System.EventHandler(this.btnSearchStudent_Click);
            // 
            // btnDeletingStudent
            // 
            this.btnDeletingStudent.Location = new System.Drawing.Point(112, 364);
            this.btnDeletingStudent.Name = "btnDeletingStudent";
            this.btnDeletingStudent.Size = new System.Drawing.Size(242, 71);
            this.btnDeletingStudent.TabIndex = 3;
            this.btnDeletingStudent.Text = "Xóa sinh viên";
            this.btnDeletingStudent.UseVisualStyleBackColor = true;
            this.btnDeletingStudent.Click += new System.EventHandler(this.btnDeletingStudent_Click);
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.Location = new System.Drawing.Point(112, 471);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(242, 71);
            this.btnUpdateStudent.TabIndex = 5;
            this.btnUpdateStudent.Text = "Sửa thông tin";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnShowClassList
            // 
            this.btnShowClassList.Location = new System.Drawing.Point(112, 587);
            this.btnShowClassList.Name = "btnShowClassList";
            this.btnShowClassList.Size = new System.Drawing.Size(242, 71);
            this.btnShowClassList.TabIndex = 6;
            this.btnShowClassList.Text = "Xem danh sách lớp";
            this.btnShowClassList.UseVisualStyleBackColor = true;
            this.btnShowClassList.Click += new System.EventHandler(this.btnShowClassList_Click);
            // 
            // FeaturesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 720);
            this.Controls.Add(this.btnShowClassList);
            this.Controls.Add(this.btnUpdateStudent);
            this.Controls.Add(this.btnDeletingStudent);
            this.Controls.Add(this.btnSearchStudent);
            this.Controls.Add(this.btnAddNewStudent);
            this.Controls.Add(this.label1);
            this.Name = "FeaturesListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeaturesListForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FeaturesListForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewStudent;
        private System.Windows.Forms.Button btnSearchStudent;
        private System.Windows.Forms.Button btnDeletingStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnShowClassList;
    }
}