using FerreteriaFerme.Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FerreteriaFerme
{
    /// <summary>
    /// Lógica de interacción para Lista_resumen.xaml
    /// </summary>
    public partial class Lista_resumen : Window
    {
        public Lista_resumen()
        {
            InitializeComponent();
            MostrarResumen();
        }

        private void MostrarResumen()
        {
            int periodo = int.Parse(DateTime.Now.AddMonths(-1).ToString("MMyyyy"));
            Resumen_Productos rep = new Resumen_Productos();
            dtg_resumen.ItemsSource = rep.ReadPeriodo(periodo);
            dtg_resumen.Items.Refresh();
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Administrador_auditoria aa = new Administrador_auditoria();
            aa.Show();
            this.Hide();
        }

        private void Btn_excel_Click(object sender, RoutedEventArgs e)
        {
            string periodo = DateTime.Now.AddMonths(-1).ToString("MMyyyy");
            dtg_resumen.SelectAllCells();
            dtg_resumen.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dtg_resumen);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtg_resumen.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\productos\"+periodo+".xls");
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();

            MessageBox.Show("Reporte en excel generado");
        }
    }
}
