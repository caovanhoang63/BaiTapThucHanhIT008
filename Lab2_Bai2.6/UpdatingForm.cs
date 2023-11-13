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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV_GUI
{
    public partial class UpdatingForm : Form
    {

        private SinhVien _sinhvien;
        public UpdatingForm()
        {
            InitializeComponent();
        }
        public UpdatingForm(SinhVien sinhvien)
        {
            InitializeComponent();
            this._sinhvien  = sinhvien;
        }


        private void UpdatingForm_Load(object sender, EventArgs e)
        {
            classId.Text = _sinhvien.Malop;
            name.Text = _sinhvien.Ten;
            math.Text = _sinhvien.DiemToan.ToString();
            physic.Text = _sinhvien.DiemLy.ToString();
            chemistry.Text = _sinhvien.DiemHoa.ToString();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (checkEmptyField()) {
                    MessageBox.Show("Vui lòng điền tất cả thông tin");
                    return;
                }
                int malop =  Program.quanly.ConvertMaLop(classId.Text);
                if (malop == 0)
                {
                    MessageBox.Show("Ma lớp tồn tại");
                    return;
                }
                _sinhvien.Ten = name.Text;
                _sinhvien.DiemToan = float.Parse(math.Text);
                _sinhvien.DiemLy = float.Parse(physic.Text);
                _sinhvien.DiemHoa = float.Parse(chemistry.Text);
                _sinhvien.TinhDTB();
                Program.quanly.Update(_sinhvien);

                MessageBox.Show("Chỉnh sửa thành công!");
                Close();
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
            if ( string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(math.Text)
                || string.IsNullOrEmpty(physic.Text) ||
                string.IsNullOrEmpty(chemistry.Text) ||
                string.IsNullOrEmpty(classId.Text)
                )
            {
                return true;
            }
            return false;
        }
    }
}
