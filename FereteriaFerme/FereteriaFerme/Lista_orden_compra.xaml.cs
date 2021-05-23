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
    /// Lógica de interacción para Lista_orden_compra.xaml
    /// </summary>
    public partial class Lista_orden_compra : Window
    {
        public Lista_orden_compra()
        {
            InitializeComponent();
            MostrarOrden();
        }

        private void MostrarOrden()
        {
            Orden_Compra orc = new Orden_Compra();
            dtg_orden.ItemsSource = orc.ReadAll();
            dtg_orden.Items.Refresh();
        }

        private void Btn_detalles_Click(object sender, RoutedEventArgs e)
        {
            Orden_Compra fila = (Orden_Compra)dtg_orden.SelectedItem;
            decimal id = fila.ID_COMPRA;
            Lista_detalle_orden ldo = new Lista_detalle_orden(id);
            ldo.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_auditoria aa = new Administrador_auditoria();
            aa.Show();
            this.Hide();
        }
    }
}
