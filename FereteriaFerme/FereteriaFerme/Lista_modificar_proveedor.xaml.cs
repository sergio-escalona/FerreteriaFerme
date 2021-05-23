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
    /// Lógica de interacción para Lista_modificar_proveedor.xaml
    /// </summary>
    public partial class Lista_modificar_proveedor : Window
    {
        public Lista_modificar_proveedor()
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

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Proveedor fila = (Proveedor)dtg_proveedor.SelectedItem;
            short id = fila.ID_PROVEEDOR;
            Modificar_proveedor mp = new Modificar_proveedor(id);
            mp.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_proveedor ap = new Administrador_proveedor();
            ap.Show();
            this.Hide();
        }
    }
}
