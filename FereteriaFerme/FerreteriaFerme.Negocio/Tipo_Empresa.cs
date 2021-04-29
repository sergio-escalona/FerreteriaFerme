using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Tipo_Empresa
    {
        //Campos
        private short _ID_TIPO;
        private string _NOMBRE_TIPO;

        //Propiedades
        public short ID_TIPO { get; set; }
        public string NOMBRE_TIPO { get; set; }

        public Tipo_Empresa()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPO = 0;
            NOMBRE_TIPO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.TIPO_EMPRESA tie = new Datos.TIPO_EMPRESA();

            try
            {
                CommonBC.Syncronize(this, tie);

                bbdd.TIPO_EMPRESA.Add(tie);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.TIPO_EMPRESA.Remove(tie);
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
                Datos.TIPO_EMPRESA tie = bbdd.TIPO_EMPRESA.First(e => e.ID_TIPO == ID_TIPO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(tie, this);

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
                Datos.TIPO_EMPRESA tie = bbdd.TIPO_EMPRESA.First(e => e.ID_TIPO == ID_TIPO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, tie);

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
                Datos.TIPO_EMPRESA tie = bbdd.TIPO_EMPRESA.First(e => e.ID_TIPO == ID_TIPO);

                /* Se elimina el registro del EDM */
                bbdd.TIPO_EMPRESA.Remove(tie);

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
        public List<Tipo_Empresa> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.TIPO_EMPRESA> listadoDatos = bbdd.TIPO_EMPRESA.ToList<Datos.TIPO_EMPRESA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Tipo_Empresa> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Empresa>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Tipo_Empresa> GenerarListado(List<Datos.TIPO_EMPRESA> listadoDatos)
        {
            List<Tipo_Empresa> listadoEmpresa = new List<Tipo_Empresa>();

            foreach (Datos.TIPO_EMPRESA dato in listadoDatos)
            {

                Tipo_Empresa negocio = new Tipo_Empresa();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }
    }
}
