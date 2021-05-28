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
    /// Lógica de interacción para Modificar_orden_proveedor.xaml
    /// </summary>
    public partial class Modificar_orden_proveedor : Window
    {
        public Modificar_orden_proveedor(int id)
        {
            InitializeComponent();
            this.id = id;
            MostrarProducto();
            Llenarestado();
            Cargar_cb();
        }

        int id;

        private void MostrarProducto()
        {
            Producto_Proveedor prp = new Producto_Proveedor();
            dtg_producto.ItemsSource = prp.ReadCompra(id);
            dtg_producto.Items.Refresh();
        }

        private void Llenarestado()
        {
            Estado_Compra pro = new Estado_Compra();
            cb_estado.ItemsSource = pro.ReadAll();

            cb_estado.DisplayMemberPath = "ESTADO";
            cb_estado.SelectedValuePath = "ID_ESTADO";

            cb_estado.SelectedIndex = -1;
        }

        private void Cargar_cb()
        {
            Compra_Proveedor cp = new Compra_Proveedor()
            {
                ID_COMPRA = id
            };

            if (cp.Read())
            {
                cb_estado.SelectedValue = cp.ID_ESTADO;
            }
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Compra_Proveedor cp = new Compra_Proveedor()
            {
                ID_COMPRA = id
            };

            if (cp.Read())
            {
                Compra_Proveedor cop = new Compra_Proveedor()
                {
                    ID_COMPRA = id,
                    FECHA_COMPRA = cp.FECHA_COMPRA,
                    ID_PROVEEDOR = cp.ID_PROVEEDOR,
                    ID_ESTADO = (int)cb_estado.SelectedValue
                };

                if (cop.Update())
                {
                    MessageBoxResult exito = MessageBox.Show("Se modificó orden", "Éxito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se pudo modificar orden", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_pedido_pendiente lpp = new Lista_pedido_pendiente();
            lpp.Show();
            this.Hide();
        }
    }
}
