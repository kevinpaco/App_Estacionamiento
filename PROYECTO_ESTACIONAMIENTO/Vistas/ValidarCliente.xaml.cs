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
    /// Interaction logic for ValidarCliente.xaml
    /// </summary>
    public partial class ValidarCliente : Window
    {
        Cliente cli = new Cliente();
        
        public ValidarCliente()
        {
            InitializeComponent();
            DniTextBox.Text = "23819281";
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
        private void DniTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DniTextBox.Text))
            {
                cli = TrabajarClientes.TraerCliente(Int32.Parse(DniTextBox.Text));
                if (cli != null)
                {
                    txtNombre.Text = cli.Nombre;
                    ApellidoTextBox.Text = cli.Apellido;
                    TelefonoTextBox.Text = cli.Telefono;

                }
                else
                {
                    txtNombre.Text = "";
                    ApellidoTextBox.Text = "";
                    TelefonoTextBox.Text = "";
                }
            }
               
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

    }
}
