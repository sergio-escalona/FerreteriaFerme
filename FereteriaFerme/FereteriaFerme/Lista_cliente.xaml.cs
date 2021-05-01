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
    /// Lógica de interacción para Lista_cliente.xaml
    /// </summary>
    public partial class Lista_cliente : Window
    {
        public Lista_cliente()
        {
            InitializeComponent();
            MostrarCliente();
        }

        private void MostrarCliente()
        {
            Cliente cli = new Cliente();
            dtg_clientes.ItemsSource = cli.ReadAll();
            dtg_clientes.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Ventana_principal vp = new Ventana_principal();
            vp.Show();
            this.Hide();
        }

        private void Btn_direccion_Click(object sender, RoutedEventArgs e)
        {
            Cliente fila = (Cliente)dtg_clientes.SelectedItem;
            string rut = fila.RUT_CLIENTE.Trim();
            Lista_direccion ld = new Lista_direccion(rut);
            ld.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Cliente fila = (Cliente)dtg_clientes.SelectedItem;
            string rut = fila.RUT_CLIENTE.Trim();
            Modificar_cliente mc = new Modificar_cliente(rut);
            mc.Show();
            this.Hide();
        }

        private void Btn_usuario_Click(object sender, RoutedEventArgs e)
        {
            Cliente fila = (Cliente)dtg_clientes.SelectedItem;
            short id = fila.ID_USUARIO;
            Modificar_usuario_cliente muc = new Modificar_usuario_cliente(id);
            muc.Show();
            this.Hide();
        }
    }
}
