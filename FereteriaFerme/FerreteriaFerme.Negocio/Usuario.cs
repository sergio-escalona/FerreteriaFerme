using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Usuario
    {
        //Campos
        private short _ID_USUARIO;
        private string _NOMBRE_USUARIO;
        private string _CONTRASENA;
        private short _ID_TIPOUSU;
        private string _descripcionTipo;

        //Propiedades
        public short ID_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public short ID_TIPOUSU { get; set; }
        public string DescripcionTipo { get { return _descripcionTipo; } }

        public Usuario()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_USUARIO = 0;
            NOMBRE_USUARIO = string.Empty;
            CONTRASENA = string.Empty;
            ID_TIPOUSU = 0;
        }
    }
}
