using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Region
    {
        //Campos
        private string _ID_REGION;
        private string _NOMBRE_REGION;

        //Propiedades
        public string ID_REGION { get; set; }
        public string NOMBRE_REGION { get; set; }

        public Region()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_REGION = string.Empty;
            NOMBRE_REGION = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.REGION reg = new Datos.REGION();

            try
            {
                CommonBC.Syncronize(this, reg);

                bbdd.REGION.Add(reg);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.REGION.Remove(reg);
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
                Datos.REGION reg = bbdd.REGION.First(e => e.ID_REGION == ID_REGION);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(reg, this);

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
                Datos.REGION reg = bbdd.REGION.First(e => e.ID_REGION == ID_REGION);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, reg);

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
                Datos.REGION reg = bbdd.REGION.First(e => e.ID_REGION == ID_REGION);

                /* Se elimina el registro del EDM */
                bbdd.REGION.Remove(reg);

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
        public List<Region> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.REGION> listadoDatos = bbdd.REGION.ToList<Datos.REGION>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Region> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Region>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Region> GenerarListado(List<Datos.REGION> listadoDatos)
        {
            List<Region> listadoEmpresa = new List<Region>();

            foreach (Datos.REGION dato in listadoDatos)
            {

                Region negocio = new Region();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
