using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1_Bai1._4
{
  
    internal class Program
    {

       
        static void Main(string[] args)
        {
            Themometer themometer = new Themometer();
            Display display = new Display();
            // dang ki man hinh hien thi voi nhiet ke
            display.Sub(themometer);
            themometer.MesureTemp();
        }
    }
}


     