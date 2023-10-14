using System;
using System.Net.NetworkInformation;

namespace Lab1_Bai1._1
{
    public class Triangle : Shape
    {
        public Triangle()
        {
            name = "Hinh tam giac";
            a = new Point();
            b = new Point();
            c = new Point();
        }
    
        private Point a;
        private Point b;
        private Point c;
        public string Name
        {
            get => name;
        }
        private Point A { get => a;}
        private Point B { get => b; }
        private Point C { get => c; }
        
        public override void Enter()
        {
            Console.WriteLine("Nhap toa do diem thu nhat:");
            A.Enter();
            Console.WriteLine("Nhap toa do diem thu hai:");
            B.Enter();
            Console.WriteLine("Nhap toa do diem thu ba:");
            C.Enter();
        }

        public override double Area()
        {
            return (1 / 2) * Math.Abs((b.x - a.x)*(c.y-a.y)- (c.x - a.x)*(b.y-a.y));
        }

        public override void Draw()
        {
            Console.WriteLine("Day la hinh: " + name);
            Console.WriteLine("Hinh tam giac co ba canh");
            Console.WriteLine("Toa do cua hinh tam giac la:" + a +  b +  c );
            Console.WriteLine("Dien tich: " + Area());
        }
        
    }
}