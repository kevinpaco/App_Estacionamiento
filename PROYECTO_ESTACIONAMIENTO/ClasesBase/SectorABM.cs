using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
   public class SectorABM
    {

        public static Sector buscarSector(int codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector WHERE sec_codigo=@cod";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cod", codigo);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Sector sec = new Sector();
                sec.Sec_id = int.Parse(dr["sec_id"].ToString());
                sec.SectorCodigo = int.Parse(dr["sec_codigo"].ToString());
                sec.Descripcion = dr["sec_descripcion"].ToString();
                sec.Identificador = dr["sec_identificador"].ToString();
                sec.Habilitado = Boolean.Parse(dr["sec_habilitado"].ToString());
                sec.Estado = int.Parse(dr["sec_estado"].ToString());
                cnn.Close();
                return sec;
            }
            else
            {
                cnn.Close();
                return null;
            }
        }


        public static List<Sector> TraerSectores(int zonaCod)
        {
            // Declara una lista de tipos de vehículos
            List<Sector> listaSectores = new List<Sector>();

            // Obtiene los datos de la base de datos
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT sec_id AS 'ID',sec_codigo AS 'Codigo',sec_descripcion AS 'Descripcion',sec_identificador AS 'Identificador', sec_habilitado as 'Habilitado',zo_codigo as 'Zo_codigo',sec_estado as 'Estado' FROM Sector WHERE zo_codigo = @zonaCod", cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@zonaCod", zonaCod);
                    da.Fill(dt);
                }
            }


            // Recorre la tabla de datos y agrega cada fila a la lista
            foreach (DataRow fila in dt.Rows)
            {
                // Crea un nuevo objeto Sector
                Sector sector = new Sector();

                // Asigna los valores de la fila al objeto TipoVehiculo
                sector.Sec_id = int.Parse(fila["ID"].ToString());
                sector.SectorCodigo = int.Parse(fila["Codigo"].ToString());
                sector.Descripcion = fila["Descripcion"].ToString();
                sector.Identificador = fila["Identificador"].ToString();
                sector.Habilitado = Boolean.Parse(fila["Habilitado"].ToString());
                sector.Estado = int.Parse(fila["Estado"].ToString());
                // Agrega el objeto sector a la lista
                listaSectores.Add(sector);
            }

            // Devuelve la lista de tipos de vehículos
            return listaSectores;
        }

        public static void modificarSector(Sector sec)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Sector SET sec_estado=@est WHERE (sec_id=@sec_id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@sec_id", sec.Sec_id);
                    cmd.Parameters.AddWithValue("@est", sec.Estado);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        public static void deshabilitarSector(Sector sec)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Sector SET sec_habilitado=0 WHERE (sec_id=@sec_id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@sec_id", sec.Sec_id);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        public static void habilitarSector(Sector sec)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Sector SET sec_habilitado=1 WHERE (sec_id=@sec_id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@sec_id", sec.Sec_id);
                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }
    }
}
