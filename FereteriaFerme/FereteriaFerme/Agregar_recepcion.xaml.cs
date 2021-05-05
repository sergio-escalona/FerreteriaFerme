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
    /// Lógica de interacción para Agregar_recepcion.xaml
    /// </summary>
    public partial class Agregar_recepcion : Window
    {
        public Agregar_recepcion()
        {
            InitializeComponent();
            LlenarEmpleado();
            LlenarOrden();
            LlenarEstado();
        }

        private void LlenarEmpleado()
        {
            Empleado emp = new Empleado();
            cb_empleado.ItemsSource = emp.ReadAll();

            cb_empleado.DisplayMemberPath = "NombreCompleto";
            cb_empleado.SelectedValuePath = "RUT_EMPLEADO";

            cb_empleado.SelectedIndex = -1;
        }

        private void LlenarOrden()
        {
            Orden_Compra orc = new Orden_Compra();
            cb_orden.ItemsSource = orc.ReadAll();

            cb_orden.DisplayMemberPath = "ID_COMPRA";
            cb_orden.SelectedValuePath = "ID_COMPRA";

            cb_orden.SelectedIndex = -1;
        }

        private void LlenarEstado()
        {
            Estado_Recepcion esr = new Estado_Recepcion();
            cb_estado.ItemsSource = esr.ReadAll();

            cb_estado.DisplayMemberPath = "ESTADO";
            cb_estado.SelectedValuePath = "ID_ESTADO";

            cb_estado.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (cb_empleado.Text != String.Empty && cb_orden.Text != String.Empty && cb_estado.Text != String.Empty)
            {
                Recepcion_Producto rpr = new Recepcion_Producto()
                {
                    ID_RECEPCION = 0,
                    ID_ESTADO = (int)cb_estado.SelectedValue,
                    RUT_EMPLEADO = cb_empleado.SelectedValue.ToString().Trim(),
                    ID_COMPRA = (decimal)cb_orden.SelectedValue
                };

                if (rpr.Create())
                {
                    MessageBoxResult exito = MessageBox.Show("Recpeción asignada", "Éxito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se asigno recepción", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Debe llenar todos los campos", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Ventana_principal vp = new Ventana_principal();
            vp.Show();
            this.Hide();
        }
    }
}
