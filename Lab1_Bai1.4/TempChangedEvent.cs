using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Bai1._4
{
    public class TempChangedEvent : EventArgs
    {

        public double NewTemp { get; set; }
        public TempChangedEvent(double newtemp)
        {
            NewTemp = newtemp;
        }
    }
}
