using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Estado_Compra
    {
        //Campos
        private int _ID_ESTADO;
        private string _ESTADO;

        //Propiedades
        public int ID_ESTADO { get; set; }
        public string ESTADO { get; set; }

        public Estado_Compra()
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

            Datos.ESTADO_COMPRA esc = new Datos.ESTADO_COMPRA();

            try
            {
                CommonBC.Syncronize(this, esc);

                bbdd.ESTADO_COMPRA.Add(esc);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.ESTADO_COMPRA.Remove(esc);
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
                Datos.ESTADO_COMPRA esc = bbdd.ESTADO_COMPRA.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(esc, this);

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
                Datos.ESTADO_COMPRA esc = bbdd.ESTADO_COMPRA.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, esc);

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
                Datos.ESTADO_COMPRA esc = bbdd.ESTADO_COMPRA.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se elimina el registro del EDM */
                bbdd.ESTADO_COMPRA.Remove(esc);

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
        public List<Estado_Compra> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.ESTADO_COMPRA> listadoDatos = bbdd.ESTADO_COMPRA.ToList<Datos.ESTADO_COMPRA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Estado_Compra> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Estado_Compra>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Estado_Compra> GenerarListado(List<Datos.ESTADO_COMPRA> listadoDatos)
        {
            List<Estado_Compra> listadoEmpresa = new List<Estado_Compra>();

            foreach (Datos.ESTADO_COMPRA dato in listadoDatos)
            {

                Estado_Compra negocio = new Estado_Compra();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
