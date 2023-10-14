using System;

namespace Lab1_Bai1._6
{
    public class Human : Mamal, IAbility
    {
        public Human()
        {
            
        }
        public void thinking_behavior()
        {
            Console.WriteLine("is thinking....");
        }

        public void intelligent_behavior()
        {
            Console.WriteLine("I'm very intelligent");
        }
    }
}