using System;

namespace Lab1_Bai1._1
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            name = "Hinh chu nhat";
            a = new Point();
            b = new Point();
            c = new Point();
            d = new Point();
        }
        
        
        private Point a;
        private Point b;
        private Point c;
        private Point d;
        
        public string Name {get => name; }
        public Point A { get => a; }
        public Point B { get => b; }
        public Point C { get => c; }
        public Point D { get => d; } 

        
        public override void Enter()
        {
            Console.WriteLine("Nhap toa do diem thu nhat:");
            a.Enter();
            Console.WriteLine("Nhap toa do diem thu hai:");
            b.Enter();
            Console.WriteLine("Nhap toa do diem thu ba:");
            c.Enter();
            Console.WriteLine("Nhap toa do diem thu tu:");
            d.Enter();
        }

        public override double Area()
        {
            return Point.Distance(a, b) * Point.Distance(b, c);
        }

        public override void Draw()
        {
            Console.WriteLine("Day la hinh: " + Name);
            Console.WriteLine("Hinh chu nhat co 4 goc vuong");
            Console.WriteLine("Toa do cua hinh chu nhat la: {0}, {1}, {2}, {3}", a, b, c, d );
            Console.WriteLine("Dien tich: {0}", Area());
        }
    }    
}