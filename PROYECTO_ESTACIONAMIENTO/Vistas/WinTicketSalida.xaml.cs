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
    /// Interaction logic for WinTicketSalida.xaml
    /// </summary>
    public partial class WinTicketSalida : Window
    {
        public WinTicketSalida()
        {
            InitializeComponent();
        }

        public void cargarTicket(Ticket ticket)
        {
            lblticket.Content = "Tocket# " + ticket.TicketNro.ToString();
            lblnombre.Content = "CLiente: " + ticket.ClienteDni;
            lblpatente.Content = "Patente: " + ticket.Patente.ToString();
            lblingre.Content = "Ingreso: " + ticket.FechaHoraEnt.ToString();
            lblSalida.Content = "Salida: " + ticket.FechaHoraSal.ToString();

            TimeSpan fechaDiferencia = ticket.FechaHoraSal.Subtract(ticket.FechaHoraEnt);
            int horasduracion = fechaDiferencia.Days * 24 + fechaDiferencia.Hours;

            lbltranscurrido.Content = "Tiempo Transcurrido: " + horasduracion + ":" + fechaDiferencia.Minutes + ":" + fechaDiferencia.Seconds;
            lblhoras.Content = "Duracion: " + ticket.Duracion + " horas";

            lbltv.Content = "Tipo Vehiculo: " + ticket.TvCodigo;
            lbltarifa.Content = "Tarifa: " + ticket.Tarifa;
        }
    }
}
