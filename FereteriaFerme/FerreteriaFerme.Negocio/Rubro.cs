using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Rubro
    {
        //Campos
        private short _ID_RUBRO;
        private string _NOMBRE_RUBRO;

        //Propiedades
        public short ID_RUBRO { get; set; }
        public string NOMBRE_RUBRO { get; set; }

        public Rubro()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_RUBRO = 0;
            NOMBRE_RUBRO = string.Empty;
        }
    }
}
