using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Estado_Recepcion
    {
        //Campos
        private int _ID_ESTADO;
        private string _ESTADO;

        //Propiedades
        public int ID_ESTADO { get; set; }
        public string ESTADO { get; set; }

        public Estado_Recepcion()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_ESTADO = 0;
            ESTADO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.ESTADO_RECEPCION esr = new Datos.ESTADO_RECEPCION();

            try
            {
                CommonBC.Syncronize(this, esr);

                bbdd.ESTADO_RECEPCION.Add(esr);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.ESTADO_RECEPCION.Remove(esr);
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
                Datos.ESTADO_RECEPCION esr = bbdd.ESTADO_RECEPCION.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(esr, this);

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
                Datos.ESTADO_RECEPCION esr = bbdd.ESTADO_RECEPCION.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, esr);

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
                Datos.ESTADO_RECEPCION esr = bbdd.ESTADO_RECEPCION.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se elimina el registro del EDM */
                bbdd.ESTADO_RECEPCION.Remove(esr);

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
        public List<Estado_Recepcion> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.ESTADO_RECEPCION> listadoDatos = bbdd.ESTADO_RECEPCION.ToList<Datos.ESTADO_RECEPCION>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Estado_Recepcion> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Estado_Recepcion>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Estado_Recepcion> GenerarListado(List<Datos.ESTADO_RECEPCION> listadoDatos)
        {
            List<Estado_Recepcion> listadoEmpresa = new List<Estado_Recepcion>();

            foreach (Datos.ESTADO_RECEPCION dato in listadoDatos)
            {

                Estado_Recepcion negocio = new Estado_Recepcion();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
