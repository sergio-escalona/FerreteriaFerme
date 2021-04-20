using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Familia_Producto
    {
        //Campos
        private short _ID_FAMILIA;
        private string _NOMBRE_FAMILIA;

        //Propiedades
        public short ID_FAMILIA { get; set; }
        public string NOMBRE_FAMILIA { get; set; }

        public Familia_Producto()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_FAMILIA = 0;
            NOMBRE_FAMILIA = string.Empty;
        }
    }
}
