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
    /// Interaction logic for WinAltaUser.xaml
    /// </summary>
    public partial class WinAltaUser : Window
    {
        public Usuario usuario;

        public WinAltaUser()
        {
            InitializeComponent();
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = cargarUsuario();
            if (user != null)
            {
                bool existe = UsuarioABM.buscarUsuario(user.UserName);
                if (existe == true)
                {
                    UsuarioABM.ingresarUsuario(user);
                    MessageBox.Show("Guardado Exitosamente");
                    this.DialogResult = true;
                    usuario= user;
                    Close();
                   
                }
                else
                {
                    MessageBox.Show("Usuario Ya existe");
                }
            }
        }

        private Usuario cargarUsuario()
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
