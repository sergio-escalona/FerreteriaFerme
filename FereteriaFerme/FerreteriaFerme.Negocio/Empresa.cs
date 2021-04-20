using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Empresa
    {
        //Campos
        private short _ID_EMPRESA;
        private string _RAZON_SOCIAL;
        private string _RUT_EMPRESA;
        private short _ID_TIPO;
        private string _CORREO_EMPRESA;
        private string _RUT_CLIENTE;
        private string _nombreCliente;

        //Propiedades
        public short ID_EMPRESA { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string RUT_EMPRESA { get; set; }
        public short ID_TIPO { get; set; }
        public string CORREO_EMPRESA { get; set; }
        public string RUT_CLIENTE { get; set; }
        public string NombreCliente { get { return _nombreCliente; } }

        public Empresa()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_EMPRESA = 0;
            RAZON_SOCIAL = string.Empty;
            RUT_EMPRESA = string.Empty;
            ID_TIPO = 0;
            CORREO_EMPRESA = string.Empty;
            RUT_CLIENTE = string.Empty;
        }
    }
}
