using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Empresa
    {
        //Campos
        private short? _ID_EMPRESA;
        private string _RAZON_SOCIAL;
        private string _RUT_EMPRESA;
        private short _ID_TIPO;
        private string _descripcionTipo;
        private string _CORREO_EMPRESA;
        private string _RUT_CLIENTE;
        private string _nombreCliente;

        //Propiedades
        public short? ID_EMPRESA { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string RUT_EMPRESA { get; set; }
        public short ID_TIPO { get; set; }
        public string DescripcionTipo { get { return _descripcionTipo; } }
        public string CORREO_EMPRESA { get; set; }
        public string RUT_CLIENTE { get; set; }
        public string NombreCliente { get { return _nombreCliente; } }

        public Empresa()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_EMPRESA = 0;
            RAZON_SOCIAL = string.Empty;
            RUT_EMPRESA = string.Empty;
            ID_TIPO = 0;
            CORREO_EMPRESA = string.Empty;
            RUT_CLIENTE = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.EMPRESA emp = new Datos.EMPRESA();

            try
            {
                CommonBC.Syncronize(this, emp);

                bbdd.EMPRESA.Add(emp);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.EMPRESA.Remove(emp);
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
                Datos.EMPRESA emp = bbdd.EMPRESA.First(e => e.ID_EMPRESA == ID_EMPRESA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(emp, this);

                /* Carga descripción de los Tipos */
                LeerNombreCliente();
                LeerNombreTipo();

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
                Datos.EMPRESA emp = bbdd.EMPRESA.First(e => e.ID_EMPRESA == ID_EMPRESA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, emp);

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
                Datos.EMPRESA emp = bbdd.EMPRESA.First(e => e.ID_EMPRESA == ID_EMPRESA);

                /* Se elimina el registro del EDM */
                bbdd.EMPRESA.Remove(emp);

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
        public List<Empresa> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.EMPRESA> listadoDatos = bbdd.EMPRESA.ToList<Datos.EMPRESA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Empresa> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empresa>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Empresa> GenerarListado(List<Datos.EMPRESA> listadoDatos)
        {
            List<Empresa> listadoEmpresa = new List<Empresa>();

            foreach (Datos.EMPRESA dato in listadoDatos)
            {

                Empresa negocio = new Empresa();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreCliente();
                negocio.LeerNombreTipo();


                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar tipo empresa
        public List<Empresa> ReadTipo(short idTipo)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.EMPRESA> listaDatos =
                    bbdd.EMPRESA.Where(b => b.ID_TIPO == idTipo).ToList<Datos.EMPRESA>();

                List<Empresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empresa>();
            }
        }

        //Mostrar tipo empresa
        public void LeerNombreTipo()
        {
            Tipo_Empresa te = new Tipo_Empresa() { ID_TIPO = ID_TIPO };

            if (te.Read())
            {
                _descripcionTipo = te.NOMBRE_TIPO;
            }
            else
            {
                _descripcionTipo = String.Empty;
            }
        }

        //Buscar usuario
        public List<Empresa> ReadCliente(string rut)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.EMPRESA> listaDatos =
                    bbdd.EMPRESA.Where(b => b.RUT_CLIENTE == rut).ToList<Datos.EMPRESA>();

                List<Empresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empresa>();
            }
        }

        //Mostrar usuario
        public void LeerNombreCliente()
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
    }
}
