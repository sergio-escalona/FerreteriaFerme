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
    /// Lógica de interacción para Modificar_direccion_empresa.xaml
    /// </summary>
    public partial class Modificar_direccion_empresa : Window
    {
        public Modificar_direccion_empresa(short id)
        {
            InitializeComponent();
            this.id = id;
        }

        short id;
    }
}
