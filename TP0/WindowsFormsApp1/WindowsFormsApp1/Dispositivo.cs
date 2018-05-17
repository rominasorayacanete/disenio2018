using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Dispositivo
    {
        public bool dispositivoON { get; set; }
        public double Kwh { get; set; }
        public string tipo { get; set; }

        public bool  ModoON() {
            dispositivoON =true; return true;
        }
    }
   
}
