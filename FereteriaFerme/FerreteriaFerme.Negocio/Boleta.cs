using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Boleta
    {
        //Campos
        private int _ID_BOLETA;
        private System.DateTime _FECHA_BOLETA;
        private int _NETO_BOLETA;
        private int _IVA_BOLETA;
        private int _TOTAL_BOLETA;
        private decimal _ID_COMPRA;
        private string _RUT_CLIENTE;
        private short _ID_MEDIO;
        private String _descripcionMedio;


        //Propiedades
        public int ID_BOLETA { get; set; }
        public System.DateTime FECHA_BOLETA { get; set; }
        public int NETO_BOLETA { get; set; }
        public int IVA_BOLETA { get; set; }
        public int TOTAL_BOLETA { get; set; }
        public decimal ID_COMPRA { get; set; }
        public string RUT_CLIENTE { get; set; }
        public short ID_MEDIO { get; set; }
        public String DescripcionMedio { get { return _descripcionMedio; } }

        public Boleta()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_BOLETA = 0;
            FECHA_BOLETA = DateTime.MinValue;
            NETO_BOLETA = 0;
            IVA_BOLETA = 0;
            TOTAL_BOLETA = 0;
            ID_COMPRA = 0;
            RUT_CLIENTE = string.Empty;
            ID_MEDIO = 0;
        }

    }
}
