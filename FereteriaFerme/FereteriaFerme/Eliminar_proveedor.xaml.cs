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
    /// Lógica de interacción para Eliminar_proveedor.xaml
    /// </summary>
    public partial class Eliminar_proveedor : Window
    {
        public Eliminar_proveedor()
        {
            InitializeComponent();
            MostrarProveedor();
        }

        private void MostrarProveedor()
        {
            Proveedor pro = new Proveedor();
            dtg_proveedor.ItemsSource = pro.ReadAll();
            dtg_proveedor.Items.Refresh();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Proveedor fila = (Proveedor)dtg_proveedor.SelectedItem;
            short id = fila.ID_PROVEEDOR;

            Proveedor pro = new Proveedor()
            {
                ID_PROVEEDOR = id
            };

            MessageBoxResult eliminar = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (eliminar == MessageBoxResult.Yes)
            {
                if (pro.Delete())
                {
                    MostrarProveedor();
                    MessageBoxResult exito = MessageBox.Show("Proveedor eliminado", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_proveedor ap = new Administrador_proveedor();
            ap.Show();
            this.Hide();
        }
    }
}
