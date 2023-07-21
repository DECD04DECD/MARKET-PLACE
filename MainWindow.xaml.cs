using MARKET_PLACE.Context;
using MARKET_PLACE.Entities;
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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            Productos pr = new Productos();
            pr.Show();

            /*En prueba
          try
          {
              using (var _Context = new ApplicationDbContext())
              {
                  Usuario usuario = new Usuario();
                  usuario.UserName = TxtUserName.Text;
                  usuario.Password = TxtPassword.Password;

              }
          }
          catch ( Exception ex)
          {

              throw new Exception("Error: " + ex.Message);
          }

      }*/
        }
    }
}
