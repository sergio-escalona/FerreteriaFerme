using FereteriaFerme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FerreteriaFerme
{
    /// <summary>
    /// Lógica de interacción para Ventana_principal.xaml
    /// </summary>
    public partial class Ventana_principal : Window
    {
        public Ventana_principal()
        {
            InitializeComponent();
        }

        private void Btn_agregarProducto_Click(object sender, RoutedEventArgs e)
        {
            Agregar_producto agrpro = new Agregar_producto();
            agrpro.Show();
            this.Hide();
        }

        private void Btn_listarProducto_Click(object sender, RoutedEventArgs e)
        {
            MainWindow lispro = new MainWindow();
            lispro.Show();
            this.Hide();
        }

        private void Btn_agregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            Agregar_proveedor ap = new Agregar_proveedor();
            ap.Show();
            this.Hide();
        }

        private void Btn_listarProveedor_Click(object sender, RoutedEventArgs e)
        {
            Lista_Proveedor lp = new Lista_Proveedor();
            lp.Show();
            this.Hide();
        }

        private void Btn_listar_orden_Click(object sender, RoutedEventArgs e)
        {
            Lista_orden_compra loc = new Lista_orden_compra();
            loc.Show();
            this.Hide();
        }

        private void Btn_agregar_empleado_Click(object sender, RoutedEventArgs e)
        {
            Agregar_empleado age = new Agregar_empleado();
            age.Show();
            this.Hide();
        }

        private void Btn_lista_empleado_Click(object sender, RoutedEventArgs e)
        {
            Lista_empleado lim = new Lista_empleado();
            lim.Show();
            this.Hide();
        }

        private void Btn_lista_cliente_Click(object sender, RoutedEventArgs e)
        {
            Lista_cliente lic = new Lista_cliente();
            lic.Show();
            this.Hide();
        }

        private void Btn_lista_empresa_Click(object sender, RoutedEventArgs e)
        {
            Lista_empresa lie = new Lista_empresa();
            lie.Show();
            this.Hide();
        }

        private void Btn_lista_boleta_Click(object sender, RoutedEventArgs e)
        {
            Lista_boleta lib = new Lista_boleta();
            lib.Show();
            this.Hide();
        }

        private void Btn_lista_factura_Click(object sender, RoutedEventArgs e)
        {
            Lista_factura lif = new Lista_factura();
            lif.Show();
            this.Hide();
        }

        private void Btn_pedido_Click(object sender, RoutedEventArgs e)
        {
            Agregar_orden_proveedor aop = new Agregar_orden_proveedor();
            aop.Show();
            this.Hide();
        }

        private void Btn_lista_pedido_Click(object sender, RoutedEventArgs e)
        {
            Lista_orden_proveedor lop = new Lista_orden_proveedor();
            lop.Show();
            this.Hide();
        }

        private void Btn_agregar_recepcion_Click(object sender, RoutedEventArgs e)
        {
            Agregar_recepcion agr = new Agregar_recepcion();
            agr.Show();
            this.Hide();
        }

        private void Btn_lista_recepcion_Click(object sender, RoutedEventArgs e)
        {
            Lista_Recepcion lir = new Lista_Recepcion();
            lir.Show();
            this.Hide();
        }

        private void Btn_agregar_despacho_Click(object sender, RoutedEventArgs e)
        {
            Agregar_despacho ad = new Agregar_despacho();
            ad.Show();
            this.Hide();
        }

        private void Btn_listar_despacho_Click(object sender, RoutedEventArgs e)
        {
            Lista_despacho ld = new Lista_despacho();
            ld.Show();
            this.Hide();
        }
    }
}
