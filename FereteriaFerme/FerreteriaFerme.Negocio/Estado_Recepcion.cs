using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Estado_Recepcion
    {
        //Campos
        private int _ID_ESTADO;
        private string _ESTADO;

        //Propiedades
        public int ID_ESTADO { get; set; }
        public string ESTADO { get; set; }

        public Estado_Recepcion()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_ESTADO = 0;
            ESTADO = string.Empty;
        }
    }
}
