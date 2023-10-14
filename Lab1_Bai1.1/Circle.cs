using System;

namespace Lab1_Bai1._1
{
    public class Circle : Shape
    {
        public Circle()
        {
            name = "Hinh tron";
            i = new Point();
        }
        private Point i;
        private double r;
        
        public Point I { get => i; }
        public double R { get => r; }
        
        public override void Enter()
        {
            Console.WriteLine("Nhap toa do tam: ");
            i.Enter();
            Console.WriteLine("Nhap ban kinh: ");
            r = double.Parse(Console.ReadLine());
        }   

        public override double Area()
        {
            return Math.PI * r * r;
        }

        public override void Draw()
        {
            Console.WriteLine("Day la hinh" + name);
            Console.WriteLine("Toa do tam hinh tron la:" + i);
            Console.WriteLine("Ban kinh hinh tron la: " + r);
            Console.WriteLine("Dien tich: " + Area());
        }
    }
}