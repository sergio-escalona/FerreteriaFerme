using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Boleta
    {
        //Campos
        private int _ID_BOLETA;
        private System.DateTime _FECHA_BOLETA;
        private int _NETO_BOLETA;
        private int _IVA_BOLETA;
        private int _TOTAL_BOLETA;
        private decimal _ID_COMPRA;
        private string _RUT_CLIENTE;
        private short _ID_MEDIO;
        private String _descripcionMedio;


        //Propiedades
        public int ID_BOLETA { get; set; }
        public System.DateTime FECHA_BOLETA { get; set; }
        public int NETO_BOLETA { get; set; }
        public int IVA_BOLETA { get; set; }
        public int TOTAL_BOLETA { get; set; }
        public decimal ID_COMPRA { get; set; }
        public string RUT_CLIENTE { get; set; }
        public short ID_MEDIO { get; set; }
        public String DescripcionMedio { get { return _descripcionMedio; } }

        public Boleta()
        {
            this.init();
        }

        //Constructor
        private void init()
        {
            ID_BOLETA = 0;
            FECHA_BOLETA = DateTime.MinValue;
            NETO_BOLETA = 0;
            IVA_BOLETA = 0;
            TOTAL_BOLETA = 0;
            ID_COMPRA = 0;
            RUT_CLIENTE = string.Empty;
            ID_MEDIO = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.BOLETA bol = new Datos.BOLETA();

            try
            {
                CommonBC.Syncronize(this, bol);

                bbdd.BOLETA.Add(bol);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.BOLETA.Remove(bol);
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
                Datos.BOLETA bol = bbdd.BOLETA.First(e => e.ID_BOLETA == ID_BOLETA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(bol, this);

                /* Carga descripción de los Tipos */
                LeerNombreMedio();

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
                Datos.BOLETA bol = bbdd.BOLETA.First(e => e.ID_BOLETA == ID_BOLETA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, bol);

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
                Datos.BOLETA bol = bbdd.BOLETA.First(e => e.ID_BOLETA == ID_BOLETA);

                /* Se elimina el registro del EDM */
                bbdd.BOLETA.Remove(bol);

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
        public List<Boleta> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.BOLETA> listadoDatos = bbdd.BOLETA.ToList<Datos.BOLETA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Boleta> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Boleta>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Boleta> GenerarListado(List<Datos.BOLETA> listadoDatos)
        {
            List<Boleta> listadoEmpresa = new List<Boleta>();

            foreach (Datos.BOLETA dato in listadoDatos)
            {

                Boleta negocio = new Boleta();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreMedio();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar proveedor
        public List<Boleta> ReadMedio(short idMedio)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.BOLETA> listaDatos =
                    bbdd.BOLETA.Where(b => b.ID_MEDIO == idMedio).ToList<Datos.BOLETA>();

                List<Boleta> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Boleta>();
            }
        }

        //Mostrar Proveedor
        public void LeerNombreMedio()
        {
            Medio_Pago mp = new Medio_Pago() { ID_MEDIO = ID_MEDIO };

            if (mp.Read())
            {
                _descripcionMedio = mp.NOMBRE_MEDIO;
            }
            else
            {
                _descripcionMedio = String.Empty;
            }
        }
    }
}
