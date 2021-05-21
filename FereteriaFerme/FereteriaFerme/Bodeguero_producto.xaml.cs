using FereteriaFerme;
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
    /// Lógica de interacción para Bodeguero_producto.xaml
    /// </summary>
    public partial class Bodeguero_producto : Window
    {
        public Bodeguero_producto()
        {
            InitializeComponent();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Inicio_bodeguero ib = new Inicio_bodeguero();
            ib.Show();
            this.Hide();
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Agregar_producto ap = new Agregar_producto();
            ap.Show();
            this.Hide();
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Lista_modificar_producto lmp = new Lista_modificar_producto();
            lmp.Show();
            this.Hide();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar_producto ep = new Eliminar_producto();
            ep.Show();
            this.Hide();
        }
    }
}
