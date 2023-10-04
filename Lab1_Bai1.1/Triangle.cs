using System;

namespace Lab1_Bai1._1
{
    public class Triangle : Shape
    {
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }
        
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
            return (1 / 2) * Math.Abs((B.x - A.x)*(C.y-A.y)- (C.x - A.x)*(B.y-A.y));
        }

        public override void Draw()
        {
            Console.WriteLine("Toa do cua hinh tam giac la:", A, B, C );
        }
    }
}