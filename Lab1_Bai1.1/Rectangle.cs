using System;

namespace Lab1_Bai1._1
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
            D = new Point();
        }
        private Point A { get; set; } 
        private Point B { get; set; }
        private Point C { get; set; }
        private Point D { get; set; }

        public override void Enter()
        {
            Console.WriteLine("Nhap toa do diem thu nhat:");
            A.Enter();
            Console.WriteLine("Nhap toa do diem thu hai:");
            B.Enter();
            Console.WriteLine("Nhap toa do diem thu ba:");
            C.Enter();
            Console.WriteLine("Nhap toa do diem thu tu:");
            D.Enter();
        }

        public override double Area()
        {
            return Point.Distance(A, B) * Point.Distance(B, C);
        }

        public override void Draw()
        {
            Console.WriteLine("Hinh chu nhat co 4 goc vuong");
            Console.WriteLine("Toa do cua hinh chu nhat la:", A, B, C, D );
        }
    }    
}