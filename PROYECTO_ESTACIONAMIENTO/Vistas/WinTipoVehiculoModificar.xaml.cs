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
using System.Text.RegularExpressions;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinTipoVehiculoModificar.xaml
    /// </summary>
    public partial class WinTipoVehiculoModificar : Window
    {
        public TipoVehiculo TipoVehiculoModificado { get; private set; }
        private TipoVehiculo tipoVehiculoOriginal;

        public WinTipoVehiculoModificar()
        {
            InitializeComponent();
        }

        public WinTipoVehiculoModificar(TipoVehiculo tipoVehiculo)
        {
            InitializeComponent();

            // Inicializar los campos de entrada con los detalles del Vehiculo
            tipoVehiculoOriginal = tipoVehiculo;
            TvCodigoTextBox.Text = tipoVehiculo.TvCodigo.ToString();
            DescripcionTextBox.Text = tipoVehiculo.Descripcion;
            TarifaTextBox.Text = tipoVehiculo.Tarifa.ToString();
            // TODO: Validar datos
        }

        private void Agregar_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            // Crea un nuevo vehiculo con los datos ingresados en la ventana - TipoVehiculo(int tvCodigo, String descripcion, decimal tarifa))
            TipoVehiculo vehiculo = new TipoVehiculo();
            vehiculo = crearVehiculo();
            if (vehiculo != null)
            {
                MessageBox.Show(vehiculo.ToString(), "Informacion actualizada del Vehiculo");

                TrabajarTiposVehiculo.modificarTipoVehiculo(vehiculo);

                WinTipoVehicleABM win = Application.Current.Windows.OfType<WinTipoVehicleABM>().FirstOrDefault();

                if (win != null)
                {
                    win.VehiculosDataGrid.ItemsSource = TrabajarTiposVehiculo.TraerTiposVehiculo().DefaultView;
                    win.VehiculosDataGrid.Items.Refresh();
                    win.Activate(); 
                }

                this.Close();
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

            if (!string.IsNullOrWhiteSpace(TvCodigoTextBox.Text) &&
                !string.IsNullOrWhiteSpace(TarifaTextBox.Text) &&
                !string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                if (int.TryParse(TvCodigoTextBox.Text, out cod) && decimal.TryParse(TarifaTextBox.Text, out tarifa))
                {
                    if (ValidarDescripcion(DescripcionTextBox.Text))
                    {
                        if (tarifa >= 0)
                        {
                            return new TipoVehiculo(cod, DescripcionTextBox.Text, tarifa);
                        }
                        else
                        {
                            MessageTextBlock.Text = "Ingrese valores positivos para la tarifa.";
                        }
                    }
                    else
                    {
                        MessageTextBlock.Text = "La descripción contiene caracteres no válidos.";
                    }
                }
                else
                {
                    MessageTextBlock.Text = "Ingrese valores numéricos válidos para el código y la tarifa.";
                }
            }
            else
            {
                MessageTextBlock.Text = "Por favor, complete todos los campos.";
            }

            return null;
        }

        private bool ValidarDescripcion(string descripcion)
        {
            string patron = @"^[A-Za-z\s]+$";
            return Regex.IsMatch(descripcion, patron);
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

    }
}
