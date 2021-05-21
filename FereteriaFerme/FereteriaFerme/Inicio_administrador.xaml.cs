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

        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
