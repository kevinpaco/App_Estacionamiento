using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TicketABM
    {
        public static void guardarTicket(Ticket ticket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Ticket(tk_numero,tk_fechaHoraEnt,tk_fechaHoraSal,cli_dni,tv_codigo,tk_patente,sec_codigo,tk_duracion,tk_tarifa,tk_total) values(@num,@horaEnt,@horaSal,@cli_dni,@tv_cod,@tk_pat,@sec_cod,@tk_dur,@tk_tar,@tk_total) ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@num", ticket.TicketNro);
            cmd.Parameters.AddWithValue("@horaEnt", ticket.FechaHoraEnt);
            cmd.Parameters.AddWithValue("@horaSal", ticket.FechaHoraSal);
            cmd.Parameters.AddWithValue("@cli_dni", ticket.ClienteDni);
            cmd.Parameters.AddWithValue("@tv_cod", ticket.TvCodigo);
            cmd.Parameters.AddWithValue("@tk_pat", ticket.Patente);
            cmd.Parameters.AddWithValue("@sec_cod", ticket.SectorCodigo);
            cmd.Parameters.AddWithValue("@tk_dur", ticket.Duracion);
            cmd.Parameters.AddWithValue("@tk_tar", ticket.Tarifa);
            cmd.Parameters.AddWithValue("@tk_total", ticket.Total);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static int TraerUltimoNumTicker()
        {
            int ultimoNumero = 0;

            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT MAX(tk_numero) AS Numero FROM Ticket";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ultimoNumero = reader.GetInt32(0);
                    }
                }

                cn.Close();
            }

            return ultimoNumero;
        }

        public static Ticket BuscarTicket(int codigoSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket WHERE sec_codigo=@cod";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cod", codigoSector);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Ticket tk = new Ticket();
                tk.Tk_id = int.Parse(dr["tk_id"].ToString());
                tk.FechaHoraEnt = DateTime.Parse(dr["tk_fechaHoraEnt"].ToString());
                tk.FechaHoraSal = DateTime.Parse(dr["tk_fechaHoraSal"].ToString());
                tk.ClienteDni = int.Parse(dr["cli_dni"].ToString());
                tk.TvCodigo = int.Parse(dr["tv_codigo"].ToString());
                tk.Patente = dr["tk_patente"].ToString();
                tk.SectorCodigo = int.Parse(dr["sec_codigo"].ToString());
                tk.Duracion = decimal.Parse(dr["tk_duracion"].ToString());
                tk.Tarifa = decimal.Parse(dr["tk_tarifa"].ToString());
                tk.Total = decimal.Parse(dr["tk_total"].ToString());
                cnn.Close();
                return tk;
            }
            else
            {
                cnn.Close();
                return null;
            }
        }

        public static void modificarTicket(Ticket ticket)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Ticket SET tk_fechaHoraEnt=@fhE,tk_fechaHoraSal=@fhS,cli_dni=@cliDni,tv_codigo=@tvCod,tk_patente=@pat,sec_codigo=@secCod,tk_duracion=@dur,tk_tarifa=@tar,tk_total=@total  WHERE (tk_numero=@id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@id", ticket.Tk_id);
                    cmd.Parameters.AddWithValue("@fhE", ticket.FechaHoraEnt);
                    cmd.Parameters.AddWithValue("@fhS", ticket.FechaHoraSal);
                    cmd.Parameters.AddWithValue("@cliDni", ticket.ClienteDni);
                    cmd.Parameters.AddWithValue("@tvCod", ticket.TvCodigo);
                    cmd.Parameters.AddWithValue("@pat", ticket.Patente);
                    cmd.Parameters.AddWithValue("@secCod", ticket.SectorCodigo);
                    cmd.Parameters.AddWithValue("@dur", ticket.Duracion);
                    cmd.Parameters.AddWithValue("@tar", ticket.Tarifa);
                    cmd.Parameters.AddWithValue("@total", ticket.Total);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }

        }
    }
}
