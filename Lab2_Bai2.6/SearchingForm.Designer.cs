namespace QLSV_GUI
{
    partial class SearchingForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.studentID = new System.Windows.Forms.TextBox();
            this.studentName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.resultListVieew = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.math = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.physic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chemistry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notFoundLabel = new System.Windows.Forms.Label();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã số sinh viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ và tên:";
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(260, 131);
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(493, 29);
            this.studentID.TabIndex = 3;
            // 
            // studentName
            // 
            this.studentName.Location = new System.Drawing.Point(260, 198);
            this.studentName.Name = "studentName";
            this.studentName.Size = new System.Drawing.Size(493, 29);
            this.studentName.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultListVieew
            // 
            this.resultListVieew.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.math,
            this.physic,
            this.chemistry});
            this.resultListVieew.HideSelection = false;
            this.resultListVieew.Location = new System.Drawing.Point(106, 382);
            this.resultListVieew.Name = "resultListVieew";
            this.resultListVieew.Size = new System.Drawing.Size(734, 272);
            this.resultListVieew.TabIndex = 6;
            this.resultListVieew.UseCompatibleStateImageBehavior = false;
            this.resultListVieew.View = System.Windows.Forms.View.Details;
            this.resultListVieew.Visible = false;
            // 
            // id
            // 
            this.id.Text = "Mssv";
            this.id.Width = 83;
            // 
            // name
            // 
            this.name.Text = "Họ và tên";
            this.name.Width = 104;
            // 
            // math
            // 
            this.math.Text = "Toán";
            this.math.Width = 75;
            // 
            // physic
            // 
            this.physic.Text = "Lý";
            this.physic.Width = 59;
            // 
            // chemistry
            // 
            this.chemistry.Text = "Hóa";
            this.chemistry.Width = 74;
            // 
            // notFoundLabel
            // 
            this.notFoundLabel.AutoSize = true;
            this.notFoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notFoundLabel.Location = new System.Drawing.Point(225, 480);
            this.notFoundLabel.Name = "notFoundLabel";
            this.notFoundLabel.Size = new System.Drawing.Size(474, 48);
            this.notFoundLabel.TabIndex = 7;
            this.notFoundLabel.Text = "Không tim thấy sinh viên";
            this.notFoundLabel.Visible = false;
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.Location = new System.Drawing.Point(329, 693);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(242, 71);
            this.btnUpdateStudent.TabIndex = 8;
            this.btnUpdateStudent.Text = "Sửa thông tin";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Visible = false;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // SearchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 807);
            this.Controls.Add(this.btnUpdateStudent);
            this.Controls.Add(this.notFoundLabel);
            this.Controls.Add(this.resultListVieew);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "SearchingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchingForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchingForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView resultListVieew;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader math;
        private System.Windows.Forms.ColumnHeader physic;
        private System.Windows.Forms.ColumnHeader chemistry;
        private System.Windows.Forms.Label notFoundLabel;
        private System.Windows.Forms.Button btnUpdateStudent;
    }
}