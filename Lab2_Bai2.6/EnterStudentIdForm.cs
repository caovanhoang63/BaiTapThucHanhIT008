using QLSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_GUI
{
    public partial class EnterStudentIdForm : Form
    {
        public EnterStudentIdForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (id.Text == string.Empty)
            {
                MessageBox.Show("Vui long nhập MSSV!");
                return;
            }

            SinhVien s = Program.quanly.GetSinhVienById(id.Text);
            if (s != null)
            {
                UpdatingForm form = new UpdatingForm(s);
                form.Show();
            } else
            {
                MessageBox.Show("Sinh viên không tồn tại!");
            }
        }
    }
}
