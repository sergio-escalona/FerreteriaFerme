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
    /// Lógica de interacción para Agregar_empleado.xaml
    /// </summary>
    public partial class Agregar_empleado : Window
    {
        public Agregar_empleado()
        {
            InitializeComponent();
            Llenarcargo();
            Llenartipo();
        }

        //Llenar combobox de cargo
        private void Llenarcargo()
        {
            Cargo car = new Cargo();
            cb_cargo.ItemsSource = car.ReadAll();

            cb_cargo.DisplayMemberPath = "NOMBRE_CARGO";
            cb_cargo.SelectedValuePath = "ID_CARGO";

            cb_cargo.SelectedIndex = -1;
        }

        //Llenar combobox de tipo
        private void Llenartipo()
        {
            Tipo_Usuario tiu = new Tipo_Usuario();
            cb_tipo.ItemsSource = tiu.ReadAll();

            cb_tipo.DisplayMemberPath = "NOMBRE";
            cb_tipo.SelectedValuePath = "ID_TIPOUSU";

            cb_tipo.SelectedIndex = -1;
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_rut.Text != String.Empty && txt_nombre.Text != String.Empty && txt_apellido.Text != String.Empty &&
                    cb_cargo.Text != String.Empty && cb_tipo.Text != String.Empty)
            {
                int espacio = txt_apellido.Text.IndexOf(' ');
                Usuario usr = new Usuario()
                {
                    ID_USUARIO = 0,
                    NOMBRE_USUARIO = txt_nombre.Text.Substring(0, 3) + "." + txt_apellido.Text.Substring(0, espacio),
                    CONTRASENA = txt_rut.Text,
                    ID_TIPOUSU = (short)cb_tipo.SelectedValue
                };

                if (usr.Create())
                {
                    Empleado emp = new Empleado()
                    {
                        RUT_EMPLEADO = txt_rut.Text,
                        NOMBRES_EMPLEADO = txt_nombre.Text,
                        APELLIDOS_EMPLEADO = txt_apellido.Text,
                        ID_CARGO = (short)cb_cargo.SelectedValue,
                        ID_USUARIO = usr.ReadNombre(txt_nombre.Text.Substring(0, 3) + "." + txt_apellido.Text.Substring(0, espacio))[0].ID_USUARIO
                    };

                    if (emp.Create())
                    {
                        MessageBoxResult exito = MessageBox.Show("Se agregó el empleado", "Éxito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarDatos();
                    }

                    else
                    {
                        MessageBoxResult mal = MessageBox.Show("No se agregó el empleado", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    }                    
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
            Administrador_empleado ae = new Administrador_empleado();
            ae.Show();
            this.Hide();
        }

        private void LimpiarDatos()
        {
            txt_rut.Text = String.Empty;
            txt_nombre.Text = String.Empty;
            txt_apellido.Text = String.Empty;
            cb_cargo.Text = String.Empty;
            cb_tipo.Text = String.Empty;
        }
    }
}
