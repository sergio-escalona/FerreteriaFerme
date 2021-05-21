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
    /// Lógica de interacción para Lista_orden_proveedor.xaml
    /// </summary>
    public partial class Lista_orden_proveedor : Window
    {
        public Lista_orden_proveedor()
        {
            InitializeComponent();
            MostrarOrden();
        }

        private void MostrarOrden()
        {
            Compra_Proveedor cp = new Compra_Proveedor();
            dtg_orden.ItemsSource = cp.ReadAll();
            dtg_orden.Items.Refresh();
        }

        private void Btn_productos_Click(object sender, RoutedEventArgs e)
        {
            Compra_Proveedor fila = (Compra_Proveedor)dtg_orden.SelectedItem;
            int id = fila.ID_COMPRA;
            Lista_producto_proveedor lpp = new Lista_producto_proveedor(id);
            lpp.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_pedido bp = new Bodeguero_pedido();
            bp.Show();
            this.Hide();
        }
    }
}
