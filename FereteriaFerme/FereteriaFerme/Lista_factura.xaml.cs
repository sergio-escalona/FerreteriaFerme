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
    /// Lógica de interacción para Lista_factura.xaml
    /// </summary>
    public partial class Lista_factura : Window
    {
        public Lista_factura()
        {
            InitializeComponent();
            MostrarFactura();
        }

        private void MostrarFactura()
        {
            Factura fac = new Factura();
            dtg_factura.ItemsSource = fac.ReadAll();
            dtg_factura.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Ventana_principal vp = new Ventana_principal();
            vp.Show();
            this.Hide();
        }
    }
}
