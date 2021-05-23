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
    /// Lógica de interacción para Administrador_empleado.xaml
    /// </summary>
    public partial class Administrador_empleado : Window
    {
        public Administrador_empleado()
        {
            InitializeComponent();
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Agregar_empleado ae = new Agregar_empleado();
            ae.Show();
            this.Hide();
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Lista_empleado le = new Lista_empleado();
            le.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Lista_modificar_empleado lme = new Lista_modificar_empleado();
            lme.Show();
            this.Hide();
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar_empleado ee = new Eliminar_empleado();
            ee.Show();
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
