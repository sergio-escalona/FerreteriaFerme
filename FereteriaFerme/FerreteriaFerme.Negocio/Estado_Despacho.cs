using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Estado_Despacho
    {
        //Campos
        private short _ID_ESTADO;
        private string _NOMBRE_ESTADO;

        //Propiedades
        public short ID_ESTADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }

        public Estado_Despacho()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_ESTADO = 0;
            NOMBRE_ESTADO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.ESTADO_DESPACHO esd = new Datos.ESTADO_DESPACHO();

            try
            {
                CommonBC.Syncronize(this, esd);

                bbdd.ESTADO_DESPACHO.Add(esd);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.ESTADO_DESPACHO.Remove(esd);
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
                Datos.ESTADO_DESPACHO esd = bbdd.ESTADO_DESPACHO.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(esd, this);

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
                Datos.ESTADO_DESPACHO esd = bbdd.ESTADO_DESPACHO.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, esd);


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
                Datos.ESTADO_DESPACHO esd = bbdd.ESTADO_DESPACHO.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se elimina el registro del EDM */
                bbdd.ESTADO_DESPACHO.Remove(esd);

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
        public List<Estado_Despacho> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.ESTADO_DESPACHO> listadoDatos = bbdd.ESTADO_DESPACHO.ToList<Datos.ESTADO_DESPACHO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Estado_Despacho> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Estado_Despacho>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Estado_Despacho> GenerarListado(List<Datos.ESTADO_DESPACHO> listadoDatos)
        {
            List<Estado_Despacho> listadoEmpresa = new List<Estado_Despacho>();

            foreach (Datos.ESTADO_DESPACHO dato in listadoDatos)
            {

                Estado_Despacho negocio = new Estado_Despacho();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
