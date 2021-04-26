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
    /// Lógica de interacción para Lista_detalle_orden.xaml
    /// </summary>
    public partial class Lista_detalle_orden : Window
    {
        public Lista_detalle_orden(decimal id)
        {
            InitializeComponent();
            this.id = id;
            MostrarDetalle();
        }

        decimal id;

        private void MostrarDetalle()
        {
            Detalle_Orden deo = new Detalle_Orden();
            dtg_detalle.ItemsSource = deo.ReadId(id);
            dtg_detalle.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_orden_compra loc = new Lista_orden_compra();
            loc.Show();
            this.Hide();
        }
    }
}
