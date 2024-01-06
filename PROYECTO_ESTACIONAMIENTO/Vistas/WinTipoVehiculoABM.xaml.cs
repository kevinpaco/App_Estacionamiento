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
using System.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinTipoVehicleABM.xaml
    /// </summary>
    public partial class WinTipoVehicleABM : Window
    {
        public TipoVehiculo vehiculoTipo { get; private set; }

        public WinTipoVehicleABM()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTotalVehiculos.Content = "Total registrados: " + VehiculosDataGrid.Items.Count;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Permite realizar el alta de un Vehiculo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Agregar_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
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


        /// <summary>
        /// Permite realizar la modificacion de los datos de un Vehiculo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modificar_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada
            DataRowView rowView = (DataRowView)VehiculosDataGrid.SelectedItem;

            // Verificar si se ha seleccionado una fila
            if (rowView == null)
            {
                MessageBox.Show("Por favor, seleccione un vehículo para ver los detalles.");
                return;
            }

            // Obtener los datos de la fila seleccionada
            DataRow row = rowView.Row;

            // Crear un objeto TipoVehiculo a partir de los datos de la fila
            TipoVehiculo vehiculoSeleccionado = new TipoVehiculo
            {
                TvCodigo = Convert.ToInt32(row["Codigo"]),
                Descripcion = row["Descripcion"].ToString(),
                Tarifa = Convert.ToDecimal(row["Tarifa"])

            };

            // Crear una ventana de modificación y pasar el vehiculo seleccionado
            WinTipoVehiculoModificar wcm = new WinTipoVehiculoModificar(vehiculoSeleccionado);

            // Abrir la ventana de modificación
            if (wcm.ShowDialog() == true)
            {
                VehiculosDataGrid.Items.Refresh();
            }
        }

        /// <summary>
        /// Permite eliminar un Vehiculo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eliminar_Vehiculo_Click(object sender, RoutedEventArgs e)
        {

            // Obtener la fila seleccionada
            DataRowView rowView = (DataRowView)VehiculosDataGrid.SelectedItem;

            // Verificar si se ha seleccionado una fila
            if (rowView == null)
            {
                MessageBox.Show("Por favor, seleccione un vehículo para ver los detalles.");
                return;
            }

            // Obtener los datos de la fila seleccionada
            DataRow row = rowView.Row;

            // Crear un objeto TipoVehiculo a partir de los datos de la fila
            TipoVehiculo vehiculoSeleccionado = new TipoVehiculo
            {
                TvCodigo = Convert.ToInt32(row["Codigo"]),
                Descripcion = row["Descripcion"].ToString(),
                Tarifa = Convert.ToDecimal(row["Tarifa"])

            };

            // Confirmar la eliminación
            MessageBoxResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este vehiculo?",
                                                            "Confirmación de eliminación",
                                                            MessageBoxButton.YesNo,
                                                            MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                // Eliminar el vehículo de la fuente de datos
                TrabajarTiposVehiculo.eliminarTipoVehiculo(vehiculoSeleccionado);

                VehiculosDataGrid.ItemsSource = TrabajarTiposVehiculo.TraerTiposVehiculo().DefaultView;

            }

        }

        /// <summary>
        /// Permite ver detalles de un Vehiculo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detalles_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada
            DataRowView rowView = (DataRowView)VehiculosDataGrid.SelectedItem;

            // Verificar si se ha seleccionado una fila
            if (rowView == null)
            {
                MessageBox.Show("Por favor, seleccione un vehículo para ver los detalles.");
                return;
            }

            // Obtener los datos de la fila seleccionada
            DataRow row = rowView.Row;

            // Crear un objeto TipoVehiculo a partir de los datos de la fila
            TipoVehiculo vehiculoSeleccionado = new TipoVehiculo
            {
                TvCodigo = Convert.ToInt32(row["Codigo"]),
                Descripcion = row["Descripcion"].ToString(),
                Tarifa = Convert.ToDecimal(row["Tarifa"])

            };

            // Crear y mostrar la ventana de detalles
            WinTipoVehiculoDetalle wcd = new WinTipoVehiculoDetalle(vehiculoSeleccionado);
            wcd.ShowDialog();
        }

        /// <summary>
        /// Permite abrir la ventana de tipos de vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tipos_Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            WinTipoVehiculos tv = new WinTipoVehiculos();
            tv.ShowDialog();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            TvCodigoTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            TarifaTextBox.Text = string.Empty;
        }
    }
}
