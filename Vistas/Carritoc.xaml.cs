using MARKET_PLACE.Entities;
using MARKET_PLACE.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MARKET_PLACE.Vistas
{
    /// <summary>
    /// Lógica de interacción para Carritoc.xaml
    /// </summary>
    public partial class Carritoc : UserControl
    {
        public Carritoc()
        {
            InitializeComponent();
        }
        carritofuncion services = new carritofuncion();


        private void VaciarCarrito_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar cuadro de diálogo de confirmación
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas vaciar el carrito?", "Confirmar vaciado", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Producto productos = new Producto();
                productos = (sender as FrameworkElement).DataContext as Producto;
                int ID = int.Parse(productos.PkProducto.ToString());
                services.vaciador(ID);
                
            }
        }

       

        private void pagar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de pagar carrito?", "Confirmar pago", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                services.pagar();

            }
          
        }
    }
}
