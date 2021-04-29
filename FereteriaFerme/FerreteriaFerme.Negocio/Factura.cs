using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio
{
    public class Factura
    {
        //Campos
        private int _ID_FACTURA;
        private System.DateTime _FECHA_FACTURA;
        private int _NETO_FACTURA;
        private int _IVA_FACTURA;
        private int _TOTAL_FACTURA;
        private decimal _ID_COMPRA;
        private short _ID_EMPRESA;
        private string _nombreEmpresa;
        private short _ID_MEDIO;
        private string _descripcionMedio;

        //Propiedades
        public int ID_FACTURA { get; set; }
        public System.DateTime FECHA_FACTURA { get; set; }
        public int NETO_FACTURA { get; set; }
        public int IVA_FACTURA { get; set; }
        public int TOTAL_FACTURA { get; set; }
        public decimal ID_COMPRA { get; set; }
        public short ID_EMPRESA { get; set; }
        public string NombreEmpresa { get { return _nombreEmpresa; } }
        public short ID_MEDIO { get; set; }
        public string DescripcionMedio { get { return _descripcionMedio; } }

        public Factura()
        {
            this.init();
        }
        
        //Constructor
        private void init()
        {
            ID_FACTURA = 0;
            FECHA_FACTURA = DateTime.MinValue;
            NETO_FACTURA = 0;
            IVA_FACTURA = 0;
            TOTAL_FACTURA = 0;
            ID_COMPRA = 0;
            ID_EMPRESA = 0;
            ID_MEDIO = 0;
        }

        //Agregar
        public bool Create()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            Datos.FACTURA fac = new Datos.FACTURA();

            try
            {
                CommonBC.Syncronize(this, fac);

                bbdd.FACTURA.Add(fac);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.FACTURA.Remove(fac);
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
                Datos.FACTURA fac = bbdd.FACTURA.First(e => e.ID_FACTURA == ID_FACTURA);

                /* Se copian las propiedades de datos al negocio */
                CommonBC.Syncronize(fac, this);

                /* Carga descripción de los Tipos */
                LeerNombreEmpresa();
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
                Datos.FACTURA fac = bbdd.FACTURA.First(e => e.ID_FACTURA == ID_FACTURA);

                /* Se copian las propiedades del negocio a los datos */
                CommonBC.Syncronize(this, fac);

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
                Datos.FACTURA fac = bbdd.FACTURA.First(e => e.ID_FACTURA == ID_FACTURA);

                /* Se elimina el registro del EDM */
                bbdd.FACTURA.Remove(fac);

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
        public List<Factura> ReadAll()
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                /* Se obtiene todos los registro desde la tabla */
                List<Datos.FACTURA> listadoDatos = bbdd.FACTURA.ToList<Datos.FACTURA>();

                /* Se convierte el listado de datos en un listado de negocio */
                List<Factura> listadoNegocio = GenerarListado(listadoDatos);

                /* Se retorna la lista */
                return listadoNegocio;
            }
            catch (Exception ex)
            {
                return new List<Factura>();
            }
        }

        /// <summary>
        /// Convierte un listado de objetos de datos en un listado de objetos de negocio
        /// </summary>
        /// <param name="listadoDatos"></param>
        /// <returns></returns>
        private List<Factura> GenerarListado(List<Datos.FACTURA> listadoDatos)
        {
            List<Factura> listadoEmpresa = new List<Factura>();

            foreach (Datos.FACTURA dato in listadoDatos)
            {

                Factura negocio = new Factura();
                CommonBC.Syncronize(dato, negocio);
                negocio.LeerNombreMedio();
                negocio.LeerNombreEmpresa();

                listadoEmpresa.Add(negocio);
            }

            return listadoEmpresa;
        }

        //Buscar factura
        public List<Factura> ReadEmpresA(short idEmpresa)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.FACTURA> listaDatos =
                    bbdd.FACTURA.Where(b => b.ID_EMPRESA == idEmpresa).ToList<Datos.FACTURA>();

                List<Factura> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Factura>();
            }
        }

        //Mostrar Proveedor
        public void LeerNombreEmpresa()
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

        //Buscar proveedor
        public List<Factura> ReadMedio(short idMedio)
        {
            Datos.FerreteriaFermeEntities bbdd = new Datos.FerreteriaFermeEntities();

            try
            {
                List<Datos.FACTURA> listaDatos =
                    bbdd.FACTURA.Where(b => b.ID_MEDIO == idMedio).ToList<Datos.FACTURA>();

                List<Factura> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Factura>();
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
