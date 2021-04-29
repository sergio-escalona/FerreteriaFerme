using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Medio_Pago
    {
        //Campos
        private short _ID_MEDIO;
        private string _NOMBRE_MEDIO;

        //Propiedades
        public short ID_MEDIO { get; set; }
        public string NOMBRE_MEDIO { get; set; }

        public Medio_Pago()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_MEDIO = 0;
            NOMBRE_MEDIO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.MEDIO_PAGO mep = new Datos.MEDIO_PAGO();

            try
            {
                CommonBC.Syncronize(this, mep);

                bbdd.MEDIO_PAGO.Add(mep);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.MEDIO_PAGO.Remove(mep);
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
                Datos.MEDIO_PAGO mep = bbdd.MEDIO_PAGO.First(e => e.ID_MEDIO == ID_MEDIO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(mep, this);

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
                Datos.MEDIO_PAGO mep = bbdd.MEDIO_PAGO.First(e => e.ID_MEDIO == ID_MEDIO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, mep);

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
                Datos.MEDIO_PAGO mep = bbdd.MEDIO_PAGO.First(e => e.ID_MEDIO == ID_MEDIO);

                /* Se elimina el registro del EDM */
                bbdd.MEDIO_PAGO.Remove(mep);

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
        public List<Medio_Pago> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.MEDIO_PAGO> listadoDatos = bbdd.MEDIO_PAGO.ToList<Datos.MEDIO_PAGO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Medio_Pago> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Medio_Pago>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Medio_Pago> GenerarListado(List<Datos.MEDIO_PAGO> listadoDatos)
        {
            List<Medio_Pago> listadoEmpresa = new List<Medio_Pago>();

            foreach (Datos.MEDIO_PAGO dato in listadoDatos)
            {

                Medio_Pago negocio = new Medio_Pago();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
