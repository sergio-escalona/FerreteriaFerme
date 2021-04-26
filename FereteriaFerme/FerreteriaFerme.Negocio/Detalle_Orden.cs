using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Detalle_Orden
    {
        //Campo
        private decimal _ID_DETALLE;
        private long _ID_PRODUCTO;
        private string _nombreProducto;
        private short _CANTIDAD;
        private decimal _ID_COMPRA;

        //Propiedades
        public decimal ID_DETALLE { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string NombreProducto { get { return _nombreProducto; } }
        public short CANTIDAD { get; set; }
        public decimal ID_COMPRA { get; set; }

        public Detalle_Orden()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_DETALLE = 0;
            ID_PRODUCTO = 0;
            CANTIDAD = 0;
            ID_COMPRA = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.DETALLE_ORDEN deo = new Datos.DETALLE_ORDEN();

            try
            {
                CommonBC.Syncronize(this, deo);

                bbdd.DETALLE_ORDEN.Add(deo);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.DETALLE_ORDEN.Remove(deo);
                return false;
            }

        }

        /// <summary>
        /// Lee un registro de orden en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.DETALLE_ORDEN deo = bbdd.DETALLE_ORDEN.First(e => e.ID_DETALLE == ID_DETALLE);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(deo, this);

                /* Carga descripción de los Tipos */
                LeerNombreProducto();

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
                Datos.DETALLE_ORDEN deo = bbdd.DETALLE_ORDEN.First(e => e.ID_DETALLE == ID_DETALLE);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, deo);

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
                Datos.DETALLE_ORDEN deo = bbdd.DETALLE_ORDEN.First(e => e.ID_DETALLE == ID_DETALLE);

                /* Se elimina el registro del EDM */
                bbdd.DETALLE_ORDEN.Remove(deo);

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
        public List<Detalle_Orden> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.DETALLE_ORDEN> listadoDatos = bbdd.DETALLE_ORDEN.ToList<Datos.DETALLE_ORDEN>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Detalle_Orden> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Detalle_Orden>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Detalle_Orden> GenerarListado(List<Datos.DETALLE_ORDEN> listadoDatos)
        {
            List<Detalle_Orden> listadoEmpresa = new List<Detalle_Orden>();

            foreach (Datos.DETALLE_ORDEN dato in listadoDatos)
            {

                Detalle_Orden negocio = new Detalle_Orden();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreProducto();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos de una compra
        public List<Detalle_Orden> ReadId(decimal id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DETALLE_ORDEN> listaDatos =
                    bbdd.DETALLE_ORDEN.Where(b => b.ID_COMPRA == id).ToList<Datos.DETALLE_ORDEN>();

                List<Detalle_Orden> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Detalle_Orden>();
            }
        }

        //Buscar envio
        public List<Detalle_Orden> ReadProducto(long idProducto)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DETALLE_ORDEN> listaDatos =
                    bbdd.DETALLE_ORDEN.Where(b => b.ID_PRODUCTO == idProducto).ToList<Datos.DETALLE_ORDEN>();

                List<Detalle_Orden> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Detalle_Orden>();
            }
        }

        //Mostrar Empleado
        public void LeerNombreProducto()
        {
            Producto pro = new Producto() { ID_PRODUCTO = ID_PRODUCTO };

            if (pro.Read())
            {
                _nombreProducto = pro.NOMBRE_PRODUCTO;
            }
            else
            {
                _nombreProducto = String.Empty;
            }
        }
    }
}
