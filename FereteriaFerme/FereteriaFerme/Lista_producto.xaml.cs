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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FerreteriaFerme;
using FerreteriaFerme.Negocio;

namespace FereteriaFerme
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int origen)
        {
            InitializeComponent();
            MostrarProducto();
            if (origen == 1)
            {
                Stock_Critico();
            }            
            this.origen = origen;
        }

        int origen;

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
                    MessageBoxResult exito = MessageBox.Show("Producto eliminado", "Exito",MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_producto bp = new Bodeguero_producto();
            bp.Show();
            this.Hide();
        }

        private void Stock_Critico()
        {
            Producto pro = new Producto();
            int contar_criticos = pro.Stock().Count;
            if (contar_criticos > 0)
            {
                MessageBoxResult critico = MessageBox.Show("Hay " + contar_criticos.ToString() + " productos con stock crítico", "¿Desea ver productos con stock crítico?", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (critico == MessageBoxResult.Yes)
                {
                    Lista_stock_critico lsc = new Lista_stock_critico();
                    lsc.ShowDialog();
                    this.Hide();
                }

                else
                {
                    Producto_Vencido();
                }
            }

            else
            {
                Producto_Vencido();
            }
        }

        private void Producto_Vencido()
        {
            Producto pro = new Producto();
            int contar_vencidos = pro.Vencimiento().Count;
            if (contar_vencidos > 0)
            {
                MessageBoxResult critico = MessageBox.Show("Hay " + contar_vencidos.ToString() + " productos vencidos", "¿Desea ver productos vencidos?", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (critico == MessageBoxResult.Yes)
                {
                    Lista_vencidos lv = new Lista_vencidos();
                    lv.ShowDialog();
                    this.Hide();
                }
            }
        }
    }
}
