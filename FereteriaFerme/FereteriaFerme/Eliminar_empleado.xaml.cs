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
    /// Lógica de interacción para Eliminar_empleado.xaml
    /// </summary>
    public partial class Eliminar_empleado : Window
    {
        public Eliminar_empleado()
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

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado fila = (Empleado)dtg_empleados.SelectedItem;
            string rut = fila.RUT_EMPLEADO.Trim();
            short id = fila.ID_USUARIO;

            Empleado emp = new Empleado()
            {
                RUT_EMPLEADO = rut
            };

            Usuario usu = new Usuario()
            {
                ID_USUARIO = id
            };

            MessageBoxResult eliminar = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (eliminar == MessageBoxResult.Yes)
            {
                if (emp.Delete())
                {
                    if (usu.Delete())
                    {
                        MostrarEmpleado();
                        MessageBoxResult exito = MessageBox.Show("Empleado y usuario eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_empleado ae = new Administrador_empleado();
            ae.Show();
            this.Hide();
        }
    }
}
