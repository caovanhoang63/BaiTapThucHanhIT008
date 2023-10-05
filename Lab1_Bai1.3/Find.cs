using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Bai1._3
{
    internal class Find
    {
        public T FindMax<T>(IEnumerable<T> sequence)// IEnumrable la mot giao dien dai dien cho mot tap hop có the lap qua cac phan tu 
        where T : IComparable<T>  // cau lenh nay de su cung ToCompare() cho KDL <T> , where kiem soat KDL mà tham so generic co the nhan 
        {
            if (sequence == null || !sequence.Any()) // ham Any() kiem tra xem sequence co it nhat mot phan 
            {
                throw new ArgumentException("Sequence is empty or null.");
            }

            {
                T max = sequence.First();
                foreach (var item in sequence)
                {
                    if (item.CompareTo(max)>0) //***
                    {
                        max = item;
                    }
                }
                return max;
            }
        }
        public T FindMin<T>(IEnumerable<T> sequence)
            where T : IComparable<T>
        {
            if (sequence ==null || !sequence.Any())
            {
                throw new ArgumentException(" Sequence is empty or null");

            }
            {
                T min = sequence.First();
                foreach (var item in sequence)
                {
                    if (item.CompareTo(min)< 0)
                    {
                        min = item;
                    }


                }
                return min;
            }

        }
    }
}
