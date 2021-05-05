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
    /// Lógica de interacción para Modificar_direccion.xaml
    /// </summary>
    public partial class Modificar_direccion : Window
    {
        public Modificar_direccion(int id)
        {
            InitializeComponent();
            this.id = id;
            LlenarRegion();
            Cargar_datos();
        }

        int id;
        string rut;

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

        private void Cargar_datos()
        {
            Direccion dir = new Direccion()
            {
                ID_DIRECCION = id
            };

            if (dir.Read())
            {
                txt_direccion.Text = dir.DIRECCION1;
                cb_region.SelectedValue = dir.IdRegion;
                LlenarComuna();
                cb_comuna.SelectedValue = dir.ID_COMUNA;
                rut = dir.RUT_CLIENTE;
            }
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_direccion.Text != String.Empty && cb_region.Text != String.Empty && cb_comuna.Text != String.Empty)
            {
                Direccion dir = new Direccion()
                {
                    ID_DIRECCION = id,
                    DIRECCION1 = txt_direccion.Text,
                    ID_COMUNA = (short)cb_comuna.SelectedValue,
                    RUT_CLIENTE = rut
                };

                if (dir.Update())
                {
                    MessageBoxResult exito = MessageBox.Show("Se modificó la dirección de cliente", "Éxito",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se pudo modificar la dirección", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Debe llenar todos los campos", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_direccion ld = new Lista_direccion(rut);
            ld.Show();
            this.Hide();
        }

        private void Cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarComuna();
        }
    }
}
