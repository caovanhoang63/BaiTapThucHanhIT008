using System;

namespace Lab1_Bai1._1
{
    public class Square : Rectangle
    {
        public Square() : base()
        {
            name = "Hinh vuong";
        }

        public override void Draw()
        {
            Console.WriteLine("Day la " + Name);
            Console.WriteLine("Toa do cua hinh la: {0}, {1}, {2}, {3} ",A,B,C,D);
            Console.WriteLine("Hinh vuong co 4 canh vuong goc bang nhau");
        }
    }
}