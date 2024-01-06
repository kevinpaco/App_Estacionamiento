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
    /// Interaction logic for VehiculosEnPlaya.xaml
    /// </summary>
    public partial class VehiculosEnPlaya : Window
    {
        public VehiculosEnPlaya()
        {
            InitializeComponent();
        }

        private List<Sector> listZona1 = new List<Sector>();
        private List<Sector> listZona2 = new List<Sector>();
        private List<Sector> listZona3 = new List<Sector>();

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private Usuario user;
        public void TipoUser(Usuario user)
        {
            this.user = user;
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
            cargarZona1(123);
            cargarZona2(124);
            cargarZona3(125);
            //Asigna los eventas a cada boton de la Zona 1
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

            //Asigna los eventas a cada boton de la Zona 2
            button1Z2.MouseEnter += Sector_MouseEnterZona2;
            button2Z2.MouseEnter += Sector_MouseEnterZona2;
            button3Z2.MouseEnter += Sector_MouseEnterZona2;
            button4Z2.MouseEnter += Sector_MouseEnterZona2;
            button5Z2.MouseEnter += Sector_MouseEnterZona2;
            button6Z2.MouseEnter += Sector_MouseEnterZona2;
            button7Z2.MouseEnter += Sector_MouseEnterZona2;
            button8Z2.MouseEnter += Sector_MouseEnterZona2;
            button9Z2.MouseEnter += Sector_MouseEnterZona2;
            button10Z2.MouseEnter += Sector_MouseEnterZona2;

            //Asigna los eventas a cada boton de la Zona 3
            button1Z3.MouseEnter += Sector_MouseEnterZona3;
            button2Z3.MouseEnter += Sector_MouseEnterZona3;
            button3Z3.MouseEnter += Sector_MouseEnterZona3;
            button4Z3.MouseEnter += Sector_MouseEnterZona3;
            button5Z3.MouseEnter += Sector_MouseEnterZona3;
            button6Z3.MouseEnter += Sector_MouseEnterZona3;
            button7Z3.MouseEnter += Sector_MouseEnterZona3;
            button8Z3.MouseEnter += Sector_MouseEnterZona3;
            button9Z3.MouseEnter += Sector_MouseEnterZona3;
            button10Z3.MouseEnter += Sector_MouseEnterZona3;
        }

        private void cargarZona1(int zonacod)
        {
            listZona1 = SectorABM.TraerSectores(zonacod);
            button1.Background = asignarColor(listZona1[0]);
            button2.Background = asignarColor(listZona1[1]);
            button3.Background = asignarColor(listZona1[2]);
            button4.Background = asignarColor(listZona1[3]);
            button5.Background = asignarColor(listZona1[4]);
            button6.Background = asignarColor(listZona1[5]);
            button7.Background = asignarColor(listZona1[6]);
            button8.Background = asignarColor(listZona1[7]);
            button9.Background = asignarColor(listZona1[8]);
            button10.Background = asignarColor(listZona1[9]);
        }

        private void cargarZona2(int zonacod)
        {
            listZona2 = SectorABM.TraerSectores(zonacod);
            button1Z2.Background = asignarColor(listZona2[0]);
            button2Z2.Background = asignarColor(listZona2[1]);
            button3Z2.Background = asignarColor(listZona2[2]);
            button4Z2.Background = asignarColor(listZona2[3]);
            button5Z2.Background = asignarColor(listZona2[4]);
            button6Z2.Background = asignarColor(listZona2[5]);
            button7Z2.Background = asignarColor(listZona2[6]);
            button8Z2.Background = asignarColor(listZona2[7]);
            button9Z2.Background = asignarColor(listZona2[8]);
            button10Z2.Background = asignarColor(listZona2[9]);
        }

        private void cargarZona3(int zonacod)
        {
            listZona3 = SectorABM.TraerSectores(zonacod);
            button1Z3.Background = asignarColor(listZona3[0]);
            button2Z3.Background = asignarColor(listZona3[1]);
            button3Z3.Background = asignarColor(listZona3[2]);
            button4Z3.Background = asignarColor(listZona3[3]);
            button5Z3.Background = asignarColor(listZona3[4]);
            button6Z3.Background = asignarColor(listZona3[5]);
            button7Z3.Background = asignarColor(listZona3[6]);
            button8Z3.Background = asignarColor(listZona3[7]);
            button9Z3.Background = asignarColor(listZona3[8]);
            button10Z3.Background = asignarColor(listZona3[9]);
        }

        /// <summary>
        /// Asigna los colores de acuerdo al estado del estacionamiento
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        private Brush asignarColor(Sector sector)
        {
            if (sector.Habilitado == true)
            {
                if (sector.Estado == 0)
                    return Brushes.Green;
                else
                    return Brushes.Red;
            }
            else
                return Brushes.Gray;
        }

        private void Sector_MouseEnter(object sender, MouseEventArgs e)
        {
            string sec = sender.ToString().Substring(sender.ToString().Length - 5);
            string sec10 = sender.ToString().Substring(sender.ToString().Length - 6);

            if (sec.Equals("Est 1"))
            {
                asignarInformacionZona1(0);
            }
            else if (sec.Equals("Est 2"))
            {
                asignarInformacionZona1(1);
            }
            else if (sec.Equals("Est 3"))
            {
                asignarInformacionZona1(2);
            }
            else if (sec.Equals("Est 4"))
            {
                asignarInformacionZona1(3);
            }
            else if (sec.Equals("Est 5"))
            {
                asignarInformacionZona1(4);
            }
            else if (sec.Equals("Est 6"))
            {
                asignarInformacionZona1(5);
            }
            else if (sec.Equals("Est 7"))
            {
                asignarInformacionZona1(6);
            }
            else if (sec.Equals("Est 8"))
            {
                asignarInformacionZona1(7);
            }
            else if (sec.Equals("Est 9"))
            {
                asignarInformacionZona1(8);
            }
            else
            {
                asignarInformacionZona1(9);
            }

        }

        private void asignarInformacionZona1(int indice)
        {
            Ticket tk = TicketABM.BuscarTicket(listZona1[indice].SectorCodigo);
            //  MessageBox.Show("na: "+tk.SectorCodigo);
            if (listZona1[indice].Habilitado == true)
            {
                if (tk != null)
                {
                    TimeSpan tiempoDesocupado = DateTime.Now.Subtract(tk.FechaHoraSal);
                    TimeSpan tiempoOcupado = DateTime.Now.Subtract(tk.FechaHoraEnt);
                    if (listZona1[indice].Estado == 0)
                        txtZona1.Text = "Sector Libre \n desde: " + tiempoDesocupado.Days + " Dias " + " y " + tiempoDesocupado.Hours + " Horas";
                    else
                    {
                        TipoVehiculo tv = TipoVahiculoABM.buscarVehiculoPorCod(tk.TvCodigo);
                        decimal montoTotal = (tiempoOcupado.Days * 24 + tiempoOcupado.Hours) * tk.Tarifa;
                        txtZona1.Text = "Sector Ocupado \n Desde: " + tiempoOcupado.Days + " Dias " + " y " + tiempoOcupado.Hours + " Horas \n" + "Tipo Vehiculo: " + tv.Descripcion + "\n" + "Monto a Pagar: " + montoTotal;
                    }
                }
                else
                    txtZona1.Text = "Sector Aun Nunca Usado";

            }
            else
                txtZona1.Text = "Sector Desabilitado";
        }
        private void Sector_MouseEnterZona2(object sender, MouseEventArgs e)
        {
            string sec = sender.ToString().Substring(sender.ToString().Length - 5);
            string sec10 = sender.ToString().Substring(sender.ToString().Length - 6);

            if (sec.Equals("Est 1"))
            {
                asignarInformacionZona2(0);
            }
            else if (sec.Equals("Est 2"))
            {
                asignarInformacionZona2(1);
            }
            else if (sec.Equals("Est 3"))
            {
                asignarInformacionZona2(2);
            }
            else if (sec.Equals("Est 4"))
            {
                asignarInformacionZona2(3);
            }
            else if (sec.Equals("Est 5"))
            {
                asignarInformacionZona2(4);
            }
            else if (sec.Equals("Est 6"))
            {
                asignarInformacionZona2(5);
            }
            else if (sec.Equals("Est 7"))
            {
                asignarInformacionZona2(6);
            }
            else if (sec.Equals("Est 8"))
            {
                asignarInformacionZona2(7);
            }
            else if (sec.Equals("Est 9"))
            {
                asignarInformacionZona2(8);
            }
            else
            {
                asignarInformacionZona2(9);
            }

        }

        private void asignarInformacionZona2(int indice)
        {
            Ticket tk = TicketABM.BuscarTicket(listZona2[indice].SectorCodigo);
            //  MessageBox.Show("na: "+tk.SectorCodigo);
            if (listZona2[indice].Habilitado == true)
            {
                if (tk != null)
                {
                    TimeSpan tiempoDesocupado = DateTime.Now.Subtract(tk.FechaHoraSal);
                    TimeSpan tiempoOcupado = DateTime.Now.Subtract(tk.FechaHoraEnt);
                    if (listZona2[indice].Estado == 0)
                        txtZona2.Text = "Sector Libre \n desde: " + tiempoDesocupado.Days + " Dias " + " y " + tiempoDesocupado.Hours + " Horas";
                    else
                    {
                        TipoVehiculo tv = TipoVahiculoABM.buscarVehiculoPorCod(tk.TvCodigo);
                        decimal montoTotal = (tiempoOcupado.Days * 24 + tiempoOcupado.Hours) * tk.Tarifa;
                        txtZona2.Text = "Sector Ocupado \n Desde: " + tiempoOcupado.Days + " Dias " + " y " + tiempoOcupado.Hours + " Horas \n" + "Tipo Vehiculo: " + tv.Descripcion + "\n" + "Monto a Pagar: " + montoTotal;
                    }
                }
                else
                    txtZona2.Text = "Sector Aun Nunca Usado";

            }
            else
                txtZona2.Text = "Sector Desabilitado";
        }

        private void Sector_MouseEnterZona3(object sender, MouseEventArgs e)
        {
            string sec = sender.ToString().Substring(sender.ToString().Length - 5);
            string sec10 = sender.ToString().Substring(sender.ToString().Length - 6);

            if (sec.Equals("Est 1"))
            {
                asignarInformacionZona3(0);
            }
            else if (sec.Equals("Est 2"))
            {
                asignarInformacionZona3(1);
            }
            else if (sec.Equals("Est 3"))
            {
                asignarInformacionZona3(2);
            }
            else if (sec.Equals("Est 4"))
            {
                asignarInformacionZona3(3);
            }
            else if (sec.Equals("Est 5"))
            {
                asignarInformacionZona3(4);
            }
            else if (sec.Equals("Est 6"))
            {
                asignarInformacionZona3(5);
            }
            else if (sec.Equals("Est 7"))
            {
                asignarInformacionZona3(6);
            }
            else if (sec.Equals("Est 8"))
            {
                asignarInformacionZona3(7);
            }
            else if (sec.Equals("Est 9"))
            {
                asignarInformacionZona3(8);
            }
            else
            {
                asignarInformacionZona3(9);
            }

        }

        private void asignarInformacionZona3(int indice)
        {
            Ticket tk = TicketABM.BuscarTicket(listZona3[indice].SectorCodigo);
            //  MessageBox.Show("na: "+tk.SectorCodigo);
            if (listZona3[indice].Habilitado == true)
            {
                if (tk != null)
                {
                    TimeSpan tiempoDesocupado = DateTime.Now.Subtract(tk.FechaHoraSal);
                    TimeSpan tiempoOcupado = DateTime.Now.Subtract(tk.FechaHoraEnt);
                    if (listZona3[indice].Estado == 0)
                        txtZona3.Text = "Sector Libre \n desde: " + tiempoDesocupado.Days + " Dias " + " y " + tiempoDesocupado.Hours + " Horas";
                    else
                    {
                        TipoVehiculo tv = TipoVahiculoABM.buscarVehiculoPorCod(tk.TvCodigo);
                        decimal montoTotal = (tiempoOcupado.Days * 24 + tiempoOcupado.Hours) * tk.Tarifa;
                        txtZona3.Text = "Sector Ocupado \n Desde: " + tiempoOcupado.Days + " Dias " + " y " + tiempoOcupado.Hours + " Horas \n" + "Tipo Vehiculo: " + tv.Descripcion + "\n" + "Monto a Pagar: " + montoTotal;
                    }
                }
                else
                    txtZona3.Text = "Sector Aun Nunca Usado";

            }
            else
                txtZona3.Text = "Sector Desabilitado";
        }
        private void button7_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSector_Click(object sender, RoutedEventArgs e)
        {
            string sec = sender.ToString().Substring(sender.ToString().Length - 5);
            string sec10 = sender.ToString().Substring(sender.ToString().Length - 6);

            if (sec.Equals("Est 1"))
            {
                cargarRegistroSalida(0);
            }
            else if (sec.Equals("Est 2"))
            {
                cargarRegistroSalida(1);
            }
            else if (sec.Equals("Est 3"))
            {
                cargarRegistroSalida(2);
            }
            else if (sec.Equals("Est 4"))
            {
                cargarRegistroSalida(3);
            }
            else if (sec.Equals("Est 5"))
            {
                cargarRegistroSalida(4);
            }
            else if (sec.Equals("Est 6"))
            {
                cargarRegistroSalida(5);
            }
            else if (sec.Equals("Est 7"))
            {
                cargarRegistroSalida(6);
            }
            else if (sec.Equals("Est 8"))
            {
                cargarRegistroSalida(7);
            }
            else if (sec.Equals("Est 9"))
            {
                cargarRegistroSalida(8);
            }
            else
            {
                cargarRegistroSalida(9);
            }
        }

        private void cargarRegistroSalida(int indice)
        {
            Ticket tk = TicketABM.BuscarTicket(listZona1[indice].SectorCodigo);
            WinRegistrarSalida rs = new WinRegistrarSalida();
            rs.cargarInformacion(tk, listZona1[indice]);
            rs.ShowDialog();
            if (rs.DialogResult == true)
            {
                this.Close();
                VehiculosEnPlaya vp = new VehiculosEnPlaya();
                vp.TipoUser(user);
                vp.Show();
            }
        }
        

         private void buttonSector2_Click(object sender, RoutedEventArgs e)
           {
            string sec = sender.ToString().Substring(sender.ToString().Length - 5);
            string sec10 = sender.ToString().Substring(sender.ToString().Length - 6);

            if (sec.Equals("Est 1"))
            {
                cargarRegistroSalida2(0);
            }
            else if (sec.Equals("Est 2"))
            {
                cargarRegistroSalida2(1);
            }
            else if (sec.Equals("Est 3"))
            {
                cargarRegistroSalida2(2);
            }
            else if (sec.Equals("Est 4"))
            {
                cargarRegistroSalida2(3);
            }
            else if (sec.Equals("Est 5"))
            {
                cargarRegistroSalida2(4);
            }
            else if (sec.Equals("Est 6"))
            {
                cargarRegistroSalida2(5);
            }
            else if (sec.Equals("Est 7"))
            {
                cargarRegistroSalida2(6);
            }
            else if (sec.Equals("Est 8"))
            {
                cargarRegistroSalida2(7);
            }
            else if (sec.Equals("Est 9"))
            {
                cargarRegistroSalida2(8);
            }
            else
            {
                cargarRegistroSalida2(9);
            }
        }

        private void cargarRegistroSalida2(int indice)
        {
            Ticket tk = TicketABM.BuscarTicket(listZona2[indice].SectorCodigo);
            WinRegistrarSalida rs = new WinRegistrarSalida();
            rs.cargarInformacion(tk, listZona2[indice]);
            rs.ShowDialog();
            if (rs.DialogResult == true)
            {
                this.Close();
                VehiculosEnPlaya vp = new VehiculosEnPlaya();
                vp.TipoUser(user);
                vp.Show();
            }
        }

        private void buttonSector3_Click(object sender, RoutedEventArgs e)
        {
            string sec = sender.ToString().Substring(sender.ToString().Length - 5);
            string sec10 = sender.ToString().Substring(sender.ToString().Length - 6);

            if (sec.Equals("Est 1"))
            {
                cargarRegistroSalida3(0);
            }
            else if (sec.Equals("Est 2"))
            {
                cargarRegistroSalida3(1);
            }
            else if (sec.Equals("Est 3"))
            {
                cargarRegistroSalida3(2);
            }
            else if (sec.Equals("Est 4"))
            {
                cargarRegistroSalida3(3);
            }
            else if (sec.Equals("Est 5"))
            {
                cargarRegistroSalida3(4);
            }
            else if (sec.Equals("Est 6"))
            {
                cargarRegistroSalida3(5);
            }
            else if (sec.Equals("Est 7"))
            {
                cargarRegistroSalida3(6);
            }
            else if (sec.Equals("Est 8"))
            {
                cargarRegistroSalida3(7);
            }
            else if (sec.Equals("Est 9"))
            {
                cargarRegistroSalida3(8);
            }
            else
            {
                cargarRegistroSalida3(9);
            }
        }

        private void cargarRegistroSalida3(int indice)
        {
            Ticket tk = TicketABM.BuscarTicket(listZona3[indice].SectorCodigo);
            WinRegistrarSalida rs = new WinRegistrarSalida();
            rs.cargarInformacion(tk, listZona3[indice]);
            rs.ShowDialog();
            if (rs.DialogResult == true)
            {
                this.Close();
                VehiculosEnPlaya vp = new VehiculosEnPlaya();
                vp.TipoUser(user);
                vp.Show();
            }
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

        private void btnAgregarTicket_Click(object sender, RoutedEventArgs e)
        {
            WinRegistrarEntrada re = new WinRegistrarEntrada();
            re.ShowDialog();
            if (re.DialogResult == true)
            {
                this.Close();
                VehiculosEnPlaya vp = new VehiculosEnPlaya();
                vp.TipoUser(user);
                vp.Show();
            }
        }
        /* Ticket tk = TicketABM.BuscarTicket(listZona1[5].SectorCodigo);
                TipoVehiculo tv = TipoVahiculoABM.buscarVahiculoPorCod(tk.TvCodigo);
                TimeSpan tiempoDesocupado = DateTime.Now.Subtract(tk.FechaHoraSal);
                TimeSpan tiempoOcupado = DateTime.Now.Subtract(tk.FechaHoraEnt);
                decimal montoTotal = (tiempoOcupado.Days * 24 + tiempoOcupado.Hours)*tk.Tarifa;
                if (listZona1[5].Habilitado == true)
                {
                    if (listZona1[5].Estado == 0)
                        txtZona1.Text = "Sector Libre \n desde: " + tiempoDesocupado.Days + " Dias " + " y " + tiempoDesocupado.Hours + " Horas";
                    else
                        txtZona1.Text = "Sector Ocupado \n Desde: " + tiempoOcupado.Days + " Dias " + " y " + tiempoOcupado.Hours + " Horas \n"+ "Tipo Vehiculo: "+tv.Descripcion+"\n"+"Monto a Pagar: "+montoTotal ;
                }
                else
                    txtZona1.Text = "Sector Desabilitado";*/
    }
}
