using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Familia_Producto
    {
        //Campos
        private short _ID_FAMILIA;
        private string _NOMBRE_FAMILIA;

        //Propiedades
        public short ID_FAMILIA { get; set; }
        public string NOMBRE_FAMILIA { get; set; }

        public Familia_Producto()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_FAMILIA = 0;
            NOMBRE_FAMILIA = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.PROVEEDOR pro = new Datos.PROVEEDOR();

            try
            {
                CommonBC.Syncronize(this, pro);

                bbdd.PROVEEDOR.Add(pro);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.PROVEEDOR.Remove(pro);
                return false;
            }

        }

        /// <summary>
        /// Lee un registro de familia en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.FAMILIA_PRODUCTO fam = bbdd.FAMILIA_PRODUCTO.First(e => e.ID_FAMILIA == ID_FAMILIA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(fam, this);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un registro de familia en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.FAMILIA_PRODUCTO fam = bbdd.FAMILIA_PRODUCTO.First(e => e.ID_FAMILIA == ID_FAMILIA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, fam);

                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un registro de familia en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.FAMILIA_PRODUCTO fam = bbdd.FAMILIA_PRODUCTO.First(e => e.ID_FAMILIA == ID_FAMILIA);

                /* Se elimina el registro del EDM */
                bbdd.FAMILIA_PRODUCTO.Remove(fam);

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
        public List<Familia_Producto> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.FAMILIA_PRODUCTO> listadoDatos = bbdd.FAMILIA_PRODUCTO.ToList<Datos.FAMILIA_PRODUCTO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Familia_Producto> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Familia_Producto>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Familia_Producto> GenerarListado(List<Datos.FAMILIA_PRODUCTO> listadoDatos)
        {
            List<Familia_Producto> listadoEmpresa = new List<Familia_Producto>();

            foreach (Datos.FAMILIA_PRODUCTO dato in listadoDatos)
            {

                Familia_Producto negocio = new Familia_Producto();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Familia_Producto> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.FAMILIA_PRODUCTO> listaDatos =
                    bbdd.FAMILIA_PRODUCTO.Where(b => b.ID_FAMILIA == id).ToList<Datos.FAMILIA_PRODUCTO>();

                List<Familia_Producto> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Familia_Producto>();
            }
        }
    }
}
