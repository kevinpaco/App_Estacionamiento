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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinAcercaDe.xaml
    /// </summary>
    public partial class WinAcercaDe : Window
    {
        public WinAcercaDe()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<Integrante> integrantes = new List<Integrante>
            {
                new Integrante { NombreApellido = "Marcos Elias Condori", DNI = "123", LU = "123" },
                new Integrante { NombreApellido = "Joaquin Facundo Elias Corimayo Mollo", DNI = "40154287", LU = "4564" },
                new Integrante { NombreApellido = "marcelo jurado", DNI = "123", LU = "123" },
                new Integrante { NombreApellido = "Kevin horacio Paco", DNI = "123", LU = "123" },
                new Integrante { NombreApellido = "Elías Ezequiel Solis", DNI = "123", LU = "123" },
            };

            integrantesDataGrid.ItemsSource = integrantes;

            string rutaVideo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos", "video1.mp4");

            videoPlayer.Source = new Uri(rutaVideo, UriKind.RelativeOrAbsolute);
            videoPlayer.Play();
        }
    }

    public class Integrante
    {
        public string NombreApellido { get; set; }
        public string DNI { get; set; }
        public string LU { get; set; }
    }
}
