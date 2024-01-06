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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinClienteABM.xaml
    /// </summary>
    public partial class WinClienteABM : Window
    {
        private List<Cliente> clientes = new List<Cliente>();

        public WinClienteABM()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lblTotalClientes.Content = "Total registrados: " + clientes.Count;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Permite mover la ventana actual manteniendo el click izquierdo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Devuelve una lista de clientes de modo hardcoded.
        /// </summary>
        /// <returns></returns>
        public List<Cliente> Cargar_Lista_Clientes()
        {
            clientes.Add(new Cliente(4012020, "Joaquin", "Corimayo", "11102292929"));
            clientes.Add(new Cliente(9512952, "Facundo", "Coco", "3439843883"));
            return clientes;
        }

        /// <summary>
        /// Permite realizar el alta de un Cliente.
        /// Solo captura los valores de los texboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Agregar_Cliente_Click(object sender, RoutedEventArgs e)
        {
            WinClienteAlta wca = new WinClienteAlta();
            wca.opcionesCliente(null, 'a');
            if (wca.ShowDialog() == true)
            {
                wca.DniTextBox.IsReadOnly = false;
                clientes.Add(wca.Cliente);
                // Actualizar la vista del DataGrid
                ClientesDataGrid.Items.Refresh();
            }
        }

        /// <summary>
        /// Permite realizar la modificacion de los datos de un cliente seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modificar_Cliente_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada
            DataRowView rowView = (DataRowView)ClientesDataGrid.SelectedItem;

            // Verificar si se ha seleccionado una fila
            if (rowView == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para ver los detalles.");
                return;
            }

            // Obtener los datos de la fila seleccionada
            DataRow row = rowView.Row;

            // Crear un objeto TipoVehiculo a partir de los datos de la fila
            Cliente clienteSeleccionado = new Cliente
            {
                ClienteDni = Convert.ToInt32(row["Dni"]),
                Apellido = row["Apellido"].ToString(),
                Nombre = row["Nombre"].ToString(),
                Telefono = row["Telefono"].ToString()

            };

            // Crear una ventana de modificación y pasar el cliente seleccionado
            //  WinClienteModificar wcm = new WinClienteModificar(clienteSeleccionado);
            WinClienteAlta wca = new WinClienteAlta();
            wca.opcionesCliente(clienteSeleccionado, 'm');
            // Abrir la ventana de modificación
            if (wca.ShowDialog() == true)
            {
                wca.DniTextBox.IsReadOnly = true;
                clientes.Remove(clienteSeleccionado);
                clientes.Add(wca.ClienteModificado);
                // Actualizar la vista del DataGrid si se guardaron cambios
                ClientesDataGrid.Items.Refresh();
            }
        }

        /// <summary>
        /// Permite eliminar un cliente seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eliminar_Cliente_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada
            DataRowView rowView = (DataRowView)ClientesDataGrid.SelectedItem;

            // Verificar si se ha seleccionado una fila
            if (rowView == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para ver los detalles.");
                return;
            }

            // Obtener los datos de la fila seleccionada
            DataRow row = rowView.Row;

            // Crear un objeto TipoVehiculo a partir de los datos de la fila
            Cliente clienteSeleccionado = new Cliente
            {
                ClienteDni = Convert.ToInt32(row["Dni"]),
                Apellido = row["Apellido"].ToString(),
                Nombre = row["Nombre"].ToString(),
                Telefono = row["Telefono"].ToString()

            };

            // Confirmar la eliminación
            MessageBoxResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?",
                                                            "Confirmación de eliminación",
                                                            MessageBoxButton.YesNo,
                                                            MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                // Eliminar el cliente de la fuente de datos
                TrabajarClientes.eliminarCliente(clienteSeleccionado);

                ClientesDataGrid.ItemsSource = TrabajarClientes.TraerClientes().DefaultView;
            }
        }

        /// <summary>
        /// Permite ver detalles de un cliente seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detalles_Cliente_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la fila seleccionada
            DataRowView rowView = (DataRowView)ClientesDataGrid.SelectedItem;

            // Verificar si se ha seleccionado una fila
            if (rowView == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para ver los detalles.");
                return;
            }

            // Obtener los datos de la fila seleccionada
            DataRow row = rowView.Row;

            // Crear un objeto TipoVehiculo a partir de los datos de la fila
            Cliente clienteSeleccionado = new Cliente
            {
                ClienteDni = Convert.ToInt32(row["Dni"]),
                Apellido = row["Apellido"].ToString(),
                Nombre = row["Nombre"].ToString(),
                Telefono = row["Telefono"].ToString()

            };

            // Crear y mostrar la ventana de detalles
            //  WinClienteDetalle wcd = new WinClienteDetalle(clienteSeleccionado);
            WinClienteAlta wcd = new WinClienteAlta();
            wcd.opcionesCliente(clienteSeleccionado, 'd');
            wcd.ShowDialog();
        }

        private void btnValidar_Cliente_Click(object sender, RoutedEventArgs e)
        {
            ValidarCliente vc = new ValidarCliente();
            vc.ShowDialog();
        }

    }
}

