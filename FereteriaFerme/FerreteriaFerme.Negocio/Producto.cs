using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerreteriaFerme.Datos;

namespace FerreteriaFerme.Negocio
{
    public class Producto
    {
        //Campos
        private long _ID_PRODUCTO;
        private string _NOMBRE_PRODUCTO;
        private short _ID_PROVEEDOR;
        private string _nombreProveedor;
        private short _ID_FAMILIA;
        private string _descripcionFamilia;
        private Nullable<System.DateTime> _FECHA_VENCIMIENTO;
        private short _ID_TIPO;
        private string _descripcionTipo;
        private string _DESCRIPCION;
        private int _PRECIO_CLP;
        private int _PRECIO_USD;
        private short _STOCK;
        private byte[] _FOTO;

        //Propiedades
        public long ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public short ID_PROVEEDOR { get; set; }
        public string NombreProveedor { get { return _nombreProveedor; } }
        public short ID_FAMILIA { get; set; }
        public string DescripcionFamilia { get { return _descripcionFamilia; } }
        public Nullable<System.DateTime> FECHA_VENCIMIENTO { get; set; }
        public short ID_TIPO { get; set; }
        public string DescripcionTipo { get { return _descripcionTipo; } }
        public string DESCRIPCION { get; set; }
        public int PRECIO_CLP { get; set; }
        public int PRECIO_USD { get; set; }
        public short STOCK { get; set; }
        public byte[] FOTO { get; set; }

        public Producto()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_PRODUCTO = 0;
            NOMBRE_PRODUCTO = string.Empty;
            ID_PROVEEDOR = 0;
            ID_FAMILIA = 0;
            FECHA_VENCIMIENTO = null;
            ID_TIPO = 0;
            DESCRIPCION = string.Empty;
            PRECIO_CLP = 0;
            PRECIO_USD = 0;
            STOCK = 0;
            FOTO = new byte[0];
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.PRODUCTO pro = new Datos.PRODUCTO();

            try
            {
                CommonBC.Syncronize(this, pro);

                bbdd.PRODUCTO.Add(pro);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.PRODUCTO.Remove(pro);
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
                Datos.PRODUCTO pro = bbdd.PRODUCTO.First(e => e.ID_PRODUCTO == ID_PRODUCTO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(pro, this);

                /* Carga descripción de los Tipos */
                LeerNombreProveedor();
                LeerDescripcionFamilia();
                LeerDescripcionTipo();

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
                Datos.PRODUCTO pro = bbdd.PRODUCTO.First(e => e.ID_PRODUCTO == ID_PRODUCTO);

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
        /// Elimina un registro de producto en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.PRODUCTO pro = bbdd.PRODUCTO.First(e => e.ID_PRODUCTO == ID_PRODUCTO);

                /* Se elimina el registro del EDM */
                bbdd.PRODUCTO.Remove(pro);

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
        public List<Producto> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.PRODUCTO> listadoDatos = bbdd.PRODUCTO.ToList<Datos.PRODUCTO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Producto> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Producto> GenerarListado(List<Datos.PRODUCTO> listadoDatos)
        {
            List<Producto> listadoEmpresa = new List<Producto>();

            foreach (Datos.PRODUCTO dato in listadoDatos)
            {

                Producto negocio = new Producto();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreProveedor();
                negocio.LeerDescripcionFamilia();
                negocio.LeerDescripcionTipo();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Producto> ReadId(long id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.PRODUCTO> listaDatos =
                    bbdd.PRODUCTO.Where(b => b.ID_PRODUCTO == id).ToList<Datos.PRODUCTO>();

                List<Producto> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto>();
            }
        }

        //Buscar proveedor
        public List<Producto> ReadProveedor(short idProveedor)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.PRODUCTO> listaDatos =
                    bbdd.PRODUCTO.Where(b => b.ID_PROVEEDOR == idProveedor).ToList<Datos.PRODUCTO>();

                List<Producto> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto>();
            }
        }

        //Buscar familia
        public List<Producto> ReadFamilia(short idFamilia)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.PRODUCTO> listaDatos =
                    bbdd.PRODUCTO.Where(b => b.ID_FAMILIA == idFamilia).ToList<Datos.PRODUCTO>();

                List<Producto> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto>();
            }
        }

        //Buscar tipo
        public List<Producto> ReadTipo(short idTipo)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.PRODUCTO> listaDatos =
                    bbdd.PRODUCTO.Where(b => b.ID_TIPO == idTipo).ToList<Datos.PRODUCTO>();

                List<Producto> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Producto>();
            }
        }

        //Mostrar Proveedor
        public void LeerNombreProveedor()
        {
            Proveedor pv = new Proveedor() { ID_PROVEEDOR = ID_PROVEEDOR };

            if (pv.Read())
            {
                _nombreProveedor = pv.NOMBRE_PROVEEDOR;
            }
            else
            {
                _nombreProveedor = String.Empty;
            }
        }

        //Mostrar Familia
        public void LeerDescripcionFamilia()
        {
            Familia_Producto fp = new Familia_Producto() { ID_FAMILIA = ID_FAMILIA };

            if (fp.Read())
            {
                _descripcionFamilia = fp.NOMBRE_FAMILIA;
            }
            else
            {
                _descripcionFamilia = String.Empty;
            }
        }

        //Mostrar Tipo
        public void LeerDescripcionTipo()
        {
            Tipo_Producto tp = new Tipo_Producto() { ID_TIPO = ID_TIPO };

            if (tp.Read())
            {
                _descripcionTipo = tp.NOMBRE_TIPO;
            }
            else
            {
                _descripcionTipo = String.Empty;
            }
        }
    }
}
