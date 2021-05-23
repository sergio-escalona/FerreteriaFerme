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
    /// Lógica de interacción para Administrador_cli_emp.xaml
    /// </summary>
    public partial class Administrador_cli_emp : Window
    {
        public Administrador_cli_emp()
        {
            InitializeComponent();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Inicio_administrador ia = new Inicio_administrador();
            ia.Show();
            this.Hide();
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Lista_cliente lc = new Lista_cliente();
            lc.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Lista_modificar_cliente lmc = new Lista_modificar_cliente();
            lmc.Show();
            this.Hide();
        }

        private void Btn_listar_emp_Click(object sender, RoutedEventArgs e)
        {
            Lista_empresa le = new Lista_empresa();
            le.Show();
            this.Hide();
        }

        private void Btn_modificar_emp_Click(object sender, RoutedEventArgs e)
        {
            Listado_modificar_empresa lme = new Listado_modificar_empresa();
            lme.Show();
            this.Hide();
        }
    }
}
