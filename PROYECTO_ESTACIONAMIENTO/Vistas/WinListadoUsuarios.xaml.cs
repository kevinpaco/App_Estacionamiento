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
    /// Interaction logic for WinListadoUsuarios.xaml
    /// </summary>
    public partial class WinListadoUsuarios : Window
    {
         CollectionViewSource vistaCollecionFiltrada;

        public WinListadoUsuarios()
        {
            InitializeComponent();
            vistaCollecionFiltrada = Resources["vista_user"] as CollectionViewSource;

          //  lts_user.ItemsSource = this.Resources["list_user"] as List<Usuario>;

          //  CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lts_user.ItemsSource);
          //  view.Filter = UserFilter;
        }

        private void filterUser(object sender, FilterEventArgs e)
        {
            Usuario oItem = (Usuario)e.Item;
            if (oItem.Apellido.StartsWith(txtfilter.Text))
                e.Accepted = true;
            else
                e.Accepted = false;
        }

        private void txtfilter_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            if (vistaCollecionFiltrada != null)
            {
                vistaCollecionFiltrada.Filter += new FilterEventHandler(filterUser);
            }

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
    }
}
