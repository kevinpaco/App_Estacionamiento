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
    /// Interaction logic for WinTicketIngreso.xaml
    /// </summary>
    public partial class WinTicketIngreso : Window
    {
        public WinTicketIngreso()
        {
            InitializeComponent();
        }

        public void cargarTicket(Ticket ticket)
        {
            Cliente cliente =  TrabajarClientes.TraerCliente(ticket.ClienteDni);
            TipoVehiculo tv = TipoVahiculoABM.buscarVehiculoPorCod(ticket.TvCodigo);

            lblticket.Content = "Ticket# " + ticket.TicketNro.ToString();
            lblnombre.Content = "Cliente: "+cliente.Apellido + " " + cliente.Nombre;
            lblpatente.Content = "Patente: " + ticket.Patente.ToString();
            lblingre.Content = "Ingreso: " + ticket.FechaHoraEnt.ToString();
            lbltv.Content = "Tipo Vehiculo: " + tv.Descripcion;
            lbltarifa.Content = "Tarifa: " + ticket.Tarifa;
        }
    }
}
