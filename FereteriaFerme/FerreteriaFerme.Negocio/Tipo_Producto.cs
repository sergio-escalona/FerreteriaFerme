using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Tipo_Producto
    {
        //Campo
        private short _ID_TIPO;
        private string _NOMBRE_TIPO;

        //Propiedades
        public short ID_TIPO { get; set; }
        public string NOMBRE_TIPO { get; set; }

        public Tipo_Producto()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPO = 0;
            NOMBRE_TIPO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.TIPO_PRODUCTO tip = new Datos.TIPO_PRODUCTO();

            try
            {
                CommonBC.Syncronize(this, tip);

                bbdd.TIPO_PRODUCTO.Add(tip);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.TIPO_PRODUCTO.Remove(tip);
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
                Datos.TIPO_PRODUCTO tip = bbdd.TIPO_PRODUCTO.First(e => e.ID_TIPO == ID_TIPO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(tip, this);

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
                Datos.TIPO_PRODUCTO tip = bbdd.TIPO_PRODUCTO.First(e => e.ID_TIPO == ID_TIPO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, tip);

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
                Datos.TIPO_PRODUCTO tip = bbdd.TIPO_PRODUCTO.First(e => e.ID_TIPO == ID_TIPO);

                /* Se elimina el registro del EDM */
                bbdd.TIPO_PRODUCTO.Remove(tip);

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
        public List<Tipo_Producto> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.TIPO_PRODUCTO> listadoDatos = bbdd.TIPO_PRODUCTO.ToList<Datos.TIPO_PRODUCTO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Tipo_Producto> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Producto>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Tipo_Producto> GenerarListado(List<Datos.TIPO_PRODUCTO> listadoDatos)
        {
            List<Tipo_Producto> listadoEmpresa = new List<Tipo_Producto>();

            foreach (Datos.TIPO_PRODUCTO dato in listadoDatos)
            {

                Tipo_Producto negocio = new Tipo_Producto();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Tipo_Producto> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.TIPO_PRODUCTO> listaDatos =
                    bbdd.TIPO_PRODUCTO.Where(b => b.ID_TIPO == id).ToList<Datos.TIPO_PRODUCTO>();

                List<Tipo_Producto> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Producto>();
            }
        }
    }
}
