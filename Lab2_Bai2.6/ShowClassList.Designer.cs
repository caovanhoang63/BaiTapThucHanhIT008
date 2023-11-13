namespace QLSV_GUI
{
    partial class ShowClassList
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
            this.resultListVieew = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.math = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.physic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chemistry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.classId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.resultListVieew.Location = new System.Drawing.Point(93, 385);
            this.resultListVieew.Name = "resultListVieew";
            this.resultListVieew.Size = new System.Drawing.Size(734, 272);
            this.resultListVieew.TabIndex = 7;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh sách lớp";
            // 
            // classId
            // 
            this.classId.FormattingEnabled = true;
            this.classId.Items.AddRange(new object[] {
            "KTPM2022.1",
            "KTPM2022.2",
            "KTPM2022.3",
            "KTPM2022.4"});
            this.classId.Location = new System.Drawing.Point(296, 169);
            this.classId.Name = "classId";
            this.classId.Size = new System.Drawing.Size(320, 32);
            this.classId.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lớp";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(326, 251);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(263, 53);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Tìm";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ShowClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 759);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.classId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultListVieew);
            this.Name = "ShowClassList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowClassList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resultListVieew;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader math;
        private System.Windows.Forms.ColumnHeader physic;
        private System.Windows.Forms.ColumnHeader chemistry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox classId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
    }
}