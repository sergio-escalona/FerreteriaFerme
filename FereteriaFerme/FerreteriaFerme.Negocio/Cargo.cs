using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Cargo
    {
        //Campos
        private short _ID_CARGO;
        private string _NOMBRE_CARGO;

        //Propiedades
        public short ID_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }

        public Cargo()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_CARGO = 0;
            NOMBRE_CARGO = string.Empty;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.CARGO car = new Datos.CARGO();

            try
            {
                CommonBC.Syncronize(this, car);

                bbdd.CARGO.Add(car);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.CARGO.Remove(car);
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
                Datos.CARGO car = bbdd.CARGO.First(e => e.ID_CARGO == ID_CARGO);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(car, this);

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
                Datos.CARGO car = bbdd.CARGO.First(e => e.ID_CARGO == ID_CARGO);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, car);

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
                Datos.CARGO car = bbdd.CARGO.First(e => e.ID_CARGO == ID_CARGO);

                /* Se elimina el registro del EDM */
                bbdd.CARGO.Remove(car);

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
        public List<Cargo> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.CARGO> listadoDatos = bbdd.CARGO.ToList<Datos.CARGO>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Cargo> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Cargo>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Cargo> GenerarListado(List<Datos.CARGO> listadoDatos)
        {
            List<Cargo> listadoEmpresa = new List<Cargo>();

            foreach (Datos.CARGO dato in listadoDatos)
            {

                Cargo negocio = new Cargo();
                CommonBC.Syncronize(dato, negocio);


                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Listar productos
        public List<Cargo> ReadId(short id)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.CARGO> listaDatos =
                    bbdd.CARGO.Where(b => b.ID_CARGO == id).ToList<Datos.CARGO>();

                List<Cargo> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Cargo>();
            }
        }
    }
}
