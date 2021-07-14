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
    /// Lógica de interacción para Inicio_despachador.xaml
    /// </summary>
    public partial class Inicio_despachador : Window
    {
        public Inicio_despachador()
        {
            InitializeComponent();
            tb_nombre.Text = Login.nombre;
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Lista_despacho ld = new Lista_despacho();
            ld.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
