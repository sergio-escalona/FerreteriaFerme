using FerreteriaFerme.Negocio;
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
    /// Lógica de interacción para Lista_producto_proveedor.xaml
    /// </summary>
    public partial class Lista_producto_proveedor : Window
    {
        public Lista_producto_proveedor(int id)
        {
            InitializeComponent();
            this.id = id;
            MostrarProducto();
        }

        int id;

        private void MostrarProducto()
        {
            Producto_Proveedor prp = new Producto_Proveedor();
            dtg_producto.ItemsSource = prp.ReadCompra(id);
            dtg_producto.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_orden_proveedor lop = new Lista_orden_proveedor();
            lop.Show();
            this.Hide();
        }
    }
}
