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
    /// Lógica de interacción para Lista_direccion.xaml
    /// </summary>
    public partial class Lista_direccion : Window
    {
        public Lista_direccion(string rut)
        {
            InitializeComponent();
            this.rut = rut;
            MostrarDireccion();
        }

        string rut;

        private void MostrarDireccion()
        {
            Direccion dir = new Direccion();
            dtg_direccion.ItemsSource = dir.ReadRut(rut);
            dtg_direccion.Items.Refresh();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Direccion fila = (Direccion)dtg_direccion.SelectedItem;
            int id = fila.ID_DIRECCION;
            Modificar_direccion md = new Modificar_direccion(id);
            md.Show();
            this.Hide();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Direccion fila = (Direccion)dtg_direccion.SelectedItem;
            int id = fila.ID_DIRECCION;

            Direccion dir = new Direccion()
            {
                ID_DIRECCION = id
            };

            MessageBoxResult eliminar = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (eliminar == MessageBoxResult.Yes)
            {
                if (dir.Delete())
                {
                    MostrarDireccion();
                    MessageBoxResult exito = MessageBox.Show("Dirección eliminada", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            Agregar_direccion ad = new Agregar_direccion(rut);
            ad.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_cliente lc = new Lista_cliente();
            lc.Show();
            this.Hide();
        }
    }
}
