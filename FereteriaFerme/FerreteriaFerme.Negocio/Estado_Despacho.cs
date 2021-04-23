using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Estado_Despacho
    {
        //Campos
        private short _ID_ESTADO;
        private string _NOMBRE_ESTADO;

        //Propiedades
        public short ID_ESTADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }

        public Estado_Despacho()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_ESTADO = 0;
            NOMBRE_ESTADO = string.Empty;
        }
    }
}
