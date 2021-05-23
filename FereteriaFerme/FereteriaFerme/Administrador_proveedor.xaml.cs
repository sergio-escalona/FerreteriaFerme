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
    /// Lógica de interacción para Administrador_proveedor.xaml
    /// </summary>
    public partial class Administrador_proveedor : Window
    {
        public Administrador_proveedor()
        {
            InitializeComponent();
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Agregar_proveedor ap = new Agregar_proveedor();
            ap.Show();
            this.Hide();
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Lista_Proveedor lp = new Lista_Proveedor();
            lp.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Inicio_administrador ia = new Inicio_administrador();
            ia.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Lista_modificar_proveedor lmp = new Lista_modificar_proveedor();
            lmp.Show();
            this.Hide();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar_proveedor ep = new Eliminar_proveedor();
            ep.Show();
            this.Hide();
        }
    }
}
