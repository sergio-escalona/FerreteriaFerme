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
    /// Lógica de interacción para Modificar_empleado.xaml
    /// </summary>
    public partial class Modificar_empleado : Window
    {
        public Modificar_empleado(string rut)
        {
            InitializeComponent();
            this.rut = rut;
            Llenarcargo();
            CargarDatos();
        }

        string rut;

        private void Llenarcargo()
        {
            Cargo car = new Cargo();
            cb_cargo.ItemsSource = car.ReadAll();

            cb_cargo.DisplayMemberPath = "NOMBRE_CARGO";
            cb_cargo.SelectedValuePath = "ID_CARGO";

            cb_cargo.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            Empleado emp = new Empleado()
            {
                RUT_EMPLEADO = rut
            };

            if (emp.Read())
            {
                txt_rut.Text = emp.RUT_EMPLEADO;
                txt_nombre.Text = emp.NOMBRES_EMPLEADO;
                txt_apellido.Text = emp.APELLIDOS_EMPLEADO;
                cb_cargo.SelectedValue = emp.ID_CARGO;
            }
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp_viejo = new Empleado()
            {
                RUT_EMPLEADO = rut
            };

            if (emp_viejo.Read())
            {
                Empleado emp = new Empleado()
                {
                    RUT_EMPLEADO = txt_rut.Text,
                    NOMBRES_EMPLEADO = txt_nombre.Text,
                    APELLIDOS_EMPLEADO = txt_apellido.Text,
                    ID_CARGO = (short)cb_cargo.SelectedValue,
                    ID_USUARIO = emp_viejo.ID_USUARIO
                };

                if (emp.Update())
                {
                    MessageBoxResult exito = MessageBox.Show("Se guardo", "bkn",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se guardo", "mala",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Lista_empleado lie = new Lista_empleado();
            lie.Show();
            this.Hide();
        }
    }
}
