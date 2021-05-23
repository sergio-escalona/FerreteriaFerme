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
    /// Lógica de interacción para Lista_modificar_empleado.xaml
    /// </summary>
    public partial class Lista_modificar_empleado : Window
    {
        public Lista_modificar_empleado()
        {
            InitializeComponent();
            MostrarEmpleado();
        }

        private void MostrarEmpleado()
        {
            Empleado emp = new Empleado();
            dtg_empleados.ItemsSource = emp.ReadAll();
            dtg_empleados.Items.Refresh();
        }

        private void Btn_modificar_empleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado fila = (Empleado)dtg_empleados.SelectedItem;
            string rut = fila.RUT_EMPLEADO.Trim();
            Modificar_empleado me = new Modificar_empleado(rut);
            me.Show();
            this.Hide();
        }

        private void Btn_modificar_usuario_Click(object sender, RoutedEventArgs e)
        {
            Empleado fila = (Empleado)dtg_empleados.SelectedItem;
            short id = fila.ID_USUARIO;
            Modificar_usuario mu = new Modificar_usuario(id);
            mu.Show();
            this.Hide();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_empleado ae = new Administrador_empleado();
            ae.Show();
            this.Hide();
        }
    }
}
