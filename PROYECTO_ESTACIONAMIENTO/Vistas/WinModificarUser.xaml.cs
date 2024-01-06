using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinModificarUser.xaml
    /// </summary>
    public partial class WinModificarUser : Window
    {
        public Usuario usuModificado;
        private int userId;

        public WinModificarUser()
        {
            InitializeComponent();
        }

        public void UserDatos(Usuario user)
        {
            userId = user.User_id;
            txtApe.Text = user.Apellido;
            txtNombre.Text = user.Nombre;
            txtPass.Text = user.Password;
            txtUname.Text = user.UserName;
            txtRol.Text = user.Rol;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = cargarUser();
            if (user != null)
            {
                //MessageBox.Show("es: " + user.Nombre + user.Apellido + user.Password + user.UserName);
                user.User_id = userId;
                UsuarioABM.modificarUsuario(user);
                MessageBox.Show("Modificado Exitosamente");
                DialogResult = true;
                usuModificado = user;
                Close();
            }
        }

        private Usuario cargarUser() 
        {
            if (!string.IsNullOrWhiteSpace(txtUname.Text) && !string.IsNullOrWhiteSpace(txtPass.Text)
                && !string.IsNullOrWhiteSpace(txtApe.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtRol.Text))
            {
                return new Usuario(txtUname.Text, txtPass.Text, txtNombre.Text, txtApe.Text, txtRol.Text);
            }
            else
            {
                return null;
            }        
        }
    }
}
