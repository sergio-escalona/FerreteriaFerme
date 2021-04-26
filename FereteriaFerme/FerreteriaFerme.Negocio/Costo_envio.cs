using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Costo_envio
    {
        //Campo
        private short _ID_COSTOENVIO;
        private string _NOMBRE;
        private int _VALOR;

        //Propiedades
        public short ID_COSTOENVIO { get; set; }
        public string NOMBRE { get; set; }
        public int VALOR { get; set; }

        public Costo_envio()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COSTOENVIO = 0;
            NOMBRE = String.Empty;
            VALOR = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.COSTO_ENVIO coe = new Datos.COSTO_ENVIO();

            try
            {
                CommonBC.Syncronize(this, coe);

                bbdd.COSTO_ENVIO.Add(coe);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.COSTO_ENVIO.Remove(coe);
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
                Datos.COSTO_ENVIO coe = bbdd.COSTO_ENVIO.First(e => e.ID_COSTOENVIO == ID_COSTOENVIO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(coe, this);

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
                Datos.COSTO_ENVIO coe = bbdd.COSTO_ENVIO.First(e => e.ID_COSTOENVIO == ID_COSTOENVIO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, coe);

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
                Datos.COSTO_ENVIO coe = bbdd.COSTO_ENVIO.First(e => e.ID_COSTOENVIO == ID_COSTOENVIO);

                /* Se elimina el registro del EDM */
                bbdd.COSTO_ENVIO.Remove(coe);

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
        public List<Costo_envio> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.COSTO_ENVIO> listadoDatos = bbdd.COSTO_ENVIO.ToList<Datos.COSTO_ENVIO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Costo_envio> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Costo_envio>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Costo_envio> GenerarListado(List<Datos.COSTO_ENVIO> listadoDatos)
        {
            List<Costo_envio> listadoEmpresa = new List<Costo_envio>();

            foreach (Datos.COSTO_ENVIO dato in listadoDatos)
            {

                Costo_envio negocio = new Costo_envio();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Costo_envio> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.COSTO_ENVIO> listaDatos =
                    bbdd.COSTO_ENVIO.Where(b => b.ID_COSTOENVIO == id).ToList<Datos.COSTO_ENVIO>();

                List<Costo_envio> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Costo_envio>();
            }
        }
    }
}
