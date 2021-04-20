using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Resumen_Productos
    {
        //Campos
        private int _ID_RESPRO;
        private int _MES_ANNO;
        private long _ID_PRODUCTO;
        private string _NOMBRE_PRODUCTO;
        private string _TIPO_PRODUCTO;
        private string _FAMILIA_PRODUCTO;
        private short _CANTIDAD;

        //Propiedades
        public int ID_RESPRO { get; set; }
        public int MES_ANNO { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string TIPO_PRODUCTO { get; set; }
        public string FAMILIA_PRODUCTO { get; set; }
        public short CANTIDAD { get; set; }

        public Resumen_Productos()
        {
            this.init();
        }

        //Cosntructor
        private void init()
        {
            ID_RESPRO = 0;
            MES_ANNO = 0;
            ID_PRODUCTO = 0;
            NOMBRE_PRODUCTO = string.Empty;
            TIPO_PRODUCTO = string.Empty;
            FAMILIA_PRODUCTO = string.Empty;
            CANTIDAD = 0;
        }
    }
}
