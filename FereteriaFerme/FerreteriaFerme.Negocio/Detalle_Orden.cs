using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Detalle_Orden
    {
        //Campo
        private decimal _ID_DETALLE;
        private long _ID_PRODUCTO;
        private string _nombreProducto;
        private short _CANTIDAD;
        private decimal _ID_COMPRA;

        //Propiedades
        public decimal ID_DETALLE { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string NombreProducto { get { return _nombreProducto; } }
        public short CANTIDAD { get; set; }
        public decimal ID_COMPRA { get; set; }

        public Detalle_Orden()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_DETALLE = 0;
            ID_PRODUCTO = 0;
            CANTIDAD = 0;
            ID_COMPRA = 0;
        }
    }
}
