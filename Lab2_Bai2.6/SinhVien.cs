using System;

namespace QLSV
{
    public class SinhVien : IComparable
    {
        public SinhVien(){}

        private string malop;
        private string mssv;
        private string ten;
        private float diemToan;
        private float diemLy;
        private float diemHoa;
        private float dtb;

        public SinhVien(string mssv, string ten, string malop,  float diemToan, float diemLy, float diemHoa, float dtb)
        {
            if (!ValidateScore(diemToan)) {
                throw new ArgumentException("Diem toan khong hop le"); 
            }

            if (!ValidateScore(diemLy)) {
                throw new ArgumentException("Diem ly khong hop le");
            }
            
            if (!ValidateScore(diemHoa)) {
                throw new ArgumentException("Diem hoa khong hop le");
            }
            this.malop = malop;
            this.mssv = mssv;
            this.ten = ten;
            this.diemToan = diemToan;
            this.diemLy = diemLy;
            this.diemHoa = diemHoa;
            this.dtb = dtb;
        }

        public string Malop
        {
            get => malop;
            set => malop = value;
        }

        public string Mssv
        {
            get => mssv;
            set => mssv = value;
        }

        public string Ten
        {
            get => ten;
            set => ten = value;
        }

        public float DiemToan
        {
            get => diemToan;
            set
            {
                if (value > 0 && value < 10)
                {
                    diemToan = value;
                }
                else
                {
                    throw new Exception("Diem khong hop le");
                }
            }
        }

        public float DiemLy
        {
            get => diemLy;
            set
            {
                if (value > 0 && value < 10 )
                {
                    diemLy = value;
                }
                else
                {
                    throw new Exception("Diem khong hop le");
                }
            }
        }

        public float DiemHoa
        {
            get => diemHoa;
            set
            {
                if (value > 0 && value < 10)
                {
                    diemHoa = value;
                }
                else
                {
                    throw new Exception("Diem khong hop le");
                }
            }
        }

        public float Dtb
        {
            get => dtb;
            set
            {
                if (value > 0 && value < 10)
                {
                    dtb = value;
                }
                else
                {
                    throw new Exception("Diem khong hop le");
                }
            }
        }



        private bool ValidateScore(float score)
        {
            if (score < 0 || score > 10) {
                return false; 
            }

            return true;
        }
        public override string ToString()
        {
            return Malop + " " + Mssv + " " + Ten + " " + DiemLy + " " + DiemLy + " " +DiemHoa + " " + Dtb;
        }
        public int CompareTo(object obj)
        {
            if(obj == null) return 1;

            SinhVien other = obj as SinhVien;
            if(other != null) {
                return this.Dtb.CompareTo(other.Dtb);
            } else {
                throw new ArgumentException("Object is not a SinhVien");
            }
        }
    }
}