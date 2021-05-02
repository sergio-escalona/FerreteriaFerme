using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Producto_Proveedor
    {
        //Campos
        private int _ID_PRODUCTO;
        private string _NOMBRE_PRODUCTO;
        private short _CANTIDAD;
        private int _PRECIO_UNITARIO;
        private int _ID_COMPRA;

        //Propiedades
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public short CANTIDAD { get; set; }
        public int PRECIO_UNITARIO { get; set; }
        public int ID_COMPRA { get; set; }

        public Producto_Proveedor()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_PRODUCTO = 0;
            NOMBRE_PRODUCTO = string.Empty;
            CANTIDAD = 0;
            PRECIO_UNITARIO = 0;
            ID_COMPRA = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.PRODUCTO_PROVEEDOR prp = new Datos.PRODUCTO_PROVEEDOR();

            try
            {
                CommonBC.Syncronize(this, prp);

                bbdd.PRODUCTO_PROVEEDOR.Add(prp);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.PRODUCTO_PROVEEDOR.Remove(prp);
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
                Datos.PRODUCTO_PROVEEDOR prp = bbdd.PRODUCTO_PROVEEDOR.First(e => e.ID_PRODUCTO == ID_PRODUCTO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(prp, this);

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
                Datos.PRODUCTO_PROVEEDOR prp = bbdd.PRODUCTO_PROVEEDOR.First(e => e.ID_PRODUCTO == ID_PRODUCTO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, prp);

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
                Datos.PRODUCTO_PROVEEDOR prp = bbdd.PRODUCTO_PROVEEDOR.First(e => e.ID_PRODUCTO == ID_PRODUCTO);

                /* Se elimina el registro del EDM */
                bbdd.PRODUCTO_PROVEEDOR.Remove(prp);

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
        public List<Producto_Proveedor> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.PRODUCTO_PROVEEDOR> listadoDatos = bbdd.PRODUCTO_PROVEEDOR.ToList<Datos.PRODUCTO_PROVEEDOR>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Producto_Proveedor> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto_Proveedor>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Producto_Proveedor> GenerarListado(List<Datos.PRODUCTO_PROVEEDOR> listadoDatos)
        {
            List<Producto_Proveedor> listadoEmpresa = new List<Producto_Proveedor>();

            foreach (Datos.PRODUCTO_PROVEEDOR dato in listadoDatos)
            {

                Producto_Proveedor negocio = new Producto_Proveedor();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar compra
        public List<Producto_Proveedor> ReadCompra(int idCompra)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.PRODUCTO_PROVEEDOR> listaDatos =
                    bbdd.PRODUCTO_PROVEEDOR.Where(b => b.ID_COMPRA == idCompra).ToList<Datos.PRODUCTO_PROVEEDOR>();

                List<Producto_Proveedor> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto_Proveedor>();
            }
        }
    }
}
