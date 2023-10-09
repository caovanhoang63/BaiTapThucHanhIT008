using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Bai1._4
{
    internal class Display
    {
        public void Sub(Themometer themometer)
        {
            themometer.TemperaterChange +=HandleTemperatureChanged;
        }
        private void HandleTemperatureChanged(object sender, TempChangedEvent e)
        {
            TempChangedEvent temp = (TempChangedEvent)e;////
            Console.WriteLine("New Temperature: {0}°C", temp.NewTemp);/////
        }
    }
}
