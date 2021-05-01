using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Comuna
    {
        //Campos
        private short _ID_COMUNA;
        private string _NOMBRE_COMUNA;
        private string _ID_REGION;
        private string _descripcionRegion;

        //Propiedades
        public short ID_COMUNA { get; set; }
        public string NOMBRE_COMUNA { get; set; }
        public string ID_REGION { get; set; }
        public string DescripcionRegion { get { return _descripcionRegion; } }

        public Comuna()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COMUNA = 0;
            NOMBRE_COMUNA = String.Empty;
            ID_REGION = String.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.COMUNA com = new Datos.COMUNA();

            try
            {
                CommonBC.Syncronize(this, com);

                bbdd.COMUNA.Add(com);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.COMUNA.Remove(com);
                return false;
            }

        }

        /// <summary>
        /// Lee un registro de producto en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.COMUNA com = bbdd.COMUNA.First(e => e.ID_COMUNA == ID_COMUNA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(com, this);

                /* Carga descripción de los Tipos */
                LeerNombreRegion();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un registro de producto en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.COMUNA com = bbdd.COMUNA.First(e => e.ID_COMUNA == ID_COMUNA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, com);

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
                Datos.COMUNA com = bbdd.COMUNA.First(e => e.ID_COMUNA == ID_COMUNA);

                /* Se elimina el registro del EDM */
                bbdd.COMUNA.Remove(com);

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
        public List<Comuna> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.COMUNA> listadoDatos = bbdd.COMUNA.ToList<Datos.COMUNA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Comuna> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Comuna>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Comuna> GenerarListado(List<Datos.COMUNA> listadoDatos)
        {
            List<Comuna> listadoEmpresa = new List<Comuna>();

            foreach (Datos.COMUNA dato in listadoDatos)
            {

                Comuna negocio = new Comuna();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreRegion();


                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar region
        public List<Comuna> ReadRegion(string idRegion)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.COMUNA> listaDatos =
                    bbdd.COMUNA.Where(b => b.ID_REGION == idRegion).ToList<Datos.COMUNA>();

                List<Comuna> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Comuna>();
            }
        }

        //Mostrar region
        public void LeerNombreRegion()
        {
            Region re = new Region() { ID_REGION = ID_REGION };

            if (re.Read())
            {
                _descripcionRegion = re.NOMBRE_REGION;
            }
            else
            {
                _descripcionRegion = String.Empty;
            }
        }
    }
}
