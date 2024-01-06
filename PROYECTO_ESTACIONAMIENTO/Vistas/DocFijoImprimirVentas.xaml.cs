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
using System.Data;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for DocFijoImprimirVentas.xaml
    /// </summary>
    public partial class DocFijoImprimirVentas : Window
    {

        private DataGrid _ventasDataGrid;

        public DocFijoImprimirVentas(DataGrid ventasDataGrid)
        {
            InitializeComponent();
            _ventasDataGrid = ventasDataGrid;
            MostrarDatosTest();
            Loaded += DocFijoImprimirVentas_Loaded;
        }

        private void DocFijoImprimirVentas_Loaded(object sender, RoutedEventArgs e)
        {
            // TextBlock para el título
            TextBlock titleTextBlock = new TextBlock();
            titleTextBlock.Text = "Resumen de Ventas";
            titleTextBlock.FontSize = 20;
            titleTextBlock.TextAlignment = TextAlignment.Center;
            titleTextBlock.Margin = new Thickness(10, 10, 0, 0);

            // agregar el TextBlock del título al Fixeddocument
            FixedDocument newFixedDocument = new FixedDocument();
            newFixedDocument.Pages.Add(CreatePage(titleTextBlock));

            // TextBlock para mostrar la información de cada fila
            TextBlock infoTextBlock = new TextBlock();
            infoTextBlock.FontSize = 16;
            infoTextBlock.Margin = new Thickness(10, 50, 0, 0);

            // Agregar una pagina para mostrar toda la información
            newFixedDocument.Pages.Add(CreatePage(infoTextBlock));

            // Agregar la información de cada fila en el DataGrid al TextBlock
            foreach (var item in _ventasDataGrid.Items)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null)
                {
                    // Agregar información de la fila al TextBlock
                    infoTextBlock.Text += "Número de Ticket: " + rowView["tk_numero"] + ", Importe Total: " + Convert.ToDouble(rowView["tk_total"]).ToString("C") + ", Fecha y Hora de Venta: " + rowView["tk_fechaHoraEnt"] + "\n";
                }
            }

            // Asignar el nuevo FixedDocument al contenido
            Content = newFixedDocument;
        }

        private PageContent CreatePage(UIElement content)
        {
            // Crear una nueva página y agregar el contenido
            PageContent pc = new PageContent();
            FixedPage fp = new FixedPage();
            fp.Children.Add(content);
            pc.Child = fp;
            return pc;
        }

        private void MostrarDatosTest()
        {
            Console.WriteLine("Datos recibidos en DocFijoImprimirVentas:");

            foreach (var item in _ventasDataGrid.Items)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null)
                {
                    string numeroTicket = rowView["tk_numero"].ToString();
                    double importeTotal = Convert.ToDouble(rowView["tk_total"]);
                    string fechaHoraEntrada = rowView["tk_fechaHoraEnt"].ToString();

                    Console.WriteLine("Número de Ticket: " + numeroTicket + ", Importe Total: " + importeTotal.ToString("C"));
                    Console.WriteLine("Fecha y Hora de Venta: " + fechaHoraEntrada);
                    Console.WriteLine("-------------");
                }
            }
        }
    }
}
