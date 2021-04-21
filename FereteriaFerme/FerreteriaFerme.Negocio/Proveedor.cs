using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Proveedor
    {
        //Campos
        private short _ID_PROVEEDOR;
        private string _NOMBRE_PROVEEDOR;
        private string _RUT_PROVEEDOR;
        private long _CELULAR;
        private string _CORREO;

        //Propiedades
        public short ID_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string RUT_PROVEEDOR { get; set; }
        public long CELULAR { get; set; }
        public string CORREO { get; set; }

        public Proveedor()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_PROVEEDOR = 0;
            NOMBRE_PROVEEDOR = string.Empty;
            RUT_PROVEEDOR = string.Empty;
            CELULAR = 0;
            CORREO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.PROVEEDOR pro = new Datos.PROVEEDOR();

            try
            {
                CommonBC.Syncronize(this, pro);

                bbdd.PROVEEDOR.Add(pro);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.PROVEEDOR.Remove(pro);
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
                Datos.PROVEEDOR pro = bbdd.PROVEEDOR.First(e => e.ID_PROVEEDOR == ID_PROVEEDOR);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(pro, this);

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
                Datos.PROVEEDOR pro = bbdd.PROVEEDOR.First(e => e.ID_PROVEEDOR == ID_PROVEEDOR);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, pro);

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
                Datos.PROVEEDOR pro = bbdd.PROVEEDOR.First(e => e.ID_PROVEEDOR == ID_PROVEEDOR);

                /* Se elimina el registro del EDM */
                bbdd.PROVEEDOR.Remove(pro);

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
        public List<Proveedor> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.PROVEEDOR> listadoDatos = bbdd.PROVEEDOR.ToList<Datos.PROVEEDOR>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Proveedor> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Proveedor>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Proveedor> GenerarListado(List<Datos.PROVEEDOR> listadoDatos)
        {
            List<Proveedor> listadoEmpresa = new List<Proveedor>();

            foreach (Datos.PROVEEDOR dato in listadoDatos)
            {

                Proveedor negocio = new Proveedor();
                CommonBC.Syncronize(dato, negocio);

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Proveedor> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.PROVEEDOR> listaDatos =
                    bbdd.PROVEEDOR.Where(b => b.ID_PROVEEDOR == id).ToList<Datos.PROVEEDOR>();

                List<Proveedor> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Proveedor>();
            }
        }
    }
}
