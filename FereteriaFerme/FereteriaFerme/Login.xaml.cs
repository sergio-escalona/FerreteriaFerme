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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string rut;
        public static string nombre;

        private void Btn_ingresar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usu = new Usuario();

            if (usu.ReadNombre(txt_usuario.Text).Count() > 0)
            {
                short id = usu.ReadNombre(txt_usuario.Text)[0].ID_USUARIO;
                Usuario usr = new Usuario()
                {
                    ID_USUARIO = id
                };

                if (usr.Read())
                {
                    if (usr.NOMBRE_USUARIO==txt_usuario.Text && usr.CONTRASENA==txt_contraseña.Password)
                    {
                        Empleado emp = new Empleado();
                        rut = emp.ReadUsuario(usr.ID_USUARIO).First().RUT_EMPLEADO;
                        nombre = emp.ReadUsuario(usr.ID_USUARIO).First().NombreCompleto;

                        if (usr.ID_TIPOUSU == 1)
                        {
                            Inicio_administrador ia = new Inicio_administrador();
                            ia.Show();
                            this.Hide();
                        }

                        else if (usr.ID_TIPOUSU == 2)
                        {
                            Inicio_otros io = new Inicio_otros();
                            io.Show();
                            this.Hide();
                        }

                        else if (usr.ID_TIPOUSU == 3)
                        {                            
                            Inicio_bodeguero ib = new Inicio_bodeguero();
                            ib.Show();
                            this.Hide();
                        }

                        else if  (usr.ID_TIPOUSU == 5)
                        {
                            Inicio_despachador ind = new Inicio_despachador();
                            ind.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBoxResult mal = MessageBox.Show("Ud. no tiene permiso para acceder", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    else
                    {
                        MessageBoxResult mal = MessageBox.Show("Datos incorrectos", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("Datos incorrectos", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Datos incorrectos", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
