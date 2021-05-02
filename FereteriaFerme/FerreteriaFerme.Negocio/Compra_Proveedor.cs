using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Compra_Proveedor
    {
        //Campos
        private int _ID_COMPRA;
        private System.DateTime _FECHA_COMPRA;
        private short _ID_PROVEEDOR;
        private String _descripcionProveedor;

        //Propiedades
        public int ID_COMPRA { get; set; }
        public System.DateTime FECHA_COMPRA { get; set; }
        public short ID_PROVEEDOR { get; set; }
        public String DescripcionProveedor { get { return _descripcionProveedor; } }

        public Compra_Proveedor()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_COMPRA = 0;
            FECHA_COMPRA = DateTime.MinValue;
            ID_PROVEEDOR = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.COMPRA_PROVEEDOR cop = new Datos.COMPRA_PROVEEDOR();

            try
            {
                CommonBC.Syncronize(this, cop);

                bbdd.COMPRA_PROVEEDOR.Add(cop);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.COMPRA_PROVEEDOR.Remove(cop);
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
                Datos.COMPRA_PROVEEDOR cop = bbdd.COMPRA_PROVEEDOR.First(e => e.ID_COMPRA == ID_COMPRA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(cop, this);

                /* Carga descripción de los Tipos */
                LeerNombreProveedor();

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
                Datos.COMPRA_PROVEEDOR cop = bbdd.COMPRA_PROVEEDOR.First(e => e.ID_COMPRA == ID_COMPRA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, cop);

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
                Datos.COMPRA_PROVEEDOR cop = bbdd.COMPRA_PROVEEDOR.First(e => e.ID_COMPRA == ID_COMPRA);

                /* Se elimina el registro del EDM */
                bbdd.COMPRA_PROVEEDOR.Remove(cop);

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
        public List<Compra_Proveedor> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.COMPRA_PROVEEDOR> listadoDatos = bbdd.COMPRA_PROVEEDOR.ToList<Datos.COMPRA_PROVEEDOR>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Compra_Proveedor> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Compra_Proveedor>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Compra_Proveedor> GenerarListado(List<Datos.COMPRA_PROVEEDOR> listadoDatos)
        {
            List<Compra_Proveedor> listadoEmpresa = new List<Compra_Proveedor>();

            foreach (Datos.COMPRA_PROVEEDOR dato in listadoDatos)
            {

                Compra_Proveedor negocio = new Compra_Proveedor();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreProveedor();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar proveedor
        public List<Compra_Proveedor> ReadProveedor(short idProveedor)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.COMPRA_PROVEEDOR> listaDatos =
                    bbdd.COMPRA_PROVEEDOR.Where(b => b.ID_COMPRA == idProveedor).ToList<Datos.COMPRA_PROVEEDOR>();

                List<Compra_Proveedor> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Compra_Proveedor>();
            }
        }

        //Mostrar proveedor
        public void LeerNombreProveedor()
        {
            Proveedor pr = new Proveedor() { ID_PROVEEDOR = ID_PROVEEDOR };

            if (pr.Read())
            {
                _descripcionProveedor = pr.NOMBRE_PROVEEDOR;
            }
            else
            {
                _descripcionProveedor = String.Empty;
            }
        }
    }
}
