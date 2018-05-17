using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Categoria
    {
        //consultar como podemos persistir estos datos, si se puede pensar en un array o algún archivo.
        private float cargoFijoMensual;
        private int cargoVariablePorKwh;
        private string subcategoria;

        public float CargoFijoMensual { get => cargoFijoMensual; set => cargoFijoMensual = value; }
        public int CargoVariablePorKwh { get => cargoVariablePorKwh; set => cargoVariablePorKwh = value; }
        public string Subcategoria { get => subcategoria; set => subcategoria = value; }

        public int consumoMaximoMensual()
        {
            return 1;
        }
        public int consumoMinimoMensual()
        {
            return 1;
        }
    }
}
