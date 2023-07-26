using MARKET_PLACE.Context;
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
    /// Lógica de interacción para Vendedor.xaml
    /// </summary>
    public partial class Vendedor : UserControl
    {
        public Vendedor()
        {
            InitializeComponent();
        }

        ProductoServices Services = new ProductoServices();
        private void BtnAddProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var _Context = new ApplicationDbContext())
                {
                    Producto producto = new Producto();
                    producto.Nombre = txtProducto.Text;
                    producto.Precio = double.Parse(txtPrecio.Text);
                    producto.Cantidad = int.Parse(txtCantidad.Text);
                    
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea continuar?", "Confirmación", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        Services.AddProducto(producto);

                        txtProducto.Clear();
                        txtPrecio.Clear();
                        txtCantidad.Clear();

                        MessageBox.Show("Producto Agregado con exito");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
