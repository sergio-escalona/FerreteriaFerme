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
        private decimal _idCompra;

        //Propiedades
        public int ID_DESPACHO { get; set; }
        public decimal ID_DETALLE { get; set; }
        public short ID_ESTADO { get; set; }
        public string DescripcionEstado { get { return _descripcionEstado; } }
        public string RUT_EMPLEADO { get; set; }
        public string NombreEmpleado { get { return _nombreEmpleado; } }
        public System.DateTime FECHA_ENVIO { get; set; }
        public Nullable<System.DateTime> FECHA_RECEPCION { get; set; }
        public decimal IdCompra { get { return _idCompra; } }

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
            FECHA_ENVIO = DateTime.Now;
            FECHA_RECEPCION = null;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.DESPACHO des = new Datos.DESPACHO();

            try
            {
                CommonBC.Syncronize(this, des);

                bbdd.DESPACHO.Add(des);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.DESPACHO.Remove(des);
                return false;
            }

        }

        /// <summary>
        /// Lee un registro de cargi en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.DESPACHO des = bbdd.DESPACHO.First(e => e.ID_DESPACHO == ID_DESPACHO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(des, this);

                /* Carga descripción de los Tipos */
                LeerNombreEstado();
                LeerNombreEmpleado();
                LeerIdCompra();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un registro de cargo en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.DESPACHO des = bbdd.DESPACHO.First(e => e.ID_DESPACHO == ID_DESPACHO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, des);


                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un registro de producto en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.DESPACHO des = bbdd.DESPACHO.First(e => e.ID_DESPACHO == ID_DESPACHO);

                /* Se elimina el registro del EDM */
                bbdd.DESPACHO.Remove(des);

                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Lee todos los registros de cargo
        /// </summary>
        /// <returns></returns>
        public List<Despacho> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.DESPACHO> listadoDatos = bbdd.DESPACHO.ToList<Datos.DESPACHO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Despacho> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Despacho>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Despacho> GenerarListado(List<Datos.DESPACHO> listadoDatos)
        {
            List<Despacho> listadoEmpresa = new List<Despacho>();

            foreach (Datos.DESPACHO dato in listadoDatos)
            {

                Despacho negocio = new Despacho();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreEmpleado();
                negocio.LeerNombreEstado();
                negocio.LeerIdCompra();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Mostrar estado
        public void LeerNombreEstado()
        {
            Estado_Despacho ed = new Estado_Despacho() { ID_ESTADO = ID_ESTADO };

            if (ed.Read())
            {
                _descripcionEstado = ed.NOMBRE_ESTADO;
            }
            else
            {
                _descripcionEstado = String.Empty;
            }
        }

        //Mostrar empleado
        public void LeerNombreEmpleado()
        {
            Empleado em = new Empleado() { RUT_EMPLEADO = RUT_EMPLEADO };

            if (em.Read())
            {
                _nombreEmpleado = em.NOMBRES_EMPLEADO + " " + em.APELLIDOS_EMPLEADO;
            }
            else
            {
                _nombreEmpleado = String.Empty;
            }
        }

        //Mostrar empleado
        public void LeerIdCompra()
        {
            Detalle_Orden oc = new Detalle_Orden() { ID_DETALLE = ID_DETALLE };

            if (oc.Read())
            {
                _idCompra = oc.ID_COMPRA;
            }
            else
            {
                _idCompra = 0;
            }
        }

    }
}
