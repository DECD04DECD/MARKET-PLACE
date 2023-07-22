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

namespace MARKET_PLACE.Vistas
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TBshow(object sender, RoutedEventArgs e)
        {
          // Content.Opacity = 0.5;
        }

        private void TBhide(object sender, RoutedEventArgs e)
        {
            //Content.Opacity = 1;
        }

        private void PreviewMouseLefthButtonDownBG(object sender, MouseButtonEventArgs e)
        {
            BtnShowHide.IsChecked=false;
        }

        private void Carrito(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
