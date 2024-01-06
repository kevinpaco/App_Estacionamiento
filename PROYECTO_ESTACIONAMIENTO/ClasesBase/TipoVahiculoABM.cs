using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TipoVahiculoABM
    {
        public static TipoVehiculo buscarVehiculo(string descripcionVehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM TipoVehiculo WHERE tv_descripcion=@des";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@des",descripcionVehiculo);

            SqlDataReader dr = cmd.ExecuteReader();
           
            if (dr.Read())
            {
                TipoVehiculo tv = new TipoVehiculo();
                //tv.Tv_id = int.Parse(dr["tv_id"].ToString());
                tv.TvCodigo = int.Parse(dr["tv_codigo"].ToString());
                tv.Descripcion = dr["tv_descripcion"].ToString();
                tv.Tarifa = decimal.Parse(dr["tv_tarifa"].ToString());
                tv.UrlImagen = dr["tv_imagen"].ToString();
                cnn.Close();
                return tv;
            }
            else {
                cnn.Close();
                return null;
            }
            
        }

        public static TipoVehiculo buscarVehiculoPorCod(int codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM TipoVehiculo WHERE tv_codigo=@des";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@des", codigo);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                TipoVehiculo tv = new TipoVehiculo();
               // tv.Tv_id = int.Parse(dr["tv_id"].ToString());
                tv.TvCodigo = int.Parse(dr["tv_codigo"].ToString());
                tv.Descripcion = dr["tv_descripcion"].ToString();
                tv.Tarifa = decimal.Parse(dr["tv_tarifa"].ToString());
                tv.UrlImagen = dr["tv_imagen"].ToString();
                cnn.Close();
                return tv;
            }
            else
            {
                cnn.Close();
                return null;
            }

        }

        public static List<TipoVehiculo> TraerTiposVehiculo()
        {
            // Declara una lista de tipos de vehículos
            List<TipoVehiculo> listaTiposVehiculo = new List<TipoVehiculo>();

            // Obtiene los datos de la base de datos
            DataTable dt = new DataTable();
           
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT tv_codigo AS 'Codigo',tv_descripcion AS 'Descripcion',tv_tarifa AS 'Tarifa' FROM TipoVehiculo", cn))
                    {
                        da.Fill(dt);
                    }
                }
            

            // Recorre la tabla de datos y agrega cada fila a la lista
            foreach (DataRow fila in dt.Rows)
            {
                // Crea un nuevo objeto TipoVehiculo
                TipoVehiculo tipoVehiculo = new TipoVehiculo();

                // Asigna los valores de la fila al objeto TipoVehiculo
                tipoVehiculo.TvCodigo = int.Parse(fila["Codigo"].ToString());
                tipoVehiculo.Descripcion = fila["Descripcion"].ToString();
                tipoVehiculo.Tarifa = Convert.ToDecimal(fila["Tarifa"]);

                // Agrega el objeto TipoVehiculo a la lista
                listaTiposVehiculo.Add(tipoVehiculo);
            }

            // Devuelve la lista de tipos de vehículos
            return listaTiposVehiculo;
        }

    }
}
