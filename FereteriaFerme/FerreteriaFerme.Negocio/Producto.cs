using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Producto
    {
        //Campos
        private long _ID_PRODUCTO;
        private string _NOMBRE_PRODUCTO;
        private short _ID_PROVEEDOR;
        private string _nombreProveedor;
        private short _ID_FAMILIA;
        private string _descripcionFamilia;
        private Nullable<System.DateTime> _FECHA_VENCIMIENTO;
        private short _ID_TIPO;
        private string _descripcionTipo;
        private string _DESCRIPCIÓN;
        private int _PRECIO_CLP;
        private int _PRECIO_USD;
        private short _STOCK;
        private byte[] _FOTO;

        //Propiedades
        public long ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public short ID_PROVEEDOR { get; set; }
        public string NombreProveedor { get { return _nombreProveedor; } }
        public short ID_FAMILIA { get; set; }
        public string DescripcionFamilia { get { return _descripcionFamilia; } }
        public Nullable<System.DateTime> FECHA_VENCIMIENTO { get; set; }
        public short ID_TIPO { get; set; }
        public string DescripcionTipo { get { return _descripcionTipo; } }
        public string DESCRIPCIÓN { get; set; }
        public int PRECIO_CLP { get; set; }
        public int PRECIO_USD { get; set; }
        public short STOCK { get; set; }
        public byte[] FOTO { get; set; }

        public Producto()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_PRODUCTO = 0;
            NOMBRE_PRODUCTO = string.Empty;
            ID_PROVEEDOR = 0;
            ID_FAMILIA = 0;
            FECHA_VENCIMIENTO = null;
            ID_TIPO = 0;
            DESCRIPCIÓN = string.Empty;
            PRECIO_CLP = 0;
            PRECIO_USD = 0;
            STOCK = 0;
            FOTO = new byte[0];
        }
    }
}
