using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Cargo
    {
        //Campos
        private short _ID_CARGO;
        private string _NOMBRE_CARGO;

        //Propiedades
        public short ID_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }

        public Cargo()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_CARGO = 0;
            NOMBRE_CARGO = string.Empty;
        }
    }
}
