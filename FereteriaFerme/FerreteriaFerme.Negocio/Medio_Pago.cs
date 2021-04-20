using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Medio_Pago
    {
        //Campos
        private short _ID_MEDIO;
        private string _NOMBRE_MEDIO;

        //Propiedades
        public short ID_MEDIO { get; set; }
        public string NOMBRE_MEDIO { get; set; }

        public Medio_Pago()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_MEDIO = 0;
            NOMBRE_MEDIO = string.Empty;
        }
    }
}
