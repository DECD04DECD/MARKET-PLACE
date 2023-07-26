using MARKET_PLACE.Context;
using MARKET_PLACE.Entities;
using MARKET_PLACE.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
            
        }
        UsuarioServices Servicios = new UsuarioServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                using (var _Context = new ApplicationDbContext())
                {
                    Usuario usuario = new Usuario();

                    usuario.Nombre = TxtName.Text;
                    usuario.UserName = TxtUserName.Text;
                    usuario.Password = TxtPassword.Password;

                    //usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());
                    Servicios.AddUsuario(usuario);

                    TxtName.Clear();
                    TxtUserName.Clear();
                    TxtPassword.Clear();

                    MessageBox.Show("Se agrego correctamente");

                    Close();

                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }

        private void BtCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
