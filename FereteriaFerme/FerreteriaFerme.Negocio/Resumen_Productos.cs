using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Resumen_Productos
    {
        //Campos
        private int _ID_RESPRO;
        private int _MES_ANNO;
        private long _ID_PRODUCTO;
        private string _NOMBRE_PRODUCTO;
        private string _TIPO_PRODUCTO;
        private string _FAMILIA_PRODUCTO;
        private short _CANTIDAD;

        //Propiedades
        public int ID_RESPRO { get; set; }
        public int MES_ANNO { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string TIPO_PRODUCTO { get; set; }
        public string FAMILIA_PRODUCTO { get; set; }
        public short CANTIDAD { get; set; }

        public Resumen_Productos()
        {
            this.init();
        }

        //Cosntructor
        private void init()
        {
            ID_RESPRO = 0;
            MES_ANNO = 0;
            ID_PRODUCTO = 0;
            NOMBRE_PRODUCTO = string.Empty;
            TIPO_PRODUCTO = string.Empty;
            FAMILIA_PRODUCTO = string.Empty;
            CANTIDAD = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.RESUMEN_PRODUCTOS rep = new Datos.RESUMEN_PRODUCTOS();

            try
            {
                CommonBC.Syncronize(this, rep);

                bbdd.RESUMEN_PRODUCTOS.Add(rep);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.RESUMEN_PRODUCTOS.Remove(rep);
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
                Datos.RESUMEN_PRODUCTOS rep = bbdd.RESUMEN_PRODUCTOS.First(e => e.ID_RESPRO == ID_RESPRO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(rep, this);

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
                Datos.RESUMEN_PRODUCTOS rep = bbdd.RESUMEN_PRODUCTOS.First(e => e.ID_RESPRO == ID_RESPRO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, rep);

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
                Datos.RESUMEN_PRODUCTOS rep = bbdd.RESUMEN_PRODUCTOS.First(e => e.ID_RESPRO == ID_RESPRO);

                /* Se elimina el registro del EDM */
                bbdd.RESUMEN_PRODUCTOS.Remove(rep);

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
        public List<Resumen_Productos> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.RESUMEN_PRODUCTOS> listadoDatos = bbdd.RESUMEN_PRODUCTOS.ToList<Datos.RESUMEN_PRODUCTOS>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Resumen_Productos> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Resumen_Productos>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Resumen_Productos> GenerarListado(List<Datos.RESUMEN_PRODUCTOS> listadoDatos)
        {
            List<Resumen_Productos> listadoEmpresa = new List<Resumen_Productos>();

            foreach (Datos.RESUMEN_PRODUCTOS dato in listadoDatos)
            {

                Resumen_Productos negocio = new Resumen_Productos();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar periodo
        public List<Resumen_Productos> ReadPeriodo(int periodo)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.RESUMEN_PRODUCTOS> listaDatos =
                    bbdd.RESUMEN_PRODUCTOS.Where(b => b.MES_ANNO == periodo).ToList<Datos.RESUMEN_PRODUCTOS>();

                List<Resumen_Productos> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Resumen_Productos>();
            }
        }

        //Buscar año
        public List<Resumen_Productos> ReadAño(int anno)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.RESUMEN_PRODUCTOS> listaDatos =
                    bbdd.RESUMEN_PRODUCTOS.Where(b => b.MES_ANNO == anno).ToList<Datos.RESUMEN_PRODUCTOS>();

                List<Resumen_Productos> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Resumen_Productos>();
            }
        }
    }
}
