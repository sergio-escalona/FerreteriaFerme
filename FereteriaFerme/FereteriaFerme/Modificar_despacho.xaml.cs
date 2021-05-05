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
    /// Lógica de interacción para Modificar_despacho.xaml
    /// </summary>
    public partial class Modificar_despacho : Window
    {
        public Modificar_despacho(int id)
        {
            InitializeComponent();
            this.id = id;
            LlenarCompra();
            LlenarEmpleado();
            LlenarEstado();
            Cargar_datos();
        }

        int id;

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

        private void Cargar_datos()
        {
            Despacho des = new Despacho()
            {
                ID_DESPACHO = id
            };

            if (des.Read())
            {
                cb_compra.SelectedValue = des.IdCompra;
                LlenarProducto();
                cb_producto.SelectedValue = des.ID_DETALLE;
                cb_empleado.SelectedValue = des.RUT_EMPLEADO;
                cb_estado.SelectedValue = des.ID_ESTADO;
            }
        }

        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (cb_compra.Text != String.Empty && cb_producto.Text != String.Empty && cb_empleado.Text != String.Empty &&
                cb_estado.Text != String.Empty)
            {
                DateTime? fecha_entrega;

                if ((short)cb_estado.SelectedValue == 4)
                {
                    fecha_entrega = DateTime.Now;
                }

                else
                {
                    fecha_entrega = null;
                }

                Despacho des = new Despacho()
                {
                    ID_DESPACHO = id,
                    ID_DETALLE = (decimal)cb_producto.SelectedValue,
                    ID_ESTADO = (short)cb_estado.SelectedValue,
                    RUT_EMPLEADO = cb_empleado.SelectedValue.ToString().Trim(),
                    FECHA_ENVIO = DateTime.Now,
                    FECHA_RECEPCION = fecha_entrega
                };

                if (des.Update())
                {
                    MessageBoxResult exito = MessageBox.Show("Se modificó la orden de despacho", "Éxito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se modificó el despacho", "Error",
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
            Lista_despacho ld = new Lista_despacho();
            ld.Show();
            this.Hide();
        }
    }
}
