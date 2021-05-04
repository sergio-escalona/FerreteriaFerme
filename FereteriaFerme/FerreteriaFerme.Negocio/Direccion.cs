using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Direccion
    {
        //Campo
        private int _ID_DIRECCION;
        private string _DIRECCION1;
        private short _ID_COMUNA;
        private string _nombreComuna;
        private string _idRegion;
        private string _RUT_CLIENTE;
        private string _nombreCliente;
        private short? _ID_EMPRESA;
        private string _nombreEmpresa;

        //Propiedades
        public int ID_DIRECCION { get; set; }
        public string DIRECCION1 { get; set; }
        public short ID_COMUNA { get; set; }
        public string IdRegion { get { return _idRegion; } }
        public string NombreComuna { get { return _nombreComuna; } }
        public string RUT_CLIENTE { get; set; }
        public string NombreCliente { get { return _nombreCliente; } }
        public short? ID_EMPRESA { get; set; }
        public string NombreEmpresa { get { return _nombreEmpresa; } }

        public Direccion()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_DIRECCION = 0;
            DIRECCION1 = string.Empty;
            ID_COMUNA = 0;
            RUT_CLIENTE = string.Empty;
            ID_EMPRESA = null;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.DIRECCION dir = new Datos.DIRECCION();

            try
            {
                CommonBC.Syncronize(this, dir);

                bbdd.DIRECCION.Add(dir);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.DIRECCION.Remove(dir);
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
                Datos.DIRECCION dir = bbdd.DIRECCION.First(e => e.ID_DIRECCION == ID_DIRECCION);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(dir, this);

                /* Carga descripción de los Tipos */
                LeerNombreComuna();
                LeerDescripcionCliente();
                LeerDescripcionEmpresa();
                LeerDescripcionRegion();

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
                Datos.DIRECCION dir = bbdd.DIRECCION.First(e => e.ID_DIRECCION == ID_DIRECCION);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, dir);

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
                Datos.DIRECCION dir = bbdd.DIRECCION.First(e => e.ID_DIRECCION == ID_DIRECCION);

                /* Se elimina el registro del EDM */
                bbdd.DIRECCION.Remove(dir);

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
        public List<Direccion> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.DIRECCION> listadoDatos = bbdd.DIRECCION.ToList<Datos.DIRECCION>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Direccion> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Direccion>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Direccion> GenerarListado(List<Datos.DIRECCION> listadoDatos)
        {
            List<Direccion> listadoEmpresa = new List<Direccion>();

            foreach (Datos.DIRECCION dato in listadoDatos)
            {

                Direccion negocio = new Direccion();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreComuna();
                negocio.LeerDescripcionCliente();
                negocio.LeerDescripcionEmpresa();
                negocio.LeerDescripcionRegion();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar direcciones de cliente
        public List<Direccion> ReadRut(string rut)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DIRECCION> listaDatos =
                    bbdd.DIRECCION.Where(b => b.RUT_CLIENTE == rut).ToList<Datos.DIRECCION>();

                List<Direccion> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Direccion>();
            }
        }

        //Listar direcciones empresa
        public List<Direccion> ReadId(short? id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DIRECCION> listaDatos =
                    bbdd.DIRECCION.Where(b => b.ID_EMPRESA == id).ToList<Datos.DIRECCION>();

                List<Direccion> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Direccion>();
            }
        }

        //Buscar comuna
        public List<Direccion> ReadComuna(short idComuna)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DIRECCION> listaDatos =
                    bbdd.DIRECCION.Where(b => b.ID_COMUNA == idComuna).ToList<Datos.DIRECCION>();

                List<Direccion> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Direccion>();
            }
        }

        //Buscar cliente
        public List<Direccion> ReadCliente(string rut)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DIRECCION> listaDatos =
                    bbdd.DIRECCION.Where(b => b.RUT_CLIENTE == rut).ToList<Datos.DIRECCION>();

                List<Direccion> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Direccion>();
            }
        }

        //Buscar empresa
        public List<Direccion> ReadEmpresa(short idEmpresa)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.DIRECCION> listaDatos =
                    bbdd.DIRECCION.Where(b => b.ID_DIRECCION == idEmpresa).ToList<Datos.DIRECCION>();

                List<Direccion> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Direccion>();
            }
        }

        //Mostrar comuna
        public void LeerNombreComuna()
        {
            Comuna co = new Comuna() { ID_COMUNA = ID_COMUNA };

            if (co.Read())
            {
                _nombreComuna = co.NOMBRE_COMUNA;
            }
            else
            {
                _nombreComuna = String.Empty;
            }
        }

        //Mostrar cliente
        public void LeerDescripcionCliente()
        {
            Cliente cl = new Cliente() { RUT_CLIENTE = RUT_CLIENTE };

            if (cl.Read())
            {
                _nombreCliente = cl.NOMBRES+' '+cl.APELLIDOS;
            }
            else
            {
                _nombreCliente = String.Empty;
            }
        }

        //Mostrar empresa
        public void LeerDescripcionEmpresa()
        {
            Empresa em = new Empresa() { ID_EMPRESA = ID_EMPRESA };

            if (em.Read())
            {
                _nombreEmpresa = em.RAZON_SOCIAL;
            }
            else
            {
                _nombreEmpresa = String.Empty;
            }
        }

        //Mostrar empresa
        public void LeerDescripcionRegion()
        {
            Comuna co = new Comuna() { ID_COMUNA = ID_COMUNA };

            if (co.Read())
            {
                _idRegion = co.ID_REGION;
            }
            else
            {
                _idRegion = String.Empty;
            }
        }
    }
}
