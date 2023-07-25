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
using System.Windows.Shapes;

namespace MARKET_PLACE.Vistas
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        public Administrador()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }

        UsuarioServices services = new UsuarioServices();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            if (txtPkUser.Text == "")
            {
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());

                services.AddUsuario(usuario);

                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();

                MessageBox.Show("Se agregó el usuario correctamente");
                GetUserTable();
            }
            else
            {

                usuario.PkUsuario = int.Parse(txtPkUser.Text); 

                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());

                services.UpdateUser(usuario);

                MessageBox.Show("Se editó el usuario correctamente");
                GetUserTable();

            }

        }
        private void DeletItem(object sender, RoutedEventArgs e)
        {
            Usuario usuarioSeleccionado = UserTable.SelectedItem as Usuario;

            if (usuarioSeleccionado != null)
            {
                services.deleteUser(usuarioSeleccionado.PkUsuario);
                MessageBox.Show("Se eliminó el usuario correctamente");
                GetUserTable();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún usuario para eliminar");
            }
        }
        public void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();

        }

        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRols();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }


        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario; 

            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow vl = new MainWindow();
            vl.Show();
        }
    }
}

