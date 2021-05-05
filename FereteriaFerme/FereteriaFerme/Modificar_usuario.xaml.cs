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
    /// Lógica de interacción para Modificar_usuario.xaml
    /// </summary>
    public partial class Modificar_usuario : Window
    {
        public Modificar_usuario(short id)
        {
            InitializeComponent();
            this.id = id;
            Llenartipo();
            CargarDatos();
        }

        short id;

        private void Llenartipo()
        {
            Tipo_Usuario tip = new Tipo_Usuario();
            cb_tipo.ItemsSource = tip.ReadAll();

            cb_tipo.DisplayMemberPath = "NOMBRE";
            cb_tipo.SelectedValuePath = "ID_TIPOUSU";

            cb_tipo.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            Usuario usu = new Usuario()
            {
                ID_USUARIO = id
            };

            if (usu.Read())
            {
                txt_usuario.Text = usu.NOMBRE_USUARIO;
                cb_tipo.SelectedValue = usu.ID_TIPOUSU;
            }
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_usuario.Text != String.Empty && txt_contrasena1.Password != String.Empty && 
                txt_contrasena2.Password != String.Empty && cb_tipo.Text != String.Empty)
            {
                if (txt_contrasena1.Password == txt_contrasena2.Password)
                {
                    Usuario usu = new Usuario()
                    {
                        ID_USUARIO = id,
                        NOMBRE_USUARIO = txt_usuario.Text,
                        CONTRASENA = txt_contrasena1.Password,
                        ID_TIPOUSU = (short)cb_tipo.SelectedValue
                    };

                    if (usu.Update())
                    {
                        MessageBoxResult exito = MessageBox.Show("Se modifico usuario empleado", "Éxito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        MessageBoxResult mal = MessageBox.Show("No se pudo modificar usuario empleado", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("Contraseñas no coinciden", "Error",
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
            Lista_empleado lie = new Lista_empleado();
            lie.Show();
            this.Hide();
        }
    }
}
