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
    /// Lógica de interacción para Lista_direccion_empresa.xaml
    /// </summary>
    public partial class Lista_direccion_empresa : Window
    {
        public Lista_direccion_empresa(short? id)
        {
            InitializeComponent();
            this.id = id;
            MostrarDireccion();
        }

        short? id;

        private void MostrarDireccion()
        {
            Direccion dir = new Direccion();
            dtg_direccion.ItemsSource = dir.ReadId(id);
            dtg_direccion.Items.Refresh();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Direccion fila = (Direccion)dtg_direccion.SelectedItem;
            int id = fila.ID_DIRECCION;
            Modificar_direccion_empresa mde = new Modificar_direccion_empresa(id);
            mde.Show();
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
            Agregar_direccion_empresa ad = new Agregar_direccion_empresa(id);
            ad.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Listado_modificar_empresa lme = new Listado_modificar_empresa();
            lme.Show();
            this.Hide();
        }
    }
}
