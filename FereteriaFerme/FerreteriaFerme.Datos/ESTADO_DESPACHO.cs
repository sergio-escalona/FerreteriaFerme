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
    
    public partial class ESTADO_DESPACHO
    {
        public ESTADO_DESPACHO()
        {
            this.DESPACHO = new HashSet<DESPACHO>();
        }
    
        public short ID_ESTADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }
    
        public virtual ICollection<DESPACHO> DESPACHO { get; set; }
    }
}
