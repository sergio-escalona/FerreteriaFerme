using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Tipo_Usuario
    {
        //Campo
        private short _ID_TIPOUSU;
        private string _NOMBRE;

        //Propiedades
        public short ID_TIPOUSU { get; set; }
        public string NOMBRE { get; set; }

        public Tipo_Usuario()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPOUSU = 0;
            NOMBRE = string.Empty;
        }
    }
}
