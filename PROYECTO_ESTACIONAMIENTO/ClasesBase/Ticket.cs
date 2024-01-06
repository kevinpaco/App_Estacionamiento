using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        private int tk_id;
        public int Tk_id
        {
            get { return tk_id; }
            set { tk_id = value; }
        }
        private int ticketNro;

        public int TicketNro
        {
            get { return ticketNro; }
            set { ticketNro = value; }
        }
        private DateTime fechaHoraEnt;

        public DateTime FechaHoraEnt
        {
            get { return fechaHoraEnt; }
            set { fechaHoraEnt = value; }
        }
        private DateTime fechaHoraSal;

        public DateTime FechaHoraSal
        {
            get { return fechaHoraSal; }
            set { fechaHoraSal = value; }
        }
        private int clienteDni;

        public int ClienteDni
        {
            get { return clienteDni; }
            set { clienteDni = value; }
        }
        private int tvCodigo;

        public int TvCodigo
        {
            get { return tvCodigo; }
            set { tvCodigo = value; }
        }
        private String patente;

        public String Patente
        {
            get { return patente; }
            set { patente = value; }
        }
        private int sectorCodigo;

        public int SectorCodigo
        {
            get { return sectorCodigo; }
            set { sectorCodigo = value; }
        }
        private decimal duracion;

        public decimal Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }
        private decimal tarifa;

        public decimal Tarifa
        {
            get { return tarifa; }
            set { tarifa = value; }
        }
        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public String toStrig()
        {
            return "entrada: " + FechaHoraEnt + " sal: " + FechaHoraSal + " cli: " + ClienteDni;
        }
    }
}
