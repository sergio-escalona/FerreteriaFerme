using FerreteriaFerme.Negocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para Agregar_producto.xaml
    /// </summary>
    public partial class Agregar_producto : Window
    {
        public Agregar_producto()
        {
            InitializeComponent();
            Llenarproveedor();
            Llenarfamilia();
            Llenartipo();
        }

        //Llenar combobox de proveedor
        private void Llenarproveedor()
        {
            Proveedor pro = new Proveedor();
            cb_proveedor.ItemsSource = pro.ReadAll();

            cb_proveedor.DisplayMemberPath = "NOMBRE_PROVEEDOR";
            cb_proveedor.SelectedValuePath = "ID_PROVEEDOR";

            cb_proveedor.SelectedIndex = -1;
        }

        //Llenar combobox de familia
        private void Llenarfamilia()
        {
            Familia_Producto fp = new Familia_Producto();
            cb_familia.ItemsSource = fp.ReadAll();

            cb_familia.DisplayMemberPath = "NOMBRE_FAMILIA";
            cb_familia.SelectedValuePath = "ID_FAMILIA";

            cb_familia.SelectedIndex = -1;
        }

        //Llenar combobox de tipo de producto
        private void Llenartipo()
        {
            Tipo_Producto tp = new Tipo_Producto();
            cb_tipo.ItemsSource = tp.ReadAll();

            cb_tipo.DisplayMemberPath = "NOMBRE_TIPO";
            cb_tipo.SelectedValuePath = "ID_TIPO";

            cb_tipo.SelectedIndex = -1;
        }

        //Ingreso de foto
        private void Btn_foto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Elije una imagen";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                img_producto.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        //Botones de vencimiento de producto
        private void Rb_no_Checked(object sender, RoutedEventArgs e)
        {
            dp_vencimiento.IsEnabled = false;
        }

        private void Rb_si_Checked(object sender, RoutedEventArgs e)
        {
            dp_vencimiento.IsEnabled = true;
        }

        DateTime? vencimiento;

        //Guardar producto
        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nombre.Text != String.Empty && cb_proveedor.Text != String.Empty && cb_familia.Text != String.Empty &&
                cb_tipo.Text != String.Empty && txt_descripcion.Text != String.Empty && txt_clp.Text != String.Empty &&
                txt_usd.Text != String.Empty && txt_stock.Text != String.Empty && ((BitmapImage)img_producto.Source).UriSource != null)
            {
                if (rb_si.IsChecked == true)
                {
                    if (dp_vencimiento.Text != String.Empty)
                    {
                        vencimiento = DateTime.Parse(dp_vencimiento.Text);
                    }

                    else
                    {
                        MessageBoxResult mal = MessageBox.Show("Ingrese fecha de vencimiento", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                else
                {
                    vencimiento = null;
                }

                string directorio = "C:\\Users\\CASA\\Downloads\\Fermefix - carro decente\\Fermefix\\app\\static\\app\\img";
                string path = System.IO.Path.Combine(directorio, Concatenar((short)cb_proveedor.SelectedValue, (short)cb_familia.SelectedValue, vencimiento, (short)cb_tipo.SelectedValue) + ".png");
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)img_producto.Source));
                using (FileStream stream = new FileStream(path, FileMode.Create))
                encoder.Save(stream);

                Producto pro = new Producto()
                {
                    ID_PRODUCTO = Concatenar((short)cb_proveedor.SelectedValue, (short)cb_familia.SelectedValue, vencimiento, (short)cb_tipo.SelectedValue),
                    NOMBRE_PRODUCTO = txt_nombre.Text,
                    ID_PROVEEDOR = (short)cb_proveedor.SelectedValue,
                    ID_FAMILIA = (short)cb_familia.SelectedValue,
                    FECHA_VENCIMIENTO = vencimiento,
                    ID_TIPO = (short)cb_tipo.SelectedValue,
                    DESCRIPCION = txt_descripcion.Text,
                    PRECIO_CLP = int.Parse(txt_clp.Text),
                    PRECIO_USD = int.Parse(txt_usd.Text),
                    STOCK = short.Parse(txt_stock.Text),
                    FOTO = getJPGFromImageControl(img_producto.Source as BitmapImage)
                };

                if (pro.Create())
                {
                    MessageBoxResult exito = MessageBox.Show("Se guardo producto", "Éxito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarDatos();
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se guardo producto", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Debe llenar todos los campos", "Error",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Concatenador de id producto
        static long Concatenar(short proveedor, short familia, DateTime? vencimiento, short tipo)
        {
            // Convierte los valores a string
            String s1 = proveedor.ToString();
            String s2 = familia.ToString();
            String s3;
            if (vencimiento == null)
            {
                s3 = "00000000";
            }
            else
            {
                s3 = vencimiento?.ToString("ddMMyyyy");
            }
            String s4 = tipo.ToString();

            // Concatena los strings
            String s = s1 + s2 + s3 + s4;

            // Convierte el string a int
            long c = long.Parse(s);

            // Retorna la id
            return c;
        }

        //Imagen a array
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Bodeguero_producto bp = new Bodeguero_producto();
            bp.Show();
            this.Hide();
        }

        private void Txt_clp_Validacion(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_usd_Validacion(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_stock_Validacion(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LimpiarDatos()
        {
            txt_nombre.Text = String.Empty;
            cb_proveedor.Text = String.Empty;
            cb_familia.Text = String.Empty;
            rb_no.IsChecked = true;
            dp_vencimiento.Text = String.Empty;
            cb_tipo.Text = String.Empty;
            txt_descripcion.Text = String.Empty;
            txt_clp.Text = String.Empty;
            txt_usd.Text = String.Empty;
            txt_stock.Text = String.Empty;
            ((BitmapImage)img_producto.Source).UriSource = null;
        }
    }
}
