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
    /// Lógica de interacción para Agregar_producto_proveedor.xaml
    /// </summary>
    public partial class Agregar_producto_proveedor : Window
    {
        public Agregar_producto_proveedor(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        int id;

        private void MostrarProducto()
        {
            Producto_Proveedor prp = new Producto_Proveedor();
            dtg_producto.ItemsSource = prp.ReadCompra(id);
            dtg_producto.Items.Refresh();
        }

        private void LimpiarDatos()
        {
            txt_producto.Text = String.Empty;
            txt_cantidad.Text = String.Empty;
            txt_precio.Text = String.Empty;
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Producto_Proveedor prp = new Producto_Proveedor()
            {
                ID_PRODUCTO = 0,
                NOMBRE_PRODUCTO = txt_producto.Text,
                CANTIDAD = short.Parse(txt_cantidad.Text),
                PRECIO_UNITARIO = int.Parse(txt_precio.Text),
                ID_COMPRA = id
            };

            if (prp.Create())
            {
                MostrarProducto();
                LimpiarDatos();
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("No se guardo", "mala",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto_Proveedor fila = (Producto_Proveedor)dtg_producto.SelectedItem;
            int id = fila.ID_PRODUCTO;

            Producto_Proveedor prp = new Producto_Proveedor()
            {
                ID_PRODUCTO = id
            };

            MessageBoxResult eliminar = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (eliminar == MessageBoxResult.Yes)
            {
                if (prp.Delete())
                {
                    MostrarProducto();
                    MessageBoxResult exito = MessageBox.Show("Producto eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Agregar_orden_proveedor aop = new Agregar_orden_proveedor();
            aop.Show();
            this.Hide();
        }
    }
}
