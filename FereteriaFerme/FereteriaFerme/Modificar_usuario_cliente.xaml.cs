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
    /// Lógica de interacción para Modificar_usuario_cliente.xaml
    /// </summary>
    public partial class Modificar_usuario_cliente : Window
    {
        public Modificar_usuario_cliente(short id)
        {
            InitializeComponent();
            this.id = id;
            CargarDatos();
        }

        short id;

        private void CargarDatos()
        {
            Usuario usu = new Usuario()
            {
                ID_USUARIO = id
            };

            if (usu.Read())
            {
                txt_usuario.Text = usu.NOMBRE_USUARIO;
            }
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_usuario.Text != String.Empty && txt_contrasena1.Password != String.Empty &&
                txt_contrasena2.Password != String.Empty)
            {
                if (txt_contrasena1.Password == txt_contrasena2.Password)
                {
                    Usuario usu_viejo = new Usuario()
                    {
                        ID_USUARIO = id
                    };

                    if (usu_viejo.Read())
                    {
                        Usuario usu = new Usuario()
                        {
                            ID_USUARIO = id,
                            NOMBRE_USUARIO = txt_usuario.Text,
                            CONTRASENA = txt_contrasena1.Password,
                            ID_TIPOUSU = usu_viejo.ID_TIPOUSU
                        };

                        if (usu.Update())
                        {
                            MessageBoxResult exito = MessageBox.Show("Se modifico usuario cliente", "Éxito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        else
                        {
                            MessageBoxResult mal = MessageBox.Show("No se pudo modificar usuario cliente", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
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
            Lista_cliente lic = new Lista_cliente();
            lic.Show();
            this.Hide();
        }
    }
}
