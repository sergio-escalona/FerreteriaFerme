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

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.RECEPCION_PRODUCTO rep = new Datos.RECEPCION_PRODUCTO();

            try
            {
                CommonBC.Syncronize(this, rep);

                bbdd.RECEPCION_PRODUCTO.Add(rep);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.RECEPCION_PRODUCTO.Remove(rep);
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
                Datos.RECEPCION_PRODUCTO rep = bbdd.RECEPCION_PRODUCTO.First(e => e.ID_RECEPCION == ID_RECEPCION);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(rep, this);

                /* Carga descripción de los Tipos */
                LeerNombreEstado();
                LeerNombreEmpleado();

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
                Datos.RECEPCION_PRODUCTO rep = bbdd.RECEPCION_PRODUCTO.First(e => e.ID_RECEPCION == ID_RECEPCION);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, rep);


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
                Datos.RECEPCION_PRODUCTO rep = bbdd.RECEPCION_PRODUCTO.First(e => e.ID_RECEPCION == ID_RECEPCION);

                /* Se elimina el registro del EDM */
                bbdd.RECEPCION_PRODUCTO.Remove(rep);

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
        public List<Recepcion_Producto> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.RECEPCION_PRODUCTO> listadoDatos = bbdd.RECEPCION_PRODUCTO.ToList<Datos.RECEPCION_PRODUCTO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Recepcion_Producto> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Recepcion_Producto>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Recepcion_Producto> GenerarListado(List<Datos.RECEPCION_PRODUCTO> listadoDatos)
        {
            List<Recepcion_Producto> listadoEmpresa = new List<Recepcion_Producto>();

            foreach (Datos.RECEPCION_PRODUCTO dato in listadoDatos)
            {

                Recepcion_Producto negocio = new Recepcion_Producto();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreEmpleado();
                negocio.LeerNombreEstado();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Mostrar estado
        public void LeerNombreEstado()
        {
            Estado_Recepcion er = new Estado_Recepcion() { ID_ESTADO = ID_ESTADO };

            if (er.Read())
            {
                _descripcionEstado = er.ESTADO;
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
                _nombreEmpleado = em.NOMBRES_EMPLEADO+" "+em.APELLIDOS_EMPLEADO;
            }
            else
            {
                _nombreEmpleado = String.Empty;
            }
        }
    }
}
