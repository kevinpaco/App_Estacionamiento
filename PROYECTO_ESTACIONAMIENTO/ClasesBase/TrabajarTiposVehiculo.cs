using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarTiposVehiculo
    {
        public static DataTable TraerTiposVehiculo()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT tv_codigo AS 'Codigo',tv_descripcion AS 'Descripcion',tv_tarifa AS 'Tarifa',tv_imagen AS Imagen FROM TipoVehiculo", cn))
                    {
                        da.Fill(dt);
                    }
                }


                return dt;
            }
        }

        public static bool VerificarExistenciaCodigo(int codigo)
        {
            bool existe = false;

            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.coneccion))
            {
                cn.Open();

                // Consulta SQL para verificar la existencia del código
                string consulta = "SELECT COUNT(*) FROM TipoVehiculo WHERE tv_codigo = @Codigo";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    // Ejecutar la consulta y obtener el número de filas
                    int rowCount = (int)cmd.ExecuteScalar();

                    // Si rowCount es mayor que 0, significa que el código ya existe en la base de datos
                    existe = rowCount > 0;
                }
            }

            return existe;
        }


        public static void guardarVehiculo(TipoVehiculo nuevoVehiculo)
        {

            Console.WriteLine("se agrego ");
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO TipoVehiculo(tv_codigo,tv_descripcion,tv_tarifa) values(@tv_codigo,@tv_descripcion,@tv_tarifa)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;


            cmd.Parameters.AddWithValue("@tv_codigo", nuevoVehiculo.TvCodigo);
            cmd.Parameters.AddWithValue("@tv_descripcion", nuevoVehiculo.Descripcion);
            cmd.Parameters.AddWithValue("@tv_tarifa", nuevoVehiculo.Tarifa);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void modificarTipoVehiculo(TipoVehiculo nuevoVehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE TipoVehiculo SET tv_descripcion=@tv_descripcion,tv_tarifa=@tv_tarifa WHERE tv_codigo=@tv_codigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@tv_codigo", nuevoVehiculo.TvCodigo);
            cmd.Parameters.AddWithValue("@tv_descripcion", nuevoVehiculo.Descripcion);
            cmd.Parameters.AddWithValue("@tv_tarifa", nuevoVehiculo.Tarifa);


            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarTipoVehiculo(TipoVehiculo nuevoVehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM TipoVehiculo WHERE tv_codigo=@tv_codigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@tv_codigo", nuevoVehiculo.TvCodigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

    }
}

