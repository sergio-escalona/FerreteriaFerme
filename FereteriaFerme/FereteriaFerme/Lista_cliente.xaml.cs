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
    }
}
