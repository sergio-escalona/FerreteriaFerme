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
    /// Lógica de interacción para Agregar_direccion_empresa.xaml
    /// </summary>
    public partial class Agregar_direccion_empresa : Window
    {
        public Agregar_direccion_empresa(short? id)
        {
            InitializeComponent();
            this.id = id;
            LlenarRegion();
            LlenarComuna();
        }

        short? id;

        private void LlenarRegion()
        {
            Region reg = new Region();
            cb_region.ItemsSource = reg.ReadAll();

            cb_region.DisplayMemberPath = "NOMBRE_REGION";
            cb_region.SelectedValuePath = "ID_REGION";

            cb_region.SelectedIndex = 4;
        }

        private void LlenarComuna()
        {
            try
            {
                Comuna com = new Comuna();
                cb_comuna.ItemsSource = com.ReadRegion((string)cb_region.SelectedValue);

                cb_comuna.DisplayMemberPath = "NOMBRE_COMUNA";
                cb_comuna.SelectedValuePath = "ID_COMUNA";

                cb_comuna.SelectedIndex = 0;
            }
            catch (Exception ex) { }
        }

        private void Cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarComuna();
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Direccion dir = new Direccion()
            {
                ID_DIRECCION = 0,
                DIRECCION1 = txt_direccion.Text,
                ID_COMUNA = (short)cb_comuna.SelectedValue,
                ID_EMPRESA = id
            };

            if (dir.Create())
            {
                MessageBoxResult exito = MessageBox.Show("Se guardo", "bkn",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("No se guardo", "mala",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_direccion_empresa lid = new Lista_direccion_empresa(id);
            lid.Show();
            this.Hide();
        }
    }
}
