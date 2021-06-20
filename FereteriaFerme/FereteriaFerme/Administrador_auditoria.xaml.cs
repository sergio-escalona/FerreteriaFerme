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
    /// Lógica de interacción para Administrador_auditoria.xaml
    /// </summary>
    public partial class Administrador_auditoria : Window
    {
        public Administrador_auditoria()
        {
            InitializeComponent();
        }

        private void Btn_carro_Click(object sender, RoutedEventArgs e)
        {
            Lista_orden_compra loc = new Lista_orden_compra();
            loc.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Inicio_administrador ia = new Inicio_administrador();
            ia.Show();
            this.Hide();
        }

        private void Btn_resumen_Click(object sender, RoutedEventArgs e)
        {
            Lista_resumen lr = new Lista_resumen();
            lr.Show();
            this.Hide();
        }
    }
}
