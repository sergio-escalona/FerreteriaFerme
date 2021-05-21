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
    /// Lógica de interacción para Lista_modificar_producto.xaml
    /// </summary>
    public partial class Lista_modificar_producto : Window
    {
        public Lista_modificar_producto()
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

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Producto fila = (Producto)dtg_productos.SelectedItem;
            long id = fila.ID_PRODUCTO;
            Modificar_producto mp = new Modificar_producto(id);
            mp.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_producto bp = new Bodeguero_producto();
            bp.Show();
            this.Hide();
        }
    }
}
