using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Despacho
    {
        //Campo
        private int _ID_DESPACHO;
        private decimal _ID_DETALLE;
        private short _ID_ESTADO;
        private string _descripcionEstado;
        private string _RUT_EMPLEADO;
        private string _nombreEmpleado;
        private System.DateTime _FECHA_ENVIO;
        private Nullable<System.DateTime> _FECHA_RECEPCION;

        //Propiedades
        public int ID_DESPACHO { get; set; }
        public decimal ID_DETALLE { get; set; }
        public short ID_ESTADO { get; set; }
        public string DescripcionEstado { get { return _descripcionEstado; } }
        public string RUT_EMPLEADO { get; set; }
        public string NombreEmpleado { get { return _nombreEmpleado; } }
        public System.DateTime FECHA_ENVIO { get; set; }
        public Nullable<System.DateTime> FECHA_RECEPCION { get; set; }

        public Despacho()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_DESPACHO = 0;
            ID_DETALLE = 0;
            ID_ESTADO = 0;
            RUT_EMPLEADO = string.Empty;
            FECHA_ENVIO = DateTime.MinValue;
            FECHA_RECEPCION = null;
        }
    }
}
