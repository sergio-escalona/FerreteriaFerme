using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Tipo_Empresa
    {
        //Campos
        private short _ID_TIPO;
        private string _NOMBRE_TIPO;

        //Propiedades
        public short ID_TIPO { get; set; }
        public string NOMBRE_TIPO { get; set; }

        public Tipo_Empresa()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPO = 0;
            NOMBRE_TIPO = string.Empty;
        }
    }
}
