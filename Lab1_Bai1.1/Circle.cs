﻿using System;

namespace Lab1_Bai1._1
{
    public class Circle : Shape
    {
        private Point I { get; set; }
        private double R { get; set; }
        
        public override void Enter()
        {
            Console.WriteLine("Nhap toa do tam: ");
            I.Enter();
            Console.WriteLine("Nhap ban kinh: ");
            R = double.Parse(Console.ReadLine());
        }   

        public override double Area()
        {
            return Math.PI * R * R;
        }

        public override void Draw()
        {
            Console.WriteLine("Toa do tam hinh tron la:",I);
            Console.WriteLine("Ban kinh hinh tron la: ",R);
        }
    }
}