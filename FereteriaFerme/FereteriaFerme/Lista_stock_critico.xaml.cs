using FereteriaFerme;
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
    /// Lógica de interacción para Lista_stock_critico.xaml
    /// </summary>
    public partial class Lista_stock_critico : Window
    {
        public Lista_stock_critico()
        {
            InitializeComponent();
            MostrarProducto();
        }

        private void MostrarProducto()
        {
            Producto pro = new Producto();
            dtg_productos.ItemsSource = pro.Stock();
            dtg_productos.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
