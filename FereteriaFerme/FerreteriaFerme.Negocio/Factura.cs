using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Factura
    {
        //Campos
        private int _ID_FACTURA;
        private System.DateTime _FECHA_FACTURA;
        private int _NETO_FACTURA;
        private int _IVA_FACTURA;
        private int _TOTAL_FACTURA;
        private decimal _ID_COMPRA;
        private short _ID_EMPRESA;
        private string _nombreEmpresa;
        private short _ID_MEDIO;
        private string _descripcionMedio;

        //Propiedades
        public int ID_FACTURA { get; set; }
        public System.DateTime FECHA_FACTURA { get; set; }
        public int NETO_FACTURA { get; set; }
        public int IVA_FACTURA { get; set; }
        public int TOTAL_FACTURA { get; set; }
        public decimal ID_COMPRA { get; set; }
        public short ID_EMPRESA { get; set; }
        public string nombreEmpresa { get { return _nombreEmpresa; } }
        public short ID_MEDIO { get; set; }
        public string DescripcionMedio { get { return _descripcionMedio; } }

        public Factura()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_FACTURA = 0;
            FECHA_FACTURA = DateTime.MinValue;
            NETO_FACTURA = 0;
            IVA_FACTURA = 0;
            TOTAL_FACTURA = 0;
            ID_COMPRA = 0;
            ID_EMPRESA = 0;
            ID_MEDIO = 0;
        }
    }
}
