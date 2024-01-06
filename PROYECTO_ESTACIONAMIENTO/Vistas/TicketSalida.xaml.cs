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
    /// Interaction logic for RegistrarSalida.xaml
    /// </summary>
    public partial class TicketSalida : Window
    {
        public TicketSalida()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        public void cargarTicket(Ticket ticket)
        {
            Cliente cliente = TrabajarClientes.TraerCliente(ticket.ClienteDni);

            txbNumTicket.Text = "Ticket# " + ticket.TicketNro.ToString();
            txbCliente.Text = "Cliente: " + cliente.Apellido + " " + cliente.Nombre;
            txbPatente.Text = "Patente: " + ticket.Patente.ToString();
            txbIngreso.Text = "Ingreso: " + ticket.FechaHoraEnt.ToString();
            txbSalida.Text = "Salida: " + ticket.FechaHoraSal.ToString();
            txbHoras.Text = "Horas contabilizadas: " + (int)ticket.Duracion;
            txbDuracion.Text = "Duracion: " + (ticket.FechaHoraSal - ticket.FechaHoraEnt).ToString();
            txbTipoVehiculo.Text = "Tipo Vehiculo: " + ticket.TvCodigo;
            txbTarifa.Text = "Tarifa: " + ticket.Tarifa;
            txbImporte.Text = "Total: " +ticket.Total;
        }
    }
}
