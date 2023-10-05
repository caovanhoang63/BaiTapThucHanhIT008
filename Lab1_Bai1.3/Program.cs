using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Bai1._3
{
    internal class Program
    {

        
        static void Main(string [] args)
        {
            List<string> list = new List<string> { "apple", "banana", "cherry", "date" };
            ;
            List<int> list2 = new List<int> { 3, 7, 1, 9, 5 }; ;
            List<double> list3 = new List<double> {3.4, 5.6,2.1,6.2,4.8 };

            Find find = new Find();

            int maxInt = find.FindMax(list2);
            double maxDouble = find.FindMax(list3);
            string maxString = find.FindMax(list);

            int minInt = find.FindMin(list2);
            double minDouble = find.FindMin(list3);
            string minString = find.FindMin(list);

            Console.WriteLine($"Max int: {maxInt}");
            Console.WriteLine($"Max double: {maxDouble}");
            Console.WriteLine($"Max string: {maxString}");

            Console.WriteLine($"Min int: {minInt}");
            Console.WriteLine($"Min double: {minDouble}");
            Console.WriteLine($"Min string: {minString}");

        }
    }
}
