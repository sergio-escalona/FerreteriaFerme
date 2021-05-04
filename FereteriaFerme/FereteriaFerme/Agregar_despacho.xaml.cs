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
    /// Lógica de interacción para Agregar_despacho.xaml
    /// </summary>
    public partial class Agregar_despacho : Window
    {
        public Agregar_despacho()
        {
            InitializeComponent();
            LlenarCompra();
            LlenarEmpleado();
            LlenarEstado();
        }

        private void LlenarCompra()
        {
            Orden_Compra orc = new Orden_Compra();
            cb_compra.ItemsSource = orc.ReadAll();

            cb_compra.DisplayMemberPath = "ID_COMPRA";
            cb_compra.SelectedValuePath = "ID_COMPRA";

            cb_compra.SelectedIndex = -1;
        }

        private void LlenarProducto()
        {
            try
            {
                Detalle_Orden com = new Detalle_Orden();
                cb_producto.ItemsSource = com.ReadId((decimal)cb_compra.SelectedValue);

                cb_producto.DisplayMemberPath = "NombreProducto";
                cb_producto.SelectedValuePath = "ID_DETALLE";

                cb_producto.SelectedIndex = 0;
            }
            catch (Exception ex) { }
        }

        private void LlenarEmpleado()
        {
            Empleado emp = new Empleado();
            cb_empleado.ItemsSource = emp.ReadAll();

            cb_empleado.DisplayMemberPath = "NombreCompleto";
            cb_empleado.SelectedValuePath = "RUT_EMPLEADO";

            cb_empleado.SelectedIndex = -1;
        }

        private void LlenarEstado()
        {
            Estado_Despacho esd = new Estado_Despacho();
            cb_estado.ItemsSource = esd.ReadAll();

            cb_estado.DisplayMemberPath = "NOMBRE_ESTADO";
            cb_estado.SelectedValuePath = "ID_ESTADO";

            cb_estado.SelectedIndex = -1;
        }

        private void Cb_compra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarProducto();
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Despacho des = new Despacho()
            {
                ID_DESPACHO = 0,
                ID_DETALLE = (decimal)cb_producto.SelectedValue,
                ID_ESTADO = (short)cb_estado.SelectedValue,
                RUT_EMPLEADO = cb_empleado.SelectedValue.ToString().Trim(),
                FECHA_ENVIO = DateTime.Now
            };

            if (des.Create())
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

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Ventana_principal vp = new Ventana_principal();
            vp.Show();
            this.Hide();
        }
    }
}
