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
    
    public partial class CARGO
    {
        public CARGO()
        {
            this.EMPLEADO = new HashSet<EMPLEADO>();
        }
    
        public short ID_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
    
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
    }
}
