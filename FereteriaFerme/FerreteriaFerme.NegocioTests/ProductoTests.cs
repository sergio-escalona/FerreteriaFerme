using Microsoft.VisualStudio.TestTools.UnitTesting;
using FerreteriaFerme.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaFerme.Negocio.Tests
{
    [TestClass()]
    public class ProductoTests
    {
        [TestMethod()]
        public void InsertarProveedorTest()
        {
            Proveedor pro = new Proveedor()
            {
                ID_PROVEEDOR = 0,
                NOMBRE_PROVEEDOR = "Lime",
                RUT_PROVEEDOR = "14500885-6",
                CELULAR = 56977202211,
                CORREO = "Lime@lime.cl"
            };

            bool res = pro.Create();
            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void ProveedorTelefonoMaloTest()
        {
            Proveedor pro = new Proveedor()
            {
                ID_PROVEEDOR = 0,
                NOMBRE_PROVEEDOR = "Keep",
                RUT_PROVEEDOR = "12500785-3",
                CELULAR = 86543002978263,
                CORREO = "Keep@keeping.com"
            };

            bool res = pro.Create();
            Assert.AreEqual(false, res);
        }

        [TestMethod()]
        public void EliminarProveedorInexistenteTest()
        {
            Proveedor pro = new Proveedor()
            {
                ID_PROVEEDOR = 856
            };

            bool res = pro.Delete();
            Assert.AreEqual(false, res);
        }

        [TestMethod()]
        public void InsertarProductoTest()
        {
            Producto pro = new Producto()
            {
                ID_PRODUCTO = 0,
                NOMBRE_PRODUCTO = "Cemento",
                ID_PROVEEDOR = 101,
                ID_FAMILIA = 102,
                FECHA_VENCIMIENTO = DateTime.Parse("12/06/2021"),
                ID_TIPO = 103,
                DESCRIPCION = "25Kg",
                PRECIO_CLP = 3890,
                PRECIO_USD = 4,
                STOCK = 100,
                FOTO = new byte[0]
            };

            bool res = pro.Create();
            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void EliminarProductoTest()
        {
            Producto pro = new Producto()
            {
                ID_PRODUCTO = 10110212062021103
            };

            bool res = pro.Delete();
            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void CrearPedidoProveedorTest()
        {
            Compra_Proveedor cop = new Compra_Proveedor()
            {
                ID_COMPRA = 0,
                ID_PROVEEDOR = 104,
                ID_ESTADO = 1
            };

            bool res = cop.Create();
            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void AgregarProductoPedidoTest()
        {
            Producto_Proveedor prp = new Producto_Proveedor()
            {
                ID_PRODUCTO = 0,
                NOMBRE_PRODUCTO = "Martillo largo",
                CANTIDAD = 700,
                PRECIO_UNITARIO = 5500,
                ID_COMPRA = 6
            };

            bool res = prp.Create();
            Assert.AreEqual(true, res);
        }

        public void ContarBoletasTest()
        {
            Boleta bol = new Boleta();

            int res = bol.ReadAll().Count();
            Assert.AreEqual(2, res);
        }

        public void ContarFacturasTest()
        {
            Factura fac = new Factura();

            int res = fac.ReadAll().Count();
            Assert.AreEqual(1, res);
        }

        public void ContarEnviosPendientesEmpleadoTest()
        {
            Despacho des = new Despacho();

            int res = des.ReadRutPendientes("15969833-4").Count();
            Assert.AreEqual(3, res);
        }

        public void ContarProductosTest()
        {
            Producto pro = new Producto();

            int res = pro.ReadAll().Count();
            Assert.AreEqual(5, res);
        }


    }
}