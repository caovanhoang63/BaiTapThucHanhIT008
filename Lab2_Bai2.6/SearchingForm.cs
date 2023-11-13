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
    public partial class SearchingForm : Form
    {
        public SearchingForm()
        {
            InitializeComponent();
            resultListVieew.Visible = false;
            notFoundLabel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void SearchingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void Search()
        {
            if (studentID.Text == string.Empty && studentName.Text == string.Empty)
            {
                MessageBox.Show("Vui long nhap thong tin sinh vien");
                return;
            }
            resultListVieew.Visible = false;
            btnUpdateStudent.Visible = false;
            notFoundLabel.Visible = false;

            var result = Program.quanly.Search(studentID.Text, studentName.Text);
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    if (item != null)
                    {
                        string[] row = {
                        item.Mssv,
                        item.Ten,
                        item.DiemToan.ToString(),
                        item.DiemHoa.ToString(),
                        item.DiemLy.ToString()};

                        ListViewItem listViewItem = new ListViewItem(row);
                        resultListVieew.Items.Add(listViewItem);
                    }

                }
                btnUpdateStudent.Visible = true;
                resultListVieew.Visible = true;
            }
            else
            {
                notFoundLabel.Visible = true;
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            EnterStudentIdForm form = new EnterStudentIdForm();
            form.ShowDialog();
        }
    }
}
