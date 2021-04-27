using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Tipo_Usuario
    {
        //Campo
        private short _ID_TIPOUSU;
        private string _NOMBRE;

        //Propiedades
        public short ID_TIPOUSU { get; set; }
        public string NOMBRE { get; set; }

        public Tipo_Usuario()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPOUSU = 0;
            NOMBRE = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.TIPO_USUARIO tiu = new Datos.TIPO_USUARIO();

            try
            {
                CommonBC.Syncronize(this, tiu);

                bbdd.TIPO_USUARIO.Add(tiu);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.TIPO_USUARIO.Remove(tiu);
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
                Datos.TIPO_USUARIO tiu = bbdd.TIPO_USUARIO.First(e => e.ID_TIPOUSU == ID_TIPOUSU);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(tiu, this);

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
                Datos.TIPO_USUARIO tiu = bbdd.TIPO_USUARIO.First(e => e.ID_TIPOUSU == ID_TIPOUSU);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, tiu);

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
                Datos.TIPO_USUARIO tiu = bbdd.TIPO_USUARIO.First(e => e.ID_TIPOUSU == ID_TIPOUSU);

                /* Se elimina el registro del EDM */
                bbdd.TIPO_USUARIO.Remove(tiu);

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
        public List<Tipo_Usuario> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.TIPO_USUARIO> listadoDatos = bbdd.TIPO_USUARIO.ToList<Datos.TIPO_USUARIO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Tipo_Usuario> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Usuario>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Tipo_Usuario> GenerarListado(List<Datos.TIPO_USUARIO> listadoDatos)
        {
            List<Tipo_Usuario> listadoEmpresa = new List<Tipo_Usuario>();

            foreach (Datos.TIPO_USUARIO dato in listadoDatos)
            {

                Tipo_Usuario negocio = new Tipo_Usuario();
                CommonBC.Syncronize(dato, negocio);


                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Tipo_Usuario> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.TIPO_USUARIO> listaDatos =
                    bbdd.TIPO_USUARIO.Where(b => b.ID_TIPOUSU == id).ToList<Datos.TIPO_USUARIO>();

                List<Tipo_Usuario> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Usuario>();
            }
        }
    }
}
