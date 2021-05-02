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
    /// Lógica de interacción para Lista_Recepcion.xaml
    /// </summary>
    public partial class Lista_Recepcion : Window
    {
        public Lista_Recepcion()
        {
            InitializeComponent();
            MostrarRecepcion();
        }

        private void MostrarRecepcion()
        {
            Recepcion_Producto rep = new Recepcion_Producto();
            dtg_recepcion.ItemsSource = rep.ReadAll();
            dtg_recepcion.Items.Refresh();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Recepcion_Producto fila = (Recepcion_Producto)dtg_recepcion.SelectedItem;
            int id = fila.ID_RECEPCION;
            Modificar_recepcion mor = new Modificar_recepcion(id);
            mor.Show();
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
