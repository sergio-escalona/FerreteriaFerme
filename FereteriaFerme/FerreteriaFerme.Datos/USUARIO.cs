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
    
    public partial class USUARIO
    {
        public USUARIO()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
            this.EMPLEADO = new HashSet<EMPLEADO>();
        }
    
        public short ID_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public short ID_TIPOUSU { get; set; }
        public short ID_ESTADO { get; set; }
    
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
        public virtual ESTADO_USUARIO ESTADO_USUARIO { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}
