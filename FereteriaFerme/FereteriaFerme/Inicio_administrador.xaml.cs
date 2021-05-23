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
    /// Lógica de interacción para Inicio_administrador.xaml
    /// </summary>
    public partial class Inicio_administrador : Window
    {
        public Inicio_administrador()
        {
            InitializeComponent();
            tb_nombre.Text = Login.rut;
        }

        private void Btn_cliente_Click(object sender, RoutedEventArgs e)
        {
            Administrador_cli_emp ace = new Administrador_cli_emp();
            ace.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Btn_proveedor_Click(object sender, RoutedEventArgs e)
        {
            Administrador_proveedor ap = new Administrador_proveedor();
            ap.Show();
            this.Hide();
        }

        private void Btn_empleado_Click(object sender, RoutedEventArgs e)
        {
            Administrador_empleado ae = new Administrador_empleado();
            ae.Show();
            this.Hide();
        }

        private void Btn_comprobante_Click(object sender, RoutedEventArgs e)
        {
            Administrador_comprobante ac = new Administrador_comprobante();
            ac.Show();
            this.Hide();
        }

        private void Btn_auditoria_Click(object sender, RoutedEventArgs e)
        {
            Administrador_auditoria aa = new Administrador_auditoria();
            aa.Show();
            this.Hide();
        }
    }
}
