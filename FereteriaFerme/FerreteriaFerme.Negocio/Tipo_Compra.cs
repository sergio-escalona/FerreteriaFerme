using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Tipo_Compra
    {
        //Campos
        private short _ID_TIPOCOM;
        private string _NOMBRE;

        //Propiedades
        public short ID_TIPOCOM { get; set; }
        public string NOMBRE { get; set; }

        public Tipo_Compra()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_TIPOCOM = 0;
            NOMBRE = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.TIPO_COMPRA tic = new Datos.TIPO_COMPRA();

            try
            {
                CommonBC.Syncronize(this, tic);

                bbdd.TIPO_COMPRA.Add(tic);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.TIPO_COMPRA.Remove(tic);
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
                Datos.TIPO_COMPRA tic = bbdd.TIPO_COMPRA.First(e => e.ID_TIPOCOM == ID_TIPOCOM);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(tic, this);

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
                Datos.TIPO_COMPRA tic = bbdd.TIPO_COMPRA.First(e => e.ID_TIPOCOM == ID_TIPOCOM);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, tic);

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
                Datos.TIPO_COMPRA tic = bbdd.TIPO_COMPRA.First(e => e.ID_TIPOCOM == ID_TIPOCOM);

                /* Se elimina el registro del EDM */
                bbdd.TIPO_COMPRA.Remove(tic);

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
        public List<Tipo_Compra> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.TIPO_COMPRA> listadoDatos = bbdd.TIPO_COMPRA.ToList<Datos.TIPO_COMPRA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Tipo_Compra> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Compra>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Tipo_Compra> GenerarListado(List<Datos.TIPO_COMPRA> listadoDatos)
        {
            List<Tipo_Compra> listadoEmpresa = new List<Tipo_Compra>();

            foreach (Datos.TIPO_COMPRA dato in listadoDatos)
            {

                Tipo_Compra negocio = new Tipo_Compra();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Tipo_Compra> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.TIPO_COMPRA> listaDatos =
                    bbdd.TIPO_COMPRA.Where(b => b.ID_TIPOCOM == id).ToList<Datos.TIPO_COMPRA>();

                List<Tipo_Compra> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Tipo_Compra>();
            }
        }
    }
}
