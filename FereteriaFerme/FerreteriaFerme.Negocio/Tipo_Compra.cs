using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Tipo_Compra
    {
        //Campos
        private short _ID_TIPOCOM;
        private string _NOMBRE;

        //Propiedades
        public short ID_TIPOCOM { get; set; }
        public string NOMBRE { get; set; }

        public Tipo_Compra()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPOCOM = 0;
            NOMBRE = string.Empty;
        }
    }
}
