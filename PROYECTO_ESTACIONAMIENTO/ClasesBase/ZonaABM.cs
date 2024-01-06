using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class ZonaABM
    {
        public static List<Zona> TraerZonas()
        {
            // Declara una lista de tipos de vehículos
            List<Zona> listaZonas = new List<Zona>();

            // Obtiene los datos de la base de datos
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT zo_id AS 'ID',zo_codigo AS 'Codigo',zo_descripcion AS 'Descripcion',zo_piso as 'Piso' FROM Zona", cn))
                {
                    da.Fill(dt);
                }
            }


            // Recorre la tabla de datos y agrega cada fila a la lista
            foreach (DataRow fila in dt.Rows)
            {
                // Crea un nuevo objeto Sector
                Zona zona = new Zona();

                // Asigna los valores de la fila al objeto TipoVehiculo
                zona.Zo_id = int.Parse(fila["ID"].ToString());
                zona.ZonaCodigo = int.Parse(fila["Codigo"].ToString());
                zona.Descripcion = fila["Descripcion"].ToString();
                zona.Piso = fila["Piso"].ToString();
               
                listaZonas.Add(zona);
            }

            // Devuelve la lista de tipos de vehículos
            return listaZonas;
        }

        public static Zona buscarZona(int codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT zo_id AS 'ID',zo_codigo AS 'Codigo',zo_descripcion AS 'Descripcion',zo_piso as 'Piso' FROM Zona WHERE zo_codigo=@cod";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cod", codigo);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Zona zona = new Zona();
                // Asigna los valores de la fila al objeto TipoVehiculo
                zona.Zo_id = int.Parse(dr["ID"].ToString());
                zona.ZonaCodigo = int.Parse(dr["Codigo"].ToString());
                zona.Descripcion = dr["Descripcion"].ToString();
                zona.Piso = dr["Piso"].ToString();

                cnn.Close();
                return zona;
            }
            else
            {
                cnn.Close();
                return null;
            }
        }
    }
}
