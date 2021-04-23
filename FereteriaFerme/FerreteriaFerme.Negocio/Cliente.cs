using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Cliente
    {
        //Campos
        private string _RUT_CLIENTE;
        private string _NOMBRES;
        private string _APELLIDOS;
        private short _ID_USUARIO;
        private string _CORREO_CLIENTE;

        //Propiedades
        public string RUT_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public short ID_USUARIO { get; set; }
        public string CORREO_CLIENTE { get; set; }

        public Cliente()
        {
            this.init();
        }

        private void init()
        {
            RUT_CLIENTE = string.Empty;
            NOMBRES = string.Empty;
            APELLIDOS = string.Empty;
            ID_USUARIO = 0;
            CORREO_CLIENTE = string.Empty;
        }
    }
}
