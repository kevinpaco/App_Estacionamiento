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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security;
using ClasesBase;
using System.Collections.ObjectModel;

namespace Vistas
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

        //private List<Usuario> listUsers = new List<Usuario>();
        private ObservableCollection<Usuario> listUsers = new ObservableCollection<Usuario>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listUsers = TrabajarUsuarios.TraerUsuario();
            
            //Usuario operador = new Usuario("juant","123","juan","topo","operador");
            //Usuario admin = new Usuario("carl", "123", "carlos", "ergia", "admin");
            //this.listUsers.Add(operador);
            //this.listUsers.Add(admin);
            string rutaAudio = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios", "sonido1.mp3");
            mediaElement.Source = new Uri(rutaAudio, UriKind.RelativeOrAbsolute);
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
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener los valores de UserName y Password del UserControl
                string userName = ucLogin.UserName;
                string password = ucLogin.Password;

                Usuario user = this.listUsers.FirstOrDefault(userfind => userfind.UserName == userName && userfind.Password == password);
                //Usuario user2 = UsuarioABM.buscarUnUsuario(userName);

                if (user != null)
                {
                    VentanaPrincipal vp = new VentanaPrincipal();
                    vp.cargarUser(user);
                    vp.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Acceso Denegado, Verifique los datos");
                }
            }
            catch {
                MessageBox.Show("Acceso Denegado, Verifique los datos");
            }                
        }

       

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
