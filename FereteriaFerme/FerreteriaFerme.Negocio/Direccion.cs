using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Direccion
    {
        //Campo
        private int _ID_DIRECCION;
        private string _DIRECCION1;
        private short _ID_COMUNA;
        private string _RUT_CLIENTE;
        private short _ID_EMPRESA;

        //Propiedades
        public int ID_DIRECCION { get; set; }
        public string DIRECCION1 { get; set; }
        public short ID_COMUNA { get; set; }
        public string RUT_CLIENTE { get; set; }
        public short ID_EMPRESA { get; set; }

        public Direccion()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_DIRECCION = 0;
            DIRECCION1 = string.Empty;
            ID_COMUNA = 0;
            RUT_CLIENTE = string.Empty;
            ID_EMPRESA = 0;
        }
    }
}
