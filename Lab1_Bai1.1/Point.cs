using System;

namespace Lab1_Bai1._1
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public void Enter()
        {
            Console.WriteLine("Nhap hoanh do:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tung do:");
            y = double.Parse(Console.ReadLine());
        }

        public static double Distance(Point a, Point b)
        {
            return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        }       
        
        public override string ToString()
        {
            return "("+ x + "," + y + ")";
        }
    }
}