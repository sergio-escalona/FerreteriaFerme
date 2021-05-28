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
    /// Lógica de interacción para Bodeguero_pedido.xaml
    /// </summary>
    public partial class Bodeguero_pedido : Window
    {
        public Bodeguero_pedido()
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
            Agregar_orden_proveedor aop = new Agregar_orden_proveedor();
            aop.Show();
            this.Hide();
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Lista_orden_proveedor lop = new Lista_orden_proveedor();
            lop.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Lista_pedido_pendiente lpp = new Lista_pedido_pendiente();
            lpp.Show();
            this.Hide();
        }
    }
}
