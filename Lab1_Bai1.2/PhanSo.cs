using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace Phanso
{
    public class PhanSo : IComparable<PhanSo>
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo(int tuSo, int mauSo)
        {
            TuSo = tuSo;
            MauSo = mauSo;
        }
        public PhanSo()
        {
            TuSo = 0; ;
            MauSo = 1;
        }

        // Hàm chuyển đổi kiểu ngầm định từ số nguyên ra phân số
        public static implicit operator PhanSo(int number)
        {
            return new PhanSo(number, 1);
        }

        // Hàm chuyển đổi tường minh từ phân số ra số thực
        public static explicit operator double(PhanSo phanSo)
        {
            return (double)phanSo.TuSo / phanSo.MauSo;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PhanSo other = (PhanSo)obj;
            return TuSo * other.MauSo == other.TuSo * MauSo;
        }

        public override int GetHashCode()
        {
            return TuSo.GetHashCode() ^ MauSo.GetHashCode();
        }


        // Các toán tử +, -, *, /
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mauSo = a.MauSo * b.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
            int mauSo = a.MauSo * b.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.TuSo;
            int mauSo = a.MauSo * b.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.MauSo;
            int mauSo = a.MauSo * b.TuSo;
            return new PhanSo(tuSo, mauSo);
        }

        // Các toán tử so sánh
        public static bool operator ==(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo == b.TuSo * a.MauSo;
        }

        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo != b.TuSo * a.MauSo;
        }

        public static bool operator <(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo < b.TuSo * a.MauSo;
        }

        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo > b.TuSo * a.MauSo;
        }

        public void Nhap()
        {
            Console.Write("Nhap tu: ");
            TuSo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap mau: ");
            MauSo = Convert.ToInt32(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"{TuSo}/{MauSo}";
        }
        public int CompareTo(PhanSo other)
        {
            double a = (double)TuSo / MauSo;
            double b = (double)other.TuSo / other.MauSo;
            return a.CompareTo(b);
        }

        // Phương thức xuất phân số
        public void Xuat()
        {
            Console.WriteLine($"{TuSo}/{MauSo}");
        }
    }
}
