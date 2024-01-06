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
    /// Interaction logic for VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private Usuario user;
        public void cargarUser(Usuario user)
        {
            this.user = user;
            if (user.Rol.Equals("operador"))
            {
              
                btnVehiculo.Visibility = Visibility.Collapsed;
                btnUsuarios.Visibility = Visibility.Collapsed;
                btnListUsuarios.Visibility = Visibility.Collapsed;
            }
            else if (user.Rol.Equals("admin"))
            {
                btnCliente.Visibility = Visibility.Collapsed;
                btnEstacionamiento.Visibility = Visibility.Collapsed;
              
            }
            lblpass.Content = user.Rol;
            lblusu.Content = user.UserName;
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
            MainWindow lg = new MainWindow();
            lg.Show();
            this.Close();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            bdrCliente.Visibility = Visibility.Visible;
            WinClienteABM wcabm = new WinClienteABM();
            wcabm.ShowDialog();
        }

        private void btnVehiculo_Click(object sender, RoutedEventArgs e)
        {
            bdrCliente.Visibility = Visibility.Collapsed;
            WinTipoVehicleABM wvabm = new WinTipoVehicleABM();
            wvabm.Show();
        }

        private void btnEstacionamineto_Click(object sender, RoutedEventArgs e)
        {
            /*bdrCliente.Visibility = Visibility.Visible;
            WinEstacionamiento wsabm = new WinEstacionamiento();
            wsabm.Show();*/
            VehiculosEnPlaya vp = new VehiculosEnPlaya();
            vp.TipoUser(this.user);
            vp.Show();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            /*bdrCliente.Visibility = Visibility.Visible;
            WinEstacionamiento wsabm = new WinEstacionamiento();
            wsabm.Show();*/
            WinUsuariosABM ua = new WinUsuariosABM();
            ua.ShowDialog();
        }

        private void btnListUsuarios_Click(object sender, RoutedEventArgs e)
        {
            /*bdrCliente.Visibility = Visibility.Visible;
            WinEstacionamiento wsabm = new WinEstacionamiento();
            wsabm.Show();*/
            WinListadoUsuarios lu = new WinListadoUsuarios();
            lu.ShowDialog();
        }

        private void btnSector_Click(object sender, RoutedEventArgs e)
        {
            bdrCliente.Visibility = Visibility.Collapsed;
            WinSectores wsabm = new WinSectores();
            wsabm.Show();
        }

        private void btnAgregarTicket_Click(object sender, RoutedEventArgs e)
        {
            WinRegistrarEntrada re = new WinRegistrarEntrada();
            re.ShowDialog();
        }

        private void btnAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            WinAcercaDe a = new WinAcercaDe();
            a.ShowDialog();
        }

        private void btnListVentas_Click(object sender, RoutedEventArgs e)
        {
            WinListadoDeVentas listVentas = new WinListadoDeVentas();
            listVentas.ShowDialog();
        }
        
    }
}
