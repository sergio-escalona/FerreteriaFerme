using FereteriaFerme;
using FerreteriaFerme.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para Modificar_proveedor.xaml
    /// </summary>
    public partial class Modificar_proveedor : Window
    {
        public Modificar_proveedor(short id)
        {
            InitializeComponent();
            this.id = id;
            CargarDatos();
        }

        short id;

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nombre.Text != String.Empty && txt_rut.Text != String.Empty && txt_celular.Text != String.Empty &&
                txt_correo.Text != String.Empty)
            {
                Proveedor pro = new Proveedor()
                {
                    ID_PROVEEDOR = id,
                    NOMBRE_PROVEEDOR = txt_nombre.Text,
                    RUT_PROVEEDOR = txt_rut.Text,
                    CELULAR = long.Parse(txt_celular.Text),
                    CORREO = txt_correo.Text
                };

                if (pro.Update())
                {
                    MessageBoxResult exito = MessageBox.Show("Se modificó proveedor", "Éxito",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se guardo proveedor", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Debe llenar todos los campos", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CargarDatos()
        {
            Proveedor pro = new Proveedor()
            {
                ID_PROVEEDOR = id
            };

            if (pro.Read())
            {
                txt_nombre.Text = pro.NOMBRE_PROVEEDOR;
                txt_rut.Text = pro.RUT_PROVEEDOR;
                txt_celular.Text = pro.CELULAR.ToString();
                txt_correo.Text = pro.CORREO;
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_Proveedor lp = new Lista_Proveedor();
            lp.Show();
            this.Hide();
        }

        private void Txt_celular_Validacion(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}
