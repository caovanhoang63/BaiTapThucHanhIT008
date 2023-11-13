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
    public partial class DeletingForm : Form
    {
        public DeletingForm()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (id.Text != string.Empty)
            {
                    
                if (Program.quanly.Delete(id.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                } else
                {
                    MessageBox.Show("MSSV không tồn tại!");
                }
                return;
            }
            MessageBox.Show("Vui lòng nhập mssv!");
        }
    }
}
