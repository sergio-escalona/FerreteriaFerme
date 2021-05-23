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
    /// Lógica de interacción para Administrador_comprobante.xaml
    /// </summary>
    public partial class Administrador_comprobante : Window
    {
        public Administrador_comprobante()
        {
            InitializeComponent();
        }

        private void Btn_boleta_Click(object sender, RoutedEventArgs e)
        {
            Lista_boleta lb = new Lista_boleta();
            lb.Show();
            this.Hide();
        }

        private void Btn_factura_Click(object sender, RoutedEventArgs e)
        {
            Lista_factura lf = new Lista_factura();
            lf.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Inicio_administrador ia = new Inicio_administrador();
            ia.Show();
            this.Hide();
        }
    }
}
