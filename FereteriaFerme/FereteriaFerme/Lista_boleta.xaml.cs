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
    /// Lógica de interacción para Lista_boleta.xaml
    /// </summary>
    public partial class Lista_boleta : Window
    {
        public Lista_boleta()
        {
            InitializeComponent();
            MostrarBoleta();
        }

        private void MostrarBoleta()
        {
            Boleta bol = new Boleta();
            dtg_boleta.ItemsSource = bol.ReadAll();
            dtg_boleta.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_comprobante ac = new Administrador_comprobante();
            ac.Show();
            this.Hide();
        }
    }
}
