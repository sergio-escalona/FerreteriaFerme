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
    /// Lógica de interacción para Inicio_bodeguero.xaml
    /// </summary>
    public partial class Inicio_bodeguero : Window
    {
        public Inicio_bodeguero()
        {
            InitializeComponent();
            tb_nombre.Text = Login.nombre;
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Btn_producto_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_producto bp = new Bodeguero_producto();
            bp.Show();
            this.Hide();
        }

        private void Btn_pedido_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_pedido bp = new Bodeguero_pedido();
            bp.Show();
            this.Hide();
        }

        private void Btn_recepción_Click(object sender, RoutedEventArgs e)
        {
            Lista_Recepcion lr = new Lista_Recepcion();
            lr.Show();
            this.Hide();
        }
    }
}
