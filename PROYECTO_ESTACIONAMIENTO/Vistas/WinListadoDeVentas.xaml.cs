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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinListadoDeVentas.xaml
    /// </summary>
    public partial class WinListadoDeVentas : Window
    {

        public WinListadoDeVentas()
        {
            InitializeComponent();
            CargarDatos();
        }

        // Cargara todas las ventas, y cargara el total de ventas
        private void CargarDatos()
        {
            TrabajarTicket tickets = new TrabajarTicket();
            dgVentas.ItemsSource = tickets.TraerVentas().DefaultView;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = 0;

            foreach (var item in dgVentas.Items)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null)
                {
                    Console.WriteLine("El objeto es DataRowView: " + item.GetType().FullName);
                    DataRow row = rowView.Row;
                    if (row != null && row.Table.Columns.Contains("tk_total"))
                    {
                        object tkTotalObj = row["tk_total"];
                        if (tkTotalObj != DBNull.Value && tkTotalObj is IConvertible)
                        {
                            double tkTotal = Convert.ToDouble(tkTotalObj);
                            total += tkTotal;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El objeto no es DataRowView: " + item.GetType().FullName);
                }
            }

            Console.WriteLine("Total: " + total);

            lblTotal.Content = total.ToString("C2");
        }

        private void AplicarFiltro_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si las fechas seleccionadas tienen un valor
            if (dpFechaInicio.SelectedDate.HasValue && dpFechaFin.SelectedDate.HasValue)
            {
                // fechas seleccionadas en los DatePicker
                DateTime fechaInicio = dpFechaInicio.SelectedDate.Value;
                DateTime fechaFin = dpFechaFin.SelectedDate.Value;

                // datos de las ventas según el rango de fechas
                TrabajarTicket tickets = new TrabajarTicket();
                DataTable ventasFiltradas = tickets.TraerVentasPorFecha(fechaInicio, fechaFin);

                // Actualiza la lista de ventas en el DataGrid
                dgVentas.ItemsSource = ventasFiltradas.DefaultView;

                // Calcula y muestra el nuevo total
                CalcularTotal();
            }
            else
            {
                // Manejar el caso en el que una o ambas fechas son nulas
                MessageBox.Show("Por favor, seleccione ambas fechas antes de aplicar el filtro.");
            }
        }

        private void BorrarFiltros_Click(object sender, RoutedEventArgs e)
        {
            // Reinicia los DatePicker
            dpFechaInicio.SelectedDate = null;
            dpFechaFin.SelectedDate = null;

            // Obtén todos los datos de ventas sin filtro
            TrabajarTicket tickets = new TrabajarTicket();
            DataTable todasLasVentas = tickets.TraerVentas();

            // Actualiza la lista de ventas en el DataGrid
            dgVentas.ItemsSource = todasLasVentas.DefaultView;

            // Calcula y muestra el nuevo total
            CalcularTotal();
        }


        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
          DocFijoImprimirVentas ventanaImpresion = new DocFijoImprimirVentas(dgVentas);
          ventanaImpresion.ShowDialog();
        }

    }
}
