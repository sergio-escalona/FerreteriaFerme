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
    /// Lógica de interacción para Agregar_proveedor.xaml
    /// </summary>
    public partial class Agregar_proveedor : Window
    {
        public Agregar_proveedor()
        {
            InitializeComponent();
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Proveedor pro = new Proveedor()
            {
                ID_PROVEEDOR = 0,
                NOMBRE_PROVEEDOR = txt_nombre.Text,
                RUT_PROVEEDOR = txt_rut.Text,
                CELULAR = long.Parse(txt_celular.Text),
                CORREO = txt_correo.Text
            };

            if (pro.Create())
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
            Ventana_principal vp = new Ventana_principal();
            vp.Show();
            this.Hide();
        }
    }
}
