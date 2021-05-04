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
    /// Lógica de interacción para Lista_despacho.xaml
    /// </summary>
    public partial class Lista_despacho : Window
    {
        public Lista_despacho()
        {
            InitializeComponent();
            MostrarDespacho();
        }

        private void MostrarDespacho()
        {
            Despacho des = new Despacho();
            dtg_despacho.ItemsSource = des.ReadAll();
            dtg_despacho.Items.Refresh();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Despacho fila = (Despacho)dtg_despacho.SelectedItem;
            int id = fila.ID_DESPACHO;
            Modificar_despacho md = new Modificar_despacho(id);
            md.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Ventana_principal vp = new Ventana_principal();
            vp.Show();
            this.Hide();
        }
    }
}
