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
    public partial class ShowClassList : Form
    {
        public ShowClassList()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            resultListVieew.Visible = false;
            resultListVieew.Items.Clear();
            int classID;
            switch (classId.Text)
            {
                case "KTPM2022.1":
                    classID = 1;
                    break;
                case "KTPM2022.2":
                    classID = 2;
                    break;
                case "KTPM2022.3":
                    classID = 3;
                    break;
                case "KTPM2022.4":
                    classID = 4;
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn lớp!");
                    return;
            }

            List<SinhVien> list = Program.quanly.GetSinhVienByClassId(classID);
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item != null)
                    {
                        string[] row = {
                        item.Mssv,
                        item.Ten,
                        item.DiemToan.ToString(),
                        item.DiemHoa.ToString(),
                        item.DiemLy.ToString()
                    };

                        ListViewItem listViewItem = new ListViewItem(row);
                        resultListVieew.Items.Add(listViewItem);
                    }
                    resultListVieew.Refresh();
                    resultListVieew.Visible = true;
                }
            }
        }
    }
}
