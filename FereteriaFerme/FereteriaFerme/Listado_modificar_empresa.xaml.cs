using FerreteriaFerme.Negocio;
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
    /// Lógica de interacción para Listado_modificar_empresa.xaml
    /// </summary>
    public partial class Listado_modificar_empresa : Window
    {
        public Listado_modificar_empresa()
        {
            InitializeComponent();
            MostrarEmpresa();
        }

        private void MostrarEmpresa()
        {
            Empresa emp = new Empresa();
            dtg_empresas.ItemsSource = emp.ReadAll();
            dtg_empresas.Items.Refresh();
        }

        private void Btn_direccion_Click(object sender, RoutedEventArgs e)
        {
            Empresa fila = (Empresa)dtg_empresas.SelectedItem;
            short? id = fila.ID_EMPRESA;
            Lista_direccion_empresa ld = new Lista_direccion_empresa(id);
            ld.Show();
            this.Hide();
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            Empresa fila = (Empresa)dtg_empresas.SelectedItem;
            short? id = fila.ID_EMPRESA;
            Modificar_empresa me = new Modificar_empresa(id);
            me.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_cli_emp ace = new Administrador_cli_emp();
            ace.Show();
            this.Hide();
        }
    }
}
