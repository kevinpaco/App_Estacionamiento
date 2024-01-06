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
    /// Interaction logic for WinTipoVehiculoAlta.xaml
    /// </summary>
    public partial class WinTipoVehiculoAlta : Window
    {
        public TipoVehiculo vehiculoTipo { get; private set; }

        public WinTipoVehiculoAlta()
        {
            InitializeComponent();
        }

        private void Agregar_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            // Crea un nuevo vehiculo con los datos ingresados en la ventana - TipoVehiculo(int tvCodigo, String descripcion, decimal tarifa))
            TipoVehiculo vehiculo = new TipoVehiculo();
            vehiculo = crearVehiculo();
            if (vehiculo != null)
            {
                MessageBox.Show(vehiculo.ToString(), "Informacion de Vehiculo");
                vehiculoTipo = vehiculo;
                TrabajarTiposVehiculo.guardarVehiculo(vehiculo);

                WinTipoVehicleABM win = new WinTipoVehicleABM();

                win.VehiculosDataGrid.ItemsSource = TrabajarTiposVehiculo.TraerTiposVehiculo().DefaultView;
                win.Show();


            }
            else
            {
                MessageTextBlock.Text = "Por favor, ingrese datos válidos para el vehiculo.";
            }
        }

        private TipoVehiculo crearVehiculo()
        {
            int cod;
            decimal tarifa;
            if (!string.IsNullOrWhiteSpace(TvCodigoTextBox.Text) && !string.IsNullOrWhiteSpace(TarifaTextBox.Text) && !string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                cod = int.Parse(TvCodigoTextBox.Text);
                if (TrabajarTiposVehiculo.VerificarExistenciaCodigo(cod))
                {
                    MessageBox.Show("Codigo Existente");
                    return null;
                }
                tarifa = decimal.Parse(TarifaTextBox.Text);
                return new TipoVehiculo(cod, DescripcionTextBox.Text, tarifa);
            }
            else
            {
                return null;
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}

