using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class Cliente
    {
        
            public string nombreYApellido { get; set; }
            public string numeroDocumento { get; set; }
            public string tipoDocumento { get; set; }
            public string domicilioServicio { get; set; }
            public string telefono { get; set; }
            public string fechaAltaServicio { get; set; }
            public string usuario { get; set; }
            public string contrasenia { get; set; }
            public string categoria { get; set; }
        public List<Dispositivo> dispositivos = new List<Dispositivo>();

        /*
        public int cantidadDispositivosOFF() { return 1; }
        public int cantidadDispositivosON() { return 1; }
        public int cantidadDispositivosTotal() { return 1; }
        public void categorizar() { }
        
        */

        public string cantidadDeDispositivosON() {
            
            int encendidos = 0;
            for (int cont = 0; cont < dispositivos.Count; cont++)
            {
                if (dispositivos[cont].dispositivoON == true) { encendidos++; }
            }

            return ("Cantidad de Dispositivos Encendidos: " + encendidos);
        }

        public string cantidadDeDispositivosOFF()
        {
            
            int apagados = 0;
            for (int cont = 0; cont < dispositivos.Count; cont++)
            {
                if (dispositivos[cont].dispositivoON == false) { apagados++; }
            }

            return ("Cantidad de Dispositivos Apagados: " + apagados);
        }

        public string cantidadDeDispositivosTotales()
        {
            
            return ("Cantidad de Dispositivos Totales: " + dispositivos.Count);
        }
        public string antiguedadEnMeses()
        {

            return ("Meses como administrador: " + (DateTime.Now.Month - Convert.ToDateTime(fechaAltaServicio).Month));
        }

        public string consumo()
        {
            string texto = "";
            for (int cont = 0; cont < dispositivos.Count; cont++)
            {
                texto= texto+"\n"+("Consumo del dispositivo " + (cont + 1) + ": " + dispositivos[cont].Kwh + " Kwh")+"\n";
            }
            return texto;
        }


}
}
