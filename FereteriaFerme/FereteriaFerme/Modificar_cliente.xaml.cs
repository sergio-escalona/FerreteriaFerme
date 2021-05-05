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
    /// Lógica de interacción para Modificar_cliente.xaml
    /// </summary>
    public partial class Modificar_cliente : Window
    {
        public Modificar_cliente(string rut)
        {
            InitializeComponent();
            this.rut = rut;
            CargarDatos();
        }

        string rut;

        private void CargarDatos()
        {
            Cliente cli = new Cliente()
            {
                RUT_CLIENTE = rut
            };

            if (cli.Read())
            {
                txt_rut.Text = cli.RUT_CLIENTE;
                txt_nombre.Text = cli.NOMBRES;
                txt_apellido.Text = cli.APELLIDOS;
                txt_correo.Text = cli.CORREO_CLIENTE;
            }
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_rut.Text != String.Empty && txt_nombre.Text != String.Empty && txt_apellido.Text != String.Empty && 
                txt_correo.Text != String.Empty)
            {
                Cliente cli_viejo = new Cliente()
                {
                    RUT_CLIENTE = rut
                };

                if (cli_viejo.Read())
                {
                    Cliente cli = new Cliente()
                    {
                        RUT_CLIENTE = txt_rut.Text,
                        NOMBRES = txt_nombre.Text,
                        APELLIDOS = txt_apellido.Text,
                        ID_USUARIO = cli_viejo.ID_USUARIO,
                        CORREO_CLIENTE = txt_correo.Text
                    };

                    if (cli.Update())
                    {
                        MessageBoxResult exito = MessageBox.Show("Cliente modificado", "Éxito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        MessageBoxResult mal = MessageBox.Show("No se modifico el cliente", "mala",
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
            Lista_cliente lic = new Lista_cliente();
            lic.Show();
            this.Hide();
        }
    }
}
