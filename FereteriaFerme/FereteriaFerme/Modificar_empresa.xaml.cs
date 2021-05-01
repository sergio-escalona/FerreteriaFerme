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
    /// Lógica de interacción para Modificar_empresa.xaml
    /// </summary>
    public partial class Modificar_empresa : Window
    {
        public Modificar_empresa(short? id)
        {
            InitializeComponent();
            this.id = id;
            LlenarTipo();
            CargarDatos();
        }

        short? id;

        private void LlenarTipo()
        {
            Tipo_Empresa tie = new Tipo_Empresa();
            cb_tipo.ItemsSource = tie.ReadAll();

            cb_tipo.DisplayMemberPath = "NOMBRE_TIPO";
            cb_tipo.SelectedValuePath = "ID_TIPO";

            cb_tipo.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            Empresa emp = new Empresa()
            {
                ID_EMPRESA = id
            };

            if (emp.Read())
            {
                txt_rut.Text = emp.RUT_EMPRESA;
                txt_razon.Text = emp.RAZON_SOCIAL;
                txt_correo.Text = emp.CORREO_EMPRESA;
                cb_tipo.SelectedValue = emp.ID_TIPO;
            }
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Empresa emp_viejo = new Empresa()
            {
                ID_EMPRESA = id
            };

            if (emp_viejo.Read())
            {
                Empresa emp = new Empresa()
                {
                    ID_EMPRESA = id,
                    RAZON_SOCIAL = txt_razon.Text,
                    RUT_EMPRESA = txt_rut.Text,
                    ID_TIPO = (short)cb_tipo.SelectedValue,
                    CORREO_EMPRESA = txt_correo.Text,
                    RUT_CLIENTE = emp_viejo.RUT_CLIENTE
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
            Lista_empresa le = new Lista_empresa();
            le.Show();
            this.Hide();
        }
    }
}
