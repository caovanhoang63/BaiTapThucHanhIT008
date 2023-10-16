using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1_Bai1._4
{
    internal class Themometer
    {
        public event EventHandler<TempChangedEvent> TemperaterChange;
        public int Temp { get; set; }

        public void MesureTemp()
        {

            Random rd = new Random();
            while (true)
            {
                // random nhiet do 
                Temp = rd.Next(0, 100);

                TemperaterChange?.Invoke(this, new TempChangedEvent(Temp));
                Thread.Sleep(2000);
            }
        }
    }
}
