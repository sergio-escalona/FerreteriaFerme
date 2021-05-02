using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Empleado
    {
        //Campos
        private string _RUT_EMPLEADO;
        private string _NOMBRES_EMPLEADO;
        private string _APELLIDOS_EMPLEADO;
        private short _ID_CARGO;
        private string _descripcionCargo;
        private short _ID_USUARIO;
        private string _nombreUsuario;

        //Propiedades
        public string RUT_EMPLEADO { get; set; }
        public string NOMBRES_EMPLEADO { get; set; }
        public string APELLIDOS_EMPLEADO { get; set; }
        public string NombreCompleto { get { return NOMBRES_EMPLEADO + " " + APELLIDOS_EMPLEADO; } }
        public short ID_CARGO { get; set; }
        public string DescripcionCargo { get { return _descripcionCargo; } }
        public short ID_USUARIO { get; set; }
        public string NombreUsuario { get { return _nombreUsuario; } }

        public Empleado()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            RUT_EMPLEADO = string.Empty;
            NOMBRES_EMPLEADO = string.Empty;
            APELLIDOS_EMPLEADO = string.Empty;
            ID_CARGO = 0;
            ID_USUARIO = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.EMPLEADO emp = new Datos.EMPLEADO();

            try
            {
                CommonBC.Syncronize(this, emp);

                bbdd.EMPLEADO.Add(emp);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.EMPLEADO.Remove(emp);
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
                Datos.EMPLEADO emp = bbdd.EMPLEADO.First(e => e.RUT_EMPLEADO == RUT_EMPLEADO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(emp, this);

                /* Carga descripción de los Tipos */
                LeerNombreCargo();
                LeerNombreUsuario();

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
                Datos.EMPLEADO emp = bbdd.EMPLEADO.First(e => e.RUT_EMPLEADO == RUT_EMPLEADO);

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
        /// Elimina un registro de proveedor en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene el primer registro coincidente con el id */
                Datos.EMPLEADO emp = bbdd.EMPLEADO.First(e => e.RUT_EMPLEADO == RUT_EMPLEADO);

                /* Se elimina el registro del EDM */
                bbdd.EMPLEADO.Remove(emp);

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
        public List<Empleado> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.EMPLEADO> listadoDatos = bbdd.EMPLEADO.ToList<Datos.EMPLEADO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Empleado> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empleado>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Empleado> GenerarListado(List<Datos.EMPLEADO> listadoDatos)
        {
            List<Empleado> listadoEmpresa = new List<Empleado>();

            foreach (Datos.EMPLEADO dato in listadoDatos)
            {

                Empleado negocio = new Empleado();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreCargo();
                negocio.LeerNombreUsuario();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Empleado> ReadRut(string rut)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.EMPLEADO> listaDatos =
                    bbdd.EMPLEADO.Where(b => b.RUT_EMPLEADO == rut).ToList<Datos.EMPLEADO>();

                List<Empleado> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empleado>();
            }
        }

        //Buscar usuario
        public List<Empleado> ReadUsuario(short idUsuario)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.EMPLEADO> listaDatos =
                    bbdd.EMPLEADO.Where(b => b.ID_USUARIO == idUsuario).ToList<Datos.EMPLEADO>();

                List<Empleado> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empleado>();
            }
        }

        //Mostrar usuario
        public void LeerNombreUsuario()
        {
            Usuario us = new Usuario() { ID_USUARIO = ID_USUARIO };

            if (us.Read())
            {
                _nombreUsuario = us.NOMBRE_USUARIO;
            }
            else
            {
                _nombreUsuario = String.Empty;
            }
        }

        //Buscar cargo
        public List<Empleado> ReadCargo(short idCargo)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.EMPLEADO> listaDatos =
                    bbdd.EMPLEADO.Where(b => b.ID_CARGO == idCargo).ToList<Datos.EMPLEADO>();

                List<Empleado> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Empleado>();
            }
        }

        //Mostrar cargo
        public void LeerNombreCargo()
        {
            Cargo ca = new Cargo() { ID_CARGO = ID_CARGO };

            if (ca.Read())
            {
                _descripcionCargo = ca.NOMBRE_CARGO;
            }
            else
            {
                _descripcionCargo = String.Empty;
            }
        }
    }
}
