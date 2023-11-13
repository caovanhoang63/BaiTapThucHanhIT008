using QLSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_GUI
{
    public partial class AddingForm : Form
    {
        public AddingForm()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkEmptyField())
                {
                    MessageBox.Show("Vui lòng điền tất cả các thông tin!");
                    return;
                }
                float toan = float.Parse(math.Text);
                float ly = float.Parse(physic.Text);
                float hoa = float.Parse(chemistry.Text);
                float dtb = (toan + ly + hoa) / 3;

                int classID = Program.quanly.ConvertMaLop(classId.Text);

                SinhVien sinhvien = new SinhVien(id.Text, name.Text, classID.ToString(),
                    toan, ly, hoa, dtb);
                if (Program.quanly.Add(sinhvien))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetForm();
                } else
                {
                    MessageBox.Show("Thêm thất bại!");
                }

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Điểm không hợp lệ!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Mssv đã tồn tại!");
            }

        }

        private bool checkEmptyField()
        {
            if (math.Text == string.Empty || physic.Text == string.Empty ||
                chemistry.Text == string.Empty || name.Text == string.Empty ||
                classId.Text == string.Empty || id.Text == string.Empty)
            {
                return false; 
            }
            return true;
        }

        private void ResetForm()
        {
            math.Text = string.Empty;
            physic.Text = string.Empty;
            chemistry.Text = string.Empty;
            id.Text = string.Empty;
            name.Text = string.Empty;   
            classId.Text = string.Empty;
        }



        private void classId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (classId.DroppedDown == true)
                    classId.DroppedDown = false;
                else
                    classId.DroppedDown = true;
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
