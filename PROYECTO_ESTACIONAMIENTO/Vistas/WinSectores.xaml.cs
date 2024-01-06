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
    /// Interaction logic for WinSectores.xaml
    /// </summary>
    public partial class WinSectores : Window
    {
        private DateTime referenciaInicio = DateTime.Now;
        private Usuario user;

        public WinSectores()
        {
            InitializeComponent();
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
            VentanaPrincipal vp = new VentanaPrincipal();
            vp.cargarUser(user);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            button1.Background = Brushes.Green;
            button2.Background = Brushes.Green;
            button3.Background = Brushes.Green;
            button4.Background = Brushes.Green;
            button5.Background = Brushes.Gray;
            button6.Background = Brushes.Green;
            button7.Background = Brushes.Red;
            button8.Background = Brushes.Green;
            button9.Background = Brushes.Green;
            button10.Background = Brushes.Green;

            // Agrega el evento MouseEnter a cada botón
            button1.MouseEnter += Sector_MouseEnter;
            button2.MouseEnter += Sector_MouseEnter;
            button3.MouseEnter += Sector_MouseEnter;
            button4.MouseEnter += Sector_MouseEnter;
            button5.MouseEnter += Sector_MouseEnter;
            button6.MouseEnter += Sector_MouseEnter;
            button7.MouseEnter += Sector_MouseEnter;
            button8.MouseEnter += Sector_MouseEnter;
            button9.MouseEnter += Sector_MouseEnter;
            button10.MouseEnter += Sector_MouseEnter;
        }

        private void HandleButtonClick(Button button)
        {
            if (button.Background == Brushes.Red)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida");
            }
            else if (button.Background == Brushes.Green)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada");
            }
            else
            {
                MessageBox.Show("Sector deshabilitado");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button5);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button6);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button7);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button8);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button9);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(button10);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal vp = new VentanaPrincipal();
            vp.cargarUser(user);
            this.Close();
        }

        private void btnEstado_Sector_Click(object sender, RoutedEventArgs e)
        {
            EstadoSector es = new EstadoSector();
            es.ShowDialog();
        }

        public void TipoUser(Usuario user)
        {
            this.user = user;
        }

        private void Sector_MouseEnter(object sender, MouseEventArgs e)
        {
            Button sector = sender as Button;
            Console.WriteLine("Info sector: " + sector);
            if (sector != null)
            {
                if (sector.Background == Brushes.Green)
                {
                    // El sector esta libre (muestra información sobre tiempo libre)
                    DateTime tiempoInicio = ObtenerTiempoInicio(sector.Name);
                    TimeSpan tiempoTranscurrido = DateTime.Now - tiempoInicio;
                    string informacion = string.Format("Sector libre desde {0}.\nTiempo transcurrido: {1}",
                tiempoInicio.ToString("dd/MM/yyyy HH:mm:ss"),
                FormatearTiempoTranscurrido(tiempoTranscurrido));

                    // Muestra la información en el TextBlock
                    infoTextBlock.Text = informacion;
                    infoTextBlock.Visibility = Visibility.Visible;
                }
                else if (sector.Background == Brushes.Red)
                {
                    // El sector esta ocupado (muestra información sobre el tiempo ocupado, tipo de vehículo, monto, etc.)
                    string informacionOcupado = ObtenerInformacionOcupado(sector.Name);

                    // Muestra la información en el TextBlock
                    infoTextBlock.Text = informacionOcupado;
                    infoTextBlock.Visibility = Visibility.Visible;
                }
                else if (sector.Background == Brushes.Gray)
                {
                    // El sector está deshabilitado (muestra sector no disponible)
                    infoTextBlock.Text = "Sector no disponible";
                    infoTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        // Función para obtener informacion del sector ocupado
        private string ObtenerInformacionOcupado(string nombreSector)
        {
            return "Información del sector ocupado";
        }

        // Función para obtener la fecha y hora de inicio del sector
        private DateTime ObtenerTiempoInicio(string nombreSector)
        {
            // Establecer la fecha y hora predeterminada (por ejemplo, 1 de enero de 2023 a las 00:00:00)
            return new DateTime(2023, 1, 1, 0, 0, 0);
        }

        // Función para formatear la fecha y que sea mas legible para el usuario
        private string FormatearTiempoTranscurrido(TimeSpan tiempo)
        {
            // Formatear la cadena de tiempo transcurrido
            return string.Format("{0} días, {1} horas, {2} min, {3} seg",
                tiempo.Days, tiempo.Hours, tiempo.Minutes, tiempo.Seconds);
        }

    }
}
