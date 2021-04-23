using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Recepcion_Producto
    {
        //Campos
        private int _ID_RECEPCION;
        private int _ID_ESTADO;
        private string _descripcionEstado;
        private string _RUT_EMPLEADO;
        private string _nombreEmpleado;
        private decimal _ID_COMPRA;

        //Propiedades
        public int ID_RECEPCION { get; set; }
        public int ID_ESTADO { get; set; }
        public string DescripcionEstado { get { return _descripcionEstado; } }
        public string RUT_EMPLEADO { get; set; }
        public string NombreEmpleado { get { return _nombreEmpleado; } }
        public decimal ID_COMPRA { get; set; }

        public Recepcion_Producto()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_RECEPCION = 0;
            ID_ESTADO = 0;
            RUT_EMPLEADO = string.Empty;
            ID_COMPRA = 0;
        }
    }
}
