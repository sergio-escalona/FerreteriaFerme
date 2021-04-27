using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Usuario
    {
        //Campos
        private short _ID_USUARIO;
        private string _NOMBRE_USUARIO;
        private string _CONTRASENA;
        private short _ID_TIPOUSU;
        private string _descripcionTipo;

        //Propiedades
        public short ID_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public short ID_TIPOUSU { get; set; }
        public string DescripcionTipo { get { return _descripcionTipo; } }

        public Usuario()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_USUARIO = 0;
            NOMBRE_USUARIO = string.Empty;
            CONTRASENA = string.Empty;
            ID_TIPOUSU = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.USUARIO usu = new Datos.USUARIO();

            try
            {
                CommonBC.Syncronize(this, usu);

                bbdd.USUARIO.Add(usu);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.USUARIO.Remove(usu);
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
                Datos.USUARIO usu = bbdd.USUARIO.First(e => e.ID_USUARIO == ID_USUARIO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(usu, this);

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
                Datos.USUARIO usu = bbdd.USUARIO.First(e => e.ID_USUARIO == ID_USUARIO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, usu);

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
                Datos.USUARIO usu = bbdd.USUARIO.First(e => e.ID_USUARIO == ID_USUARIO);

                /* Se elimina el registro del EDM */
                bbdd.USUARIO.Remove(usu);

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
        public List<Usuario> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.USUARIO> listadoDatos = bbdd.USUARIO.ToList<Datos.USUARIO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Usuario> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Usuario> GenerarListado(List<Datos.USUARIO> listadoDatos)
        {
            List<Usuario> listadoEmpresa = new List<Usuario>();

            foreach (Datos.USUARIO dato in listadoDatos)
            {

                Usuario negocio = new Usuario();
                CommonBC.Syncronize(dato, negocio);


                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Usuario> ReadNombre(string nombre)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.USUARIO> listaDatos =
                    bbdd.USUARIO.Where(b => b.NOMBRE_USUARIO == nombre).ToList<Datos.USUARIO>();

                List<Usuario> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }

        //Buscar proveedor
        public List<Usuario> ReadTipo(short idTipo)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.USUARIO> listaDatos =
                    bbdd.USUARIO.Where(b => b.ID_TIPOUSU == idTipo).ToList<Datos.USUARIO>();

                List<Usuario> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }

        //Mostrar Proveedor
        public void LeerNombreProveedor()
        {
            Tipo_Usuario tu = new Tipo_Usuario() { ID_TIPOUSU = ID_TIPOUSU };

            if (tu.Read())
            {
                _descripcionTipo = tu.NOMBRE;
            }
            else
            {
                _descripcionTipo = String.Empty;
            }
        }
    }
}
