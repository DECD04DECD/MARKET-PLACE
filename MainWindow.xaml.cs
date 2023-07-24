using MARKET_PLACE.Context;
using MARKET_PLACE.Entities;
using MARKET_PLACE.Services;
using MARKET_PLACE.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MARKET_PLACE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState=WindowState.Minimized;
        }
        UsuarioServices Services = new UsuarioServices();
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {


         


          try
          {
              using (var _Context = new ApplicationDbContext())
              {
                  String UserName = TxtUserName.Text;
                  String Password = TxtPassword.Password;
                  var res = Services.Login(UserName, Password);
                  if (res.Roles.Nombre == "Administrador")
                  {
                      Administrador Admin = new Administrador();
                      Close();
                      Admin.Show();
                  }            
                  else if (res.Roles.Nombre == "Vendedor")
                  {
                      Productos pr = new Productos();
                      Close();
                      pr.Show();
                  }
                  else if (res.Roles.Nombre == "Comprador")
                   {
                  return;
                  }

                }
          }
          catch ( Exception ex)
          {

              throw new Exception("Error: " + ex.Message);
          }
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
            
        }
    }
}
