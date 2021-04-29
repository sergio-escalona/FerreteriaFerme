using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Cliente
    {
        //Campos
        private string _RUT_CLIENTE;
        private string _NOMBRES;
        private string _APELLIDOS;
        private short _ID_USUARIO;
        private string _nombreUsuario;
        private string _CORREO_CLIENTE;

        //Propiedades
        public string RUT_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public short ID_USUARIO { get; set; }
        public string NombreUsuario { get { return _nombreUsuario; } }
        public string CORREO_CLIENTE { get; set; }

        public Cliente()
        {
            this.init();
        }

        private void init()
        {
            RUT_CLIENTE = string.Empty;
            NOMBRES = string.Empty;
            APELLIDOS = string.Empty;
            ID_USUARIO = 0;
            CORREO_CLIENTE = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.CLIENTE cli = new Datos.CLIENTE();

            try
            {
                CommonBC.Syncronize(this, cli);

                bbdd.CLIENTE.Add(cli);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.CLIENTE.Remove(cli);
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
                Datos.CLIENTE cli = bbdd.CLIENTE.First(e => e.RUT_CLIENTE == RUT_CLIENTE);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(cli, this);

                /* Carga descripción de los Tipos */
                LeerNombreUsuario();

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
                Datos.CLIENTE cli = bbdd.CLIENTE.First(e => e.RUT_CLIENTE == RUT_CLIENTE);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, cli);

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
                Datos.CLIENTE cli = bbdd.CLIENTE.First(e => e.RUT_CLIENTE == RUT_CLIENTE);

                /* Se elimina el registro del EDM */
                bbdd.CLIENTE.Remove(cli);

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
        public List<Cliente> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.CLIENTE> listadoDatos = bbdd.CLIENTE.ToList<Datos.CLIENTE>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Cliente> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Cliente> GenerarListado(List<Datos.CLIENTE> listadoDatos)
        {
            List<Cliente> listadoEmpresa = new List<Cliente>();

            foreach (Datos.CLIENTE dato in listadoDatos)
            {

                Cliente negocio = new Cliente();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreUsuario();


                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar cliente
        public List<Cliente> ReadUsuario(short idUsuario)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.CLIENTE> listaDatos =
                    bbdd.CLIENTE.Where(b => b.ID_USUARIO == idUsuario).ToList<Datos.CLIENTE>();

                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        //Mostrar cliente
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
    }
}
