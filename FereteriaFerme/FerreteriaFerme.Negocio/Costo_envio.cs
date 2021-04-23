using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Costo_envio
    {
        //Campo
        private short _ID_COSTOENVIO;
        private string _NOMBRE;
        private int _VALOR;

        //Propiedades
        public short ID_COSTOENVIO { get; set; }
        public string NOMBRE { get; set; }
        public int VALOR { get; set; }

        public Costo_envio()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COSTOENVIO = 0;
            NOMBRE = String.Empty;
            VALOR = 0;
        }
    }
}
