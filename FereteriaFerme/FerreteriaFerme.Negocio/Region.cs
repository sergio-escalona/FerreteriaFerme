using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Region
    {
        //Campos
        private string _ID_REGION;
        private string _NOMBRE_REGION;

        //Propiedades
        public string ID_REGION { get; set; }
        public string NOMBRE_REGION { get; set; }

        public Region()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_REGION = string.Empty;
            NOMBRE_REGION = string.Empty;
        }
    }
}
