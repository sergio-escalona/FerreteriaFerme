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

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.ORDEN_COMPRA orc = new Datos.ORDEN_COMPRA();

            try
            {
                CommonBC.Syncronize(this, orc);

                bbdd.ORDEN_COMPRA.Add(orc);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.ORDEN_COMPRA.Remove(orc);
                return false;
            }

        }

        /// <summary>
        /// Lee un registro de proveedor en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.ORDEN_COMPRA orc = bbdd.ORDEN_COMPRA.First(e => e.ID_COMPRA == ID_COMPRA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(orc, this);

                /* Carga descripción de los Tipos */
                LeerNombreEmpleado();
                LeerNombreEnvio();
                LeerNombreTipo();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un registro de proveedor en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.ORDEN_COMPRA orc = bbdd.ORDEN_COMPRA.First(e => e.ID_COMPRA == ID_COMPRA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, orc);

                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un registro de proveedor en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.ORDEN_COMPRA orc = bbdd.ORDEN_COMPRA.First(e => e.ID_COMPRA == ID_COMPRA);

                /* Se elimina el registro del EDM */
                bbdd.ORDEN_COMPRA.Remove(orc);

                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Lee todos los registros de producto
        /// </summary>
        /// <returns></returns>
        public List<Orden_Compra> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.ORDEN_COMPRA> listadoDatos = bbdd.ORDEN_COMPRA.ToList<Datos.ORDEN_COMPRA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Orden_Compra> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Orden_Compra>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Orden_Compra> GenerarListado(List<Datos.ORDEN_COMPRA> listadoDatos)
        {
            List<Orden_Compra> listadoEmpresa = new List<Orden_Compra>();

            foreach (Datos.ORDEN_COMPRA dato in listadoDatos)
            {

                Orden_Compra negocio = new Orden_Compra();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreEmpleado();
                negocio.LeerNombreEnvio();
                negocio.LeerNombreTipo();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Orden_Compra> ReadId(decimal id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.ORDEN_COMPRA> listaDatos =
                    bbdd.ORDEN_COMPRA.Where(b => b.ID_COMPRA == id).ToList<Datos.ORDEN_COMPRA>();

                List<Orden_Compra> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Orden_Compra>();
            }
        }

        //Buscar empleado
        public List<Orden_Compra> ReadEmpleado(string rutEmpleado)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.ORDEN_COMPRA> listaDatos =
                    bbdd.ORDEN_COMPRA.Where(b => b.RUT_EMPLEADO == rutEmpleado).ToList<Datos.ORDEN_COMPRA>();

                List<Orden_Compra> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Orden_Compra>();
            }
        }

        //Buscar tipo venta
        public List<Orden_Compra> ReadTipo(short idtipo)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.ORDEN_COMPRA> listaDatos =
                    bbdd.ORDEN_COMPRA.Where(b => b.ID_TIPOCOM == idtipo).ToList<Datos.ORDEN_COMPRA>();

                List<Orden_Compra> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Orden_Compra>();
            }
        }

        //Buscar envio
        public List<Orden_Compra> ReadEnvio(short idEnvio)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.ORDEN_COMPRA> listaDatos =
                    bbdd.ORDEN_COMPRA.Where(b => b.ID_COSTOENVIO == idEnvio).ToList<Datos.ORDEN_COMPRA>();

                List<Orden_Compra> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Orden_Compra>();
            }
        }

        //Mostrar Empleado
        public void LeerNombreEmpleado()
        {
            Empleado emp = new Empleado() { RUT_EMPLEADO = RUT_EMPLEADO };

            if (emp.Read())
            {
                _nombreEmpleado = emp.NOMBRES_EMPLEADO + " " + emp.APELLIDOS_EMPLEADO;
            }
            else
            {
                _nombreEmpleado = String.Empty;
            }
        }

        //Mostrar Tipo venta
        public void LeerNombreTipo()
        {
            Tipo_Compra tc = new Tipo_Compra() { ID_TIPOCOM = ID_TIPOCOM };

            if (tc.Read())
            {
                _descripcionTipo = tc.NOMBRE;
            }
            else
            {
                _descripcionTipo = String.Empty;
            }
        }

        //Mostrar envio
        public void LeerNombreEnvio()
        {
            Costo_envio ce = new Costo_envio() { ID_COSTOENVIO = ID_COSTOENVIO };

            if (ce.Read())
            {
                _descripcionCosto = ce.NOMBRE;
            }
            else
            {
                _descripcionCosto = String.Empty;
            }
        }
    }
}
