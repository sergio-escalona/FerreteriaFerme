﻿using FerreteriaFerme.Negocio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using FereteriaFerme;
using System.Text.RegularExpressions;

namespace FerreteriaFerme
{
    /// <summary>
    /// Lógica de interacción para Modificar_producto.xaml
    /// </summary>
    public partial class Modificar_producto : Window
    {
        public Modificar_producto(long id)
        {
            InitializeComponent();
            this.id = id;
            Llenarproveedor();
            Llenarfamilia();
            Llenartipo();
            Cargar_datos();
        }

        long id;

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
        //Guardar cambios
        private void Btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nombre.Text != String.Empty && cb_proveedor.Text != String.Empty && cb_familia.Text != String.Empty &&
                cb_tipo.Text != String.Empty && txt_descripcion.Text != String.Empty && txt_clp.Text != String.Empty &&
                txt_usd.Text != String.Empty && txt_stock.Text != String.Empty)
            {
                Producto pro = new Producto()
                {
                    ID_PRODUCTO = id
                };

                if (pro.Read())
                {
                    if (rb_si.IsChecked == true)
                    {
                        vencimiento = DateTime.Parse(dp_vencimiento.Text);
                    }

                    else
                    {
                        vencimiento = null;
                    }

                    string directorio = "C:\\productos";
                    string path = System.IO.Path.Combine(directorio, Concatenar((short)cb_proveedor.SelectedValue, (short)cb_familia.SelectedValue, vencimiento, (short)cb_tipo.SelectedValue) + ".png");
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)img_producto.Source));
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                        encoder.Save(stream);

                    Producto prd = new Producto()
                    {
                        ID_PRODUCTO = id,
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

                    if (prd.Update())
                    {
                        MessageBoxResult exito = MessageBox.Show("Se modificó producto", "Éxito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        MessageBoxResult mal = MessageBox.Show("No se pudo modificar producto", "Error",
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

        //Carga de datos
        private void Cargar_datos()
        {
            Producto pro = new Producto()
            {
                ID_PRODUCTO = id
            };

            if (pro.Read())
            {
                txt_nombre.Text = pro.NOMBRE_PRODUCTO;
                cb_proveedor.SelectedValue = pro.ID_PROVEEDOR;
                cb_familia.SelectedValue = pro.ID_FAMILIA;
                if (pro.FECHA_VENCIMIENTO == null)
                {
                    rb_no.IsChecked = true;
                }
                else
                {
                    rb_si.IsChecked = true;
                    dp_vencimiento.SelectedDate = pro.FECHA_VENCIMIENTO;
                }
                cb_tipo.SelectedValue = pro.ID_TIPO;
                txt_descripcion.Text = pro.DESCRIPCION;
                txt_clp.Text = pro.PRECIO_CLP.ToString();
                txt_usd.Text = pro.PRECIO_USD.ToString();
                txt_stock.Text = pro.STOCK.ToString();
                img_producto.Source = ConvertByteArrayToBitMapImage(pro.FOTO);
            }
        }

        //Convertir array a imagen
        public BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            BitmapImage img = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(imageByteArray))
            {
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = memStream;
                img.EndInit();
                img.Freeze();
            }
            return img;
        }

        //Convertir imagen a array
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
            Lista_modificar_producto lmp = new Lista_modificar_producto();
            lmp.Show();
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
    }
}
