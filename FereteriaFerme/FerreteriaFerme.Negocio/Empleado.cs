using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Empleado
    {
        //Campos
        private string _RUT_EMPLEADO;
        private string _NOMBRES_EMPLEADO;
        private string _APELLIDOS_EMPLEADO;
        private short _ID_CARGO;
        private string _descripcionCargo;
        private short _ID_USUARIO;

        //Propiedades
        public string RUT_EMPLEADO { get; set; }
        public string NOMBRES_EMPLEADO { get; set; }
        public string APELLIDOS_EMPLEADO { get; set; }
        public short ID_CARGO { get; set; }
        public string DescripcionCargo { get { return _descripcionCargo; } }
        public short ID_USUARIO { get; set; }

        public Empleado()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            RUT_EMPLEADO = string.Empty;
            NOMBRES_EMPLEADO = string.Empty;
            APELLIDOS_EMPLEADO = string.Empty;
            ID_CARGO = 0;
            ID_USUARIO = 0;
        }
    }
}
