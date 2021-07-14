﻿using FerreteriaFerme.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Lógica de interacción para Agregar_producto_proveedor.xaml
    /// </summary>
    public partial class Agregar_producto_proveedor : Window
    {
        public Agregar_producto_proveedor(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        int id;

        private void MostrarProducto()
        {
            Producto_Proveedor prp = new Producto_Proveedor();
            dtg_producto.ItemsSource = prp.ReadCompra(id);
            dtg_producto.Items.Refresh();
        }

        private void LimpiarDatos()
        {
            txt_producto.Text = String.Empty;
            txt_cantidad.Text = String.Empty;
            txt_precio.Text = String.Empty;
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_producto.Text != String.Empty && txt_cantidad.Text != String.Empty && txt_precio.Text != String.Empty)
            {
                Producto_Proveedor prp = new Producto_Proveedor()
                {
                    ID_PRODUCTO = 0,
                    NOMBRE_PRODUCTO = txt_producto.Text,
                    CANTIDAD = short.Parse(txt_cantidad.Text),
                    PRECIO_UNITARIO = int.Parse(txt_precio.Text),
                    ID_COMPRA = id
                };

                if (prp.Create())
                {
                    MostrarProducto();
                    LimpiarDatos();
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se guardo el producto", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBoxResult mal = MessageBox.Show("Debe llenar todos los campos", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto_Proveedor fila = (Producto_Proveedor)dtg_producto.SelectedItem;
            int id = fila.ID_PRODUCTO;

            Producto_Proveedor prp = new Producto_Proveedor()
            {
                ID_PRODUCTO = id
            };

            MessageBoxResult eliminar = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (eliminar == MessageBoxResult.Yes)
            {
                if (prp.Delete())
                {
                    MostrarProducto();
                    MessageBoxResult exito = MessageBox.Show("Producto eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Agregar_orden_proveedor aop = new Agregar_orden_proveedor();
            aop.Show();
            this.Hide();
        }

        private void Txt_cantidad_Validacion(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Txt_precio_Validacion(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                short proveedor = 0;
                string nombre = string.Empty;
                string correo = string.Empty;

                Producto_Proveedor prp = new Producto_Proveedor();

                if (prp.ReadCompra(id).Count > 0)
                {
                    Compra_Proveedor cop = new Compra_Proveedor()
                    {
                        ID_COMPRA = id
                    };

                    if (cop.Read())
                    {
                        proveedor = cop.ID_PROVEEDOR;
                    }

                    Proveedor pro = new Proveedor()
                    {
                        ID_PROVEEDOR = proveedor
                    };

                    if (pro.Read())
                    {
                        nombre = pro.NOMBRE_PROVEEDOR;
                        correo = pro.CORREO;
                    }

                    string periodo = DateTime.Now.ToString("ddMMyyyy");
                    dtg_producto.SelectAllCells();
                    dtg_producto.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, dtg_producto);
                    String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                    String result = (string)Clipboard.GetData(DataFormats.Text);
                    dtg_producto.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\productos\"+ nombre + "_" + periodo + ".xls");
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                    MailMessage mail = new MailMessage();
                    
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    //Correo origen
                    mail.From = new MailAddress("proyecto.ferme@gmail.com");
                    //Correo destino
                    mail.To.Add(correo);
                    //Asunto
                    mail.Subject = "Ferretria Ferme - Orden de productos";
                    //Detalle del correo
                    StringBuilder sbBody = new StringBuilder();
                    //Cada uno es una línea
                    sbBody.AppendLine("Estimado "+ nombre + ",");

                    sbBody.AppendLine("Ferreteria Ferme ha solicitado los productos adjuntados en el archivo excel");

                    sbBody.AppendLine("Saludos Cordiales");

                    sbBody.AppendLine("Ferreteria Ferme");

                    mail.Body = sbBody.ToString();
                    //Archivo adjunto
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(@"C:\productos\" + pro.NOMBRE_PROVEEDOR + "_" + periodo + ".xls");

                    mail.Attachments.Add(attachment);

                    //RECORDATORIO: Colocar contraseña
                    SmtpServer.Credentials = new System.Net.NetworkCredential("proyecto.ferme@gmail.com", "");
                    
                    SmtpServer.Port = 587;
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Orden enviada");
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("Debe ingresar al menos un producto para enviar la solicitud",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
