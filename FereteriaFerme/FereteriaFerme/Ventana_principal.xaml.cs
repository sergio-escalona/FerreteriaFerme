﻿using FereteriaFerme;
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
    /// Lógica de interacción para Ventana_principal.xaml
    /// </summary>
    public partial class Ventana_principal : Window
    {
        public Ventana_principal()
        {
            InitializeComponent();
        }

        private void Btn_agregarProducto_Click(object sender, RoutedEventArgs e)
        {
            Agregar_producto agrpro = new Agregar_producto();
            agrpro.Show();
            this.Hide();
        }

        private void Btn_listarProducto_Click(object sender, RoutedEventArgs e)
        {
            MainWindow lispro = new MainWindow();
            lispro.Show();
            this.Hide();
        }
    }
}
