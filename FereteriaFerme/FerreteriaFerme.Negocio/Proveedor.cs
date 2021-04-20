using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Proveedor
    {
        //Campos
        private short _ID_PROVEEDOR;
        private string _NOMBRE_PROVEEDOR;
        private string _RUT_PROVEEDOR;
        private long _CELULAR;
        private string _CORREO;

        //Propiedades
        public short ID_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string RUT_PROVEEDOR { get; set; }
        public long CELULAR { get; set; }
        public string CORREO { get; set; }

        public Proveedor()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_PROVEEDOR = 0;
            NOMBRE_PROVEEDOR = string.Empty;
            RUT_PROVEEDOR = string.Empty;
            CELULAR = 0;
            CORREO = string.Empty;
        }
    }
}
