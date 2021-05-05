﻿using FerreteriaFerme.Negocio;
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
    /// Lógica de interacción para Agregar_direccion.xaml
    /// </summary>
    public partial class Agregar_direccion : Window
    {
        public Agregar_direccion(string rut)
        {
            InitializeComponent();
            this.rut = rut;
            LlenarRegion();
            LlenarComuna();
        }

        string rut;

        private void LlenarRegion()
        {
            Region reg = new Region();
            cb_region.ItemsSource = reg.ReadAll();

            cb_region.DisplayMemberPath = "NOMBRE_REGION";
            cb_region.SelectedValuePath = "ID_REGION";

            cb_region.SelectedIndex = 4;
        }

        private void LlenarComuna()
        {
            try
            {
                Comuna com = new Comuna();
                cb_comuna.ItemsSource = com.ReadRegion((string)cb_region.SelectedValue);

                cb_comuna.DisplayMemberPath = "NOMBRE_COMUNA";
                cb_comuna.SelectedValuePath = "ID_COMUNA";

                cb_comuna.SelectedIndex = 0;
            }
            catch (Exception ex) { }
        }

        private void Cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarComuna();
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_direccion.Text != String.Empty && cb_region.Text != String.Empty && cb_comuna.Text != String.Empty)
            {
                Direccion dir = new Direccion()
                {
                    ID_DIRECCION = 0,
                    DIRECCION1 = txt_direccion.Text,
                    ID_COMUNA = (short)cb_comuna.SelectedValue,
                    RUT_CLIENTE = rut,
                };

                if (dir.Create())
                {
                    MessageBoxResult exito = MessageBox.Show("Se creo la dirección de cliente", "Éxito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBoxResult mal = MessageBox.Show("No se guardo la dirección", "Error",
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
            Lista_direccion lid = new Lista_direccion(rut);
            lid.Show();
            this.Hide();
        }
    }
}
