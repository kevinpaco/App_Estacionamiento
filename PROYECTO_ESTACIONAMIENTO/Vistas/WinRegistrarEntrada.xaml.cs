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
    /// Interaction logic for WinRegistrarEntrada.xaml
    /// </summary>
    public partial class WinRegistrarEntrada : Window
    {
        TipoVehiculo buscartv = new TipoVehiculo();
        private Sector buscarSec = new Sector();
        private Zona buscarZon = new Zona();
        private List<TipoVehiculo> listTv;
        private List<Sector> listSec;
        private List<Zona> listZonas;
        private List<Sector> ListCombo = new List<Sector>();
        public WinRegistrarEntrada()
        {
            InitializeComponent();
            // Llenar ComboBox de horas
            for (int i = 0; i < 24; i++)
            {
                cmbHora.Items.Add(i.ToString("00"));
            }

            // Llenar ComboBox de minutos
            for (int i = 0; i < 60; i += 5)
            {
                cmbMinutos.Items.Add(i.ToString("00"));
            }

            //llenar combox de Zona
            listZonas = ZonaABM.TraerZonas();
            cmbZona.ItemsSource = listZonas;
            cmbZona.DisplayMemberPath = "Descripcion";

            listTv = TipoVahiculoABM.TraerTiposVehiculo();
            //  MessageBox.Show("lis: "+listTv[0].Descripcion);
            cmbTipoVehiculo.ItemsSource = listTv;
            cmbTipoVehiculo.DisplayMemberPath = "Descripcion";


        }

        private void GuardarEntrada_Click(object sender, RoutedEventArgs e)
        {
            int dniCliente;
            //MessageBox.Show("naa: "+buscarSec.Descripcion);

            if (string.IsNullOrWhiteSpace(txtDniCliente.Text))
            {
                MessageBox.Show("Ingrese el DNI del cliente.");
                return;
            }else  if (string.IsNullOrWhiteSpace(txtPatente.Text))
            {
                MessageBox.Show("Ingrese la patente del vehículo.");
                return;
            }else if (!int.TryParse(txtDniCliente.Text, out dniCliente))
            {
                MessageBox.Show("El DNI del cliente debe ser un número válido.");
                return;
            }else if (dniCliente <= 0)
            {
                MessageBox.Show("El DNI del cliente debe ser un número positivo.");
                return;
            }
            else if (cmbHora.SelectedIndex == -1 || cmbMinutos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar la Fecha y Hora ");
            }
            else if(cmbSector.SelectedIndex==-1 ||cmbZona.SelectedIndex==-1){
                MessageBox.Show("Debe ingresar la zona y el sector");
            }else
            {
                Cliente cliente = TrabajarClientes.TraerCliente(dniCliente);
                if (cliente != null)
                {
                    Ticket ticket = new Ticket();
                    ticket.ClienteDni = cliente.ClienteDni;
                    ticket.Patente = txtPatente.Text;
                    //  ticket.TvCodigo = ObtenerCodigoTipoVehiculo();
                    // ticket.SectorCodigo =  ObtenerCodigoSector();
                    DateTime fechaIngreso = (DateTime)datePickerFecha.SelectedDate;
                    int horaIngreso = int.Parse(cmbHora.SelectedItem.ToString());
                    int minutosIngreso = int.Parse(cmbMinutos.SelectedItem.ToString());
                    ticket.FechaHoraEnt = new DateTime(fechaIngreso.Year, fechaIngreso.Month, fechaIngreso.Day, horaIngreso, minutosIngreso, 0);
                    ticket.FechaHoraSal = ticket.FechaHoraEnt;
                    ticket.TvCodigo = buscartv.TvCodigo;//CODIGO DEL TIPO VEHICULO
                    //MessageBox.Show("es: "+ticket.FechaHoraEnt);
                    ticket.SectorCodigo = buscarSec.SectorCodigo;
                    ticket.TicketNro = TicketABM.TraerUltimoNumTicker() + 1;
                    ticket.Tarifa = decimal.Parse(txtTarifa.Text);
                    TicketABM.guardarTicket(ticket);
                    WinTicketIngreso ti = new WinTicketIngreso();
                    buscarSec.Estado = 1;
                    SectorABM.modificarSector(buscarSec);
                    //MessageBox.Show("es: " + buscarSec.Sec_id);
                    ti.cargarTicket(ticket);
                    ti.Show();
                }
                else
                {
                    MessageBox.Show("El cliente con DNI " + dniCliente + " no está registrado.");
                }
                this.DialogResult = true;
                this.Close();
            }
        }

        private void cmbTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int posicion = cmbTipoVehiculo.SelectedIndex;
            string des = listTv[posicion].Descripcion;
            buscartv = TipoVahiculoABM.buscarVehiculo(des);
            txtTarifa.Text = buscartv.Tarifa.ToString();
            // MessageBox.Show("tari: "+buscartv.Tarifa);

        }

        private void cmbTipoSector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSector.SelectedIndex != -1)
            {
                int posicion = cmbSector.SelectedIndex;
                int cod = ListCombo[posicion].SectorCodigo;
                buscarSec = SectorABM.buscarSector(cod);
               // MessageBox.Show("sec: " + buscarSec.SectorCodigo);
            }
        }

        private void cmbZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int posicion = cmbZona.SelectedIndex;
            int cod = listZonas[posicion].ZonaCodigo;
            buscarZon = ZonaABM.buscarZona(cod);
            ListCombo = new List<Sector>();
            // llenar combox de sectores
            listSec = SectorABM.TraerSectores(buscarZon.ZonaCodigo);
            for (int i = 0; i <= listSec.Count - 1; i++)
            {
                if (listSec[i].Estado == 0 && listSec[i].Habilitado == true)
                    ListCombo.Add(listSec[i]);
            }

            cmbSector.ItemsSource = ListCombo;
            cmbSector.DisplayMemberPath = "Descripcion";
            //  MessageBox.Show("cod: "+buscarZon.Descripcion);
        }


       
    }
}
