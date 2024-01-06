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
    /// Interaction logic for WinTipoVehiculoDetalle.xaml
    /// </summary>
    public partial class WinTipoVehiculoDetalle : Window
    {
        public WinTipoVehiculoDetalle()
        {
            InitializeComponent();
        }


        public WinTipoVehiculoDetalle(TipoVehiculo tipoVehiculo)
        {
            InitializeComponent();

            // Mostrar los detalles del vehiculo en la ventana de detalles
            TvCodigoTextBox.Text = tipoVehiculo.TvCodigo.ToString();
            DescripcionTextBox.Text = tipoVehiculo.Descripcion;
            TarifaTextBox.Text = tipoVehiculo.Tarifa.ToString();

            // Deshabilitar la edición de campos de texto
            //TvCodigoTextBox.IsEnabled = false;
            //DescripcionTextBox.IsEnabled = false;
            //TarifaTextBox.IsEnabled = false;
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