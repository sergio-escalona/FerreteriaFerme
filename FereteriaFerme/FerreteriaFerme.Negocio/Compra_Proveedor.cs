using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Compra_Proveedor
    {
        //Campos
        private int _ID_COMPRA;
        private System.DateTime _FECHA_COMPRA;
        private short _ID_PROVEEDOR;
        private String _descripcionProveedor;

        //Propiedades
        public int ID_COMPRA { get; set; }
        public System.DateTime FECHA_COMPRA { get; set; }
        public short ID_PROVEEDOR { get; set; }
        public String DescripcionProveedor { get { return _descripcionProveedor; } }

        public Compra_Proveedor()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COMPRA = 0;
            FECHA_COMPRA = DateTime.MinValue;
            ID_PROVEEDOR = 0;
        }
    }
}
