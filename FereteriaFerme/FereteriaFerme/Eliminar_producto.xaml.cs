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
    /// Lógica de interacción para Eliminar_producto.xaml
    /// </summary>
    public partial class Eliminar_producto : Window
    {
        public Eliminar_producto()
        {
            InitializeComponent();
            MostrarProducto();
        }

        private void MostrarProducto()
        {
            Producto pro = new Producto();
            dtg_productos.ItemsSource = pro.ReadAll();
            dtg_productos.Items.Refresh();
        }


        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto fila = (Producto)dtg_productos.SelectedItem;
            long id = fila.ID_PRODUCTO;

            Producto pro = new Producto()
            {
                ID_PRODUCTO = id
            };

            MessageBoxResult eliminar = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (eliminar == MessageBoxResult.Yes)
            {
                if (pro.Delete())
                {
                    MostrarProducto();
                    MessageBoxResult exito = MessageBox.Show("Producto eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_producto bp = new Bodeguero_producto();
            bp.Show();
            this.Hide();
        }
    }
}
