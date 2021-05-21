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
    /// Lógica de interacción para Agregar_orden_proveedor.xaml
    /// </summary>
    public partial class Agregar_orden_proveedor : Window
    {
        public Agregar_orden_proveedor()
        {
            InitializeComponent();
            LlenarProveedor();
        }

        private void LlenarProveedor()
        {
            Proveedor pro = new Proveedor();
            cb_proveedor.ItemsSource = pro.ReadAll();

            cb_proveedor.DisplayMemberPath = "NOMBRE_PROVEEDOR";
            cb_proveedor.SelectedValuePath = "ID_PROVEEDOR";

            cb_proveedor.SelectedIndex = -1;
        }

        private void Btn_crear_Click(object sender, RoutedEventArgs e)
        {
            if (cb_proveedor.Text != String.Empty)
            {
                Compra_Proveedor cop = new Compra_Proveedor()
                {
                    ID_COMPRA = 0,
                    FECHA_COMPRA = DateTime.Now,
                    ID_PROVEEDOR = (short)cb_proveedor.SelectedValue
                };

                if (cop.Create())
                {
                    Compra_Proveedor cp = new Compra_Proveedor();
                    int id = cp.ReadAll().Max(x => x.ID_COMPRA);
                    Agregar_producto_proveedor app = new Agregar_producto_proveedor(id);
                    app.Show();
                    this.Hide();
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se crear pudo crear orden", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Debe seleccionar proveedor", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_pedido bp = new Bodeguero_pedido();
            bp.Show();
            this.Hide();
        }
    }
}
