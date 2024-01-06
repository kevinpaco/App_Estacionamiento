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
    /// Interaction logic for WinRegistrarSalida.xaml
    /// </summary>
    public partial class WinRegistrarSalida : Window
    {
         Ticket tk = new Ticket();
        TipoVehiculo tv = new TipoVehiculo();
        private Sector sector1= new Sector();
        private bool secHabilitado;
        private int secEstado;
        public WinRegistrarSalida()
        {
            InitializeComponent();
        }

        public void cargarInformacion(Ticket ticket,Sector sector)
        {
            //MessageBox.Show("es: "+ticket.SectorCodigo);
            sector1 = sector;
            secHabilitado = sector.Habilitado;
            secEstado = sector.Estado;
            if (sector.Habilitado == true && sector.Estado == 1)
            {
               
                hab.Visibility = Visibility.Collapsed;
                des.Visibility = Visibility.Collapsed;
                datePickerFecha.SelectedDate = DateTime.Today;

                tk = TicketABM.BuscarTicket(ticket.SectorCodigo);//(ticket.SectorCodigo);           
                
                txthoras.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                TimeSpan fechaDiferencia = DateTime.Now.Subtract(tk.FechaHoraEnt);
                int horasduracion = fechaDiferencia.Days * 24 + fechaDiferencia.Hours;
                tk.Duracion = horasduracion;
                txtduracion.Text = horasduracion + " Horas, " + fechaDiferencia.Minutes + " minutos";
                tv = TipoVahiculoABM.buscarVehiculoPorCod(tk.TvCodigo);
                tk.FechaHoraSal = DateTime.Now;
                tk.Total = horasduracion * tv.Tarifa;
                txtpag.Text = "$ " + tk.Total;
            }
            else if (sector.Habilitado == false)
            {

                formSalida.Visibility = Visibility.Collapsed;
                hab.Visibility = Visibility.Collapsed;

            }else if(sector.Estado == 0 ){
                formSalida.Visibility = Visibility.Collapsed;
                des.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sal: "+tk.FechaHoraSal);
            TicketABM.modificarTicket(tk);

            sector1.Estado = 0;
            SectorABM.modificarSector(sector1);
            MessageBox.Show("Salida Registrada");
            this.DialogResult = true;
            this.Close();
            WinTicketSalida ts = new WinTicketSalida();
            ts.cargarTicket(tk);
            ts.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (secHabilitado == true)
            {
                MessageBox.Show("El sector se encuentra Habiliado");          
            }
            else
            {
                sector1.Habilitado = true;
                SectorABM.habilitarSector(sector1);
                MessageBox.Show("Sector a sido habilitado con exito");
                this.DialogResult = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (secEstado == 1)
            {
                MessageBox.Show("El sector se encuentra ocupado, desocupe y luego deshabilite");
            }
            else if (secHabilitado == false)
            {
                MessageBox.Show("El Sector Ya se encuentra deshabilitado");
            }
            else
            {
                sector1.Habilitado = false;
                SectorABM.deshabilitarSector(sector1);
                MessageBox.Show("Sector a sido deshabilitado con exito");
                this.DialogResult = true;
                this.Close();
            }
        }

      /*  private void GuardarSalida_Click(object sender, RoutedEventArgs e)
        {
            TrabajarTicket ticketABM = new TrabajarTicket();
            Ticket ticket = ticketABM.TraerTicket(txtNumTicket.Text);
            if (ticket != null)
            {
                DateTime fechaSalida = (DateTime)datePickerFecha.SelectedDate;
                int horaSalida = int.Parse(cmbHora.SelectedItem.ToString());
                int minutosSalida = int.Parse(cmbMinutos.SelectedItem.ToString());
                ticket.FechaHoraSal = new DateTime(fechaSalida.Year, fechaSalida.Month, fechaSalida.Day, horaSalida, minutosSalida, 0);
                TimeSpan diferencia = ticket.FechaHoraSal - ticket.FechaHoraEnt;
                ticket.Duracion = (decimal)(diferencia.TotalHours);
                ticket.Total = ((int)ticket.Duracion + 1) * ticket.Tarifa;

                buscarSec = SectorABM.buscarSector(ticket.SectorCodigo);
                buscarSec.Estado = 0;
                SectorABM.modificarSector(buscarSec);

                TrabajarTicket.modificarTicket(ticket);
                TicketSalida ti = new TicketSalida();
                ti.cargarTicket(ticket);
                ti.Show();
            }
            else {
                MessageBox.Show("El numero de ticket no existe.");
            }
        }*/

    }
}
