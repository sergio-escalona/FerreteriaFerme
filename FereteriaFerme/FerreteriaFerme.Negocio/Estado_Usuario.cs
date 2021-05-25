using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    class Estado_Usuario
    {
        //Campos
        private short _ID_ESTADO;
        private string _ESTADO;

        //Propiedades
        public short ID_ESTADO { get; set; }
        public string ESTADO { get; set; }

        public Estado_Usuario()
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

            Datos.ESTADO_USUARIO esu = new Datos.ESTADO_USUARIO();

            try
            {
                CommonBC.Syncronize(this, esu);

                bbdd.ESTADO_USUARIO.Add(esu);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.ESTADO_USUARIO.Remove(esu);
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
                Datos.ESTADO_USUARIO esu = bbdd.ESTADO_USUARIO.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(esu, this);

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
                Datos.ESTADO_USUARIO esu = bbdd.ESTADO_USUARIO.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, esu);

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
                Datos.ESTADO_USUARIO esu = bbdd.ESTADO_USUARIO.First(e => e.ID_ESTADO == ID_ESTADO);

                /* Se elimina el registro del EDM */
                bbdd.ESTADO_USUARIO.Remove(esu);

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
        public List<Estado_Usuario> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.ESTADO_USUARIO> listadoDatos = bbdd.ESTADO_USUARIO.ToList<Datos.ESTADO_USUARIO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Estado_Usuario> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Estado_Usuario>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Estado_Usuario> GenerarListado(List<Datos.ESTADO_USUARIO> listadoDatos)
        {
            List<Estado_Usuario> listadoEmpresa = new List<Estado_Usuario>();

            foreach (Datos.ESTADO_USUARIO dato in listadoDatos)
            {

                Estado_Usuario negocio = new Estado_Usuario();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
