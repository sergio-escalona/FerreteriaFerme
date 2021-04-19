//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FerreteriaFerme.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        public PRODUCTO()
        {
            this.DETALLE_ORDEN = new HashSet<DETALLE_ORDEN>();
        }
    
        public long ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public short ID_PROVEEDOR { get; set; }
        public short ID_FAMILIA { get; set; }
        public Nullable<System.DateTime> FECHA_VENCIMIENTO { get; set; }
        public short ID_TIPO { get; set; }
        public string DESCRIPCIÓN { get; set; }
        public int PRECIO_CLP { get; set; }
        public int PRECIO_USD { get; set; }
        public string STOCK { get; set; }
        public byte[] FOTO { get; set; }
    
        public virtual ICollection<DETALLE_ORDEN> DETALLE_ORDEN { get; set; }
        public virtual FAMILIA_PRODUCTO FAMILIA_PRODUCTO { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
        public virtual TIPO_PRODUCTO TIPO_PRODUCTO { get; set; }
    }
}
