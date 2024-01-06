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
    /// Interaction logic for WinClienteAlta.xaml
    /// </summary>
    public partial class WinClienteAlta : Window
    {
        public Cliente Cliente { get; private set; }
        public Cliente ClienteModificado { get; private set; }
        private Cliente clienteOriginal;
        public WinClienteAlta()
        {
            InitializeComponent();
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Recive un tipo Cliente y una opcion.
        ///La opcion puede ser: 'd'(detalle) o 'm'(modificar)
        ///Segun la Opcion usa un modulo para activar los tipos de Formulario
        /// </summary>
        /// <param name="cliente"></param>
        public void opcionesCliente(Cliente cliente, char op)
        {
            if (op == 'd')
            {
                detalleCliente(cliente);
                tituloForm.Content = "Detalle de Cliente"; //Cambia el titulo del Formulario
            }
            else if (op == 'm')
            {
                DniTextBox.IsReadOnly = true;
                tituloForm.Content = "Modificar Cliente";
                btnGuardar.Click += (sender, e) => Guardar_Actualizacion_Click();//Cambia la propiedad(Click) del boton guardar para redirigilo a otro metodo
                modificarCliente(cliente);
            }
            else //si no es modificar o dertalle, solo abre el formulario de alta
            {
                DniTextBox.IsReadOnly = false;
                tituloForm.Content = "Nuevo Cliente";
                btnGuardar.Click += (sender, e) => Agregar_Cliente_Click();//Cambia la propiedad(Click) del boton guardar para redirigilo a otro metodo
            }
        }


        private void Agregar_Cliente_Click()
        {
            Cliente nuevoCliente = CrearClienteDesdeEntrada();

            if (nuevoCliente != null)
            {
                // Muestra la información del cliente en un MessageBox
                MessageBox.Show(nuevoCliente.ToString(), "Información del Cliente");
                Cliente = nuevoCliente;
                // Establece DialogResult (si es necesario)
                DialogResult = true;
                MessageTextBlock.Text = String.Empty;

                if (TrabajarClientes.VerificarExistenciaDni(nuevoCliente.ClienteDni))
                {
                    MessageBox.Show("Ya Existe Cliente");

                }
                else
                {
                    TrabajarClientes.guardarCliente(nuevoCliente);

                    WinClienteABM win = new WinClienteABM();

                    win.ClientesDataGrid.ItemsSource = TrabajarClientes.TraerClientes().DefaultView;
                    win.Show();
                }

            }
            else
            {
                // Manejar errores de validación de entrada
                MessageTextBlock.Text = "Por favor, ingrese datos válidos para el cliente.";
            }
        }

        private Cliente CrearClienteDesdeEntrada()
        {
            int dni;
            if (Int32.TryParse(DniTextBox.Text, out dni) && !string.IsNullOrWhiteSpace(NombreTextBox.Text) && !string.IsNullOrWhiteSpace(ApellidoTextBox.Text) && !string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                return new Cliente(dni, NombreTextBox.Text, ApellidoTextBox.Text, TelefonoTextBox.Text);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Recive un tipo Cliente
        /// Asigna a los controles los atributos del cliente
        /// </summary>
        /// <param name="cliente"></param>
        private void detalleCliente(Cliente cliente)
        {
            // Mostrar los detalles del cliente en la ventana de detalles
            DniTextBox.Text = cliente.ClienteDni.ToString();
            NombreTextBox.Text = cliente.Nombre;
            ApellidoTextBox.Text = cliente.Apellido;
            TelefonoTextBox.Text = cliente.Telefono;

            // Deshabilitar la edición de campos de texto
            DniTextBox.IsEnabled = false;
            NombreTextBox.IsEnabled = false;
            ApellidoTextBox.IsEnabled = false;
            TelefonoTextBox.IsEnabled = false;
            //Desabilita los botones
            btnGuardar.Visibility = Visibility.Collapsed;
            btnCancelar.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Modifica el cliente
        ///  Asigna a los controles los atributos del cliente
        /// </summary>
        /// <param name="cliente"></param>
        private void modificarCliente(Cliente cliente)
        {
            // Inicializar los campos de entrada con los detalles del cliente
            clienteOriginal = cliente; // Almacenar el cliente original
            DniTextBox.Text = cliente.ClienteDni.ToString();
            NombreTextBox.Text = cliente.Nombre;
            ApellidoTextBox.Text = cliente.Apellido;
            TelefonoTextBox.Text = cliente.Telefono;
            // TODO: Validar datos
        }

        /// <summary>
        /// Guarda el cliente modificado
        /// </summary>
        private void Guardar_Actualizacion_Click()
        {
            Cliente nuevoCliente = CrearClienteDesdeEntrada();

            if (nuevoCliente != null)
            {
                // Muestra la información del cliente en un MessageBox
                MessageBox.Show(nuevoCliente.ToString(), "Información del Cliente");
                Cliente = nuevoCliente;
                // Establece DialogResult (si es necesario)
                DialogResult = true;
                MessageTextBlock.Text = String.Empty;

                TrabajarClientes.modificarCliente(nuevoCliente);

                WinClienteABM win = new WinClienteABM();

                win.ClientesDataGrid.ItemsSource = TrabajarClientes.TraerClientes().DefaultView;
                win.Show();


            }
            else
            {
                // Manejar errores de validación de entrada
                MessageTextBlock.Text = "Por favor, ingrese datos válidos para el cliente.";
            }
        }

        /// <summary>
        /// Cerrar El formulario
        /// </summary>
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        /// <summary>
        /// valida el ingreso del DNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DniTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = isDniTxt(e.Text);
        }

        private static readonly Regex dniRegex = new Regex("[0-9]");
        private static bool isDniTxt(string text)
        {
            return !dniRegex.IsMatch(text);
        }

        /// <summary>
        /// valida el ingreso del nombre y apellido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreYApellidoTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = esStringTxt(e.Text);
        }

        private static readonly Regex stringRegex = new Regex("[a-zA-Z]");
        private static bool esStringTxt(string text)
        {
            return !stringRegex.IsMatch(text);
        }
    }
}