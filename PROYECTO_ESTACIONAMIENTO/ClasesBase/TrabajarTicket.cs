using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarTicket
    {
        public DataTable TraerVentas()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
                {
                    string query = "SELECT tk_id, tk_numero, tk_fechaHoraEnt, tk_fechaHoraSal, cli_dni, tv_codigo, tk_patente, sec_codigo, tk_duracion, tk_tarifa, tk_total FROM Ticket";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public DataTable TraerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
                {
                    string consulta = "SELECT * FROM Ticket WHERE tk_fechaHoraEnt >= @FechaInicio AND tk_fechaHoraEnt <= @FechaFin";
                    using (SqlDataAdapter da = new SqlDataAdapter(consulta, cn))
                    {

                        da.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        da.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);

                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }
        public Ticket TraerTicket(string numeroTicket)
        {
             using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Ticket WHERE tk_numero=@numeroTicket";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@numeroticket", numeroTicket);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                       Ticket tk = new Ticket();
                        tk.TicketNro = int.Parse(dr["tk_numero"].ToString());
                        tk.Patente = dr["tk_patente"].ToString();
                        tk.FechaHoraEnt = DateTime.Parse(dr["tk_fechaHoraEnt"].ToString());
                        tk.ClienteDni = int.Parse(dr["cli_dni"].ToString());
                        tk.Tarifa = decimal.Parse(dr["tk_tarifa"].ToString());
                        tk.FechaHoraSal = DateTime.Parse(dr["tk_fechaHoraSal"].ToString());
                        tk.TvCodigo = int.Parse(dr["tv_codigo"].ToString());
                        tk.SectorCodigo =  int.Parse(dr["sec_codigo"].ToString());
                        tk.Duracion = decimal.Parse(dr["tk_duracion"].ToString());
                        tk.Total = decimal.Parse(dr["tk_total"].ToString());
                        return tk;
                    }
                    else
                    {
                        return null;
                    }
                }

                cn.Close();
            }
        }
       

        // SOLO PARA PRUEBAS
        public void AgregarTicketManual()
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();
                string query = "INSERT INTO Ticket (tk_numero, tk_fechaHoraEnt, tk_fechaHoraSal, cli_dni, tv_codigo, tk_patente, sec_codigo, tk_duracion, tk_tarifa, tk_total) " +
                               "VALUES (@Numero, @FechaHoraEnt, @FechaHoraSal, @DniCliente, @CodigoVehiculo, @Patente, @CodigoSector, @Duracion, @Tarifa, @Total)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Numero", 1);
                    cmd.Parameters.AddWithValue("@FechaHoraEnt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@FechaHoraSal", DateTime.Now.AddHours(2));
                    cmd.Parameters.AddWithValue("@DniCliente", 38293829);
                    cmd.Parameters.AddWithValue("@CodigoVehiculo", 103);
                    cmd.Parameters.AddWithValue("@Patente", "ABC123");
                    cmd.Parameters.AddWithValue("@CodigoSector", 123);
                    cmd.Parameters.AddWithValue("@Duracion", 2.0);
                    cmd.Parameters.AddWithValue("@Tarifa", 10.0);
                    cmd.Parameters.AddWithValue("@Total", 20.0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void modificarTicket(Ticket ticket)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Ticket SET tk_fechaHoraSal=@tk_fechaHoraSal, tk_duracion=@tk_duracion, tk_total=@tk_total WHERE (tk_numero=@tk_numTicket)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("@tk_numTicket", ticket.TicketNro);
                    cmd.Parameters.AddWithValue("@tk_fechaHoraSal", ticket.FechaHoraSal);
                    cmd.Parameters.AddWithValue("@tk_duracion", ticket.Duracion);
                    cmd.Parameters.AddWithValue("@tk_total", ticket.Total);
                    

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }

        }
    }
}
