using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Producto_Proveedor
    {
        //Campos
        private int _ID_PRODUCTO;
        private string _NOMBRE_PRODUCTO;
        private short _CANTIDAD;
        private int _PRECIO_UNITARIO;
        private int _ID_COMPRA;

        //Propiedades
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public short CANTIDAD { get; set; }
        public int PRECIO_UNITARIO { get; set; }
        public int ID_COMPRA { get; set; }

        public Producto_Proveedor()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_PRODUCTO = 0;
            NOMBRE_PRODUCTO = string.Empty;
            CANTIDAD = 0;
            PRECIO_UNITARIO = 0;
            ID_COMPRA = 0;
        }

    }
}
