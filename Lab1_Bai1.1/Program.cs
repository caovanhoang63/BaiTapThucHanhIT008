using System;
using System.Collections.Generic;

namespace Lab1_Bai1._1
{


    internal class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random();
            List<Shape> listShape = new List<Shape>();
            Console.WriteLine("Nhap so hinh: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Shape shape = null;
                int shapeType = rand.Next(4);
                switch (shapeType)
                {
                    case 0 :
                        shape = new Rectangle();
                        Console.WriteLine("Nhap thong tin hinh chu nhat:");
                        shape.Enter();
                        break;
                    case 1 :
                        shape = new Triangle();
                        Console.WriteLine("Nhap thong tin hinh tam giac:");
                        shape.Enter();
                        break;
                    case 2 :
                        shape = new Circle();
                        Console.WriteLine("Nhap thong tin hinh tron:");
                        shape.Enter();
                        break;
                    case 3 :
                        shape = new Square();
                        Console.WriteLine("Nhap thong tin hinh vuong:");
                        shape.Enter();
                        break;
                }
                listShape.Add(shape);
            }
            foreach (var shape in listShape)
            {
                if (shape != null)
                {
                    shape.Draw();
                }
            }
        }
    }
}