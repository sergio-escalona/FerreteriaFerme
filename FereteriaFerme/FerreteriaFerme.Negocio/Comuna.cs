using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Comuna
    {
        //Campos
        private short _ID_COMUNA;
        private string _NOMBRE_COMUNA;
        private string _ID_REGION;
        private string _descripcionRegion;

        //Propiedades
        public short ID_COMUNA { get; set; }
        public string NOMBRE_COMUNA { get; set; }
        public string ID_REGION { get; set; }
        public string DescripcionRegion { get { return _descripcionRegion; } }

        public Comuna()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COMUNA = 0;
            NOMBRE_COMUNA = String.Empty;
            ID_REGION = String.Empty;
        }
    }
}
