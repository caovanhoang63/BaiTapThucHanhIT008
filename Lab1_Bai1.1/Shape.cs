namespace Lab1_Bai1._1
{
    public abstract class Shape
    {
        protected string Name { get; set; }

        public abstract void Enter();
        public abstract double Area();
        public abstract void Draw();
    }
}