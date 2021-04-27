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
    /// Lógica de interacción para Lista_empleado.xaml
    /// </summary>
    public partial class Lista_empleado : Window
    {
        public Lista_empleado()
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
    }
}
