using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Orden_Compra
    {
        //Campos
        private decimal _ID_COMPRA;
        private System.DateTime _FECHA_ORDEN;
        private Nullable<short> _DESCUENTO;
        private string _RUT_EMPLEADO;
        private string _nombreEmpleado;
        private short _ID_TIPOCOM;
        private string _descripcionTipo;
        private short _ID_COSTOENVIO;
        private string _descripcionCosto;

        //Propiedades
        public decimal ID_COMPRA { get; set; }
        public System.DateTime FECHA_ORDEN { get; set; }
        public Nullable<short> DESCUENTO { get; set; }
        public string RUT_EMPLEADO { get; set; }
        public string NombreEmpleado { get { return _nombreEmpleado; } }
        public short ID_TIPOCOM { get; set; }
        public string DescripcionTipo { get { return _descripcionTipo; } }
        public short ID_COSTOENVIO { get; set; }
        public string DescripcionCosto { get { return _descripcionCosto; } }

        public Orden_Compra()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COMPRA = 0;
            FECHA_ORDEN = DateTime.MinValue;
            DESCUENTO = 0;
            RUT_EMPLEADO = string.Empty;
            ID_TIPOCOM = 0;
            ID_COSTOENVIO = 0;
        }
    }
}
