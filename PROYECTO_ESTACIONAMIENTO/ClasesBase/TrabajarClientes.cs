using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarClientes
    {
        public static Cliente TraerCliente(int dni)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cliente WHERE cli_dni=@dni", cn))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int, 3));
                    da.SelectCommand.Parameters["@dni"].Value = dni;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Obtenemos la primera fila del resultado
                        DataRow dr = dt.Rows[0];

                        // Creamos un nuevo objeto Cliente
                        Cliente cliente = new Cliente();

                        // Asignamos los valores de las columnas a los atributos del cliente
                        cliente.ClienteDni = (int)dr["cli_dni"];
                        cliente.Nombre = (string)dr["cli_nombre"];
                        cliente.Apellido = (string)dr["cli_apellido"];
                        cliente.Telefono = (string)dr["cli_telefono"];

                        return cliente;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }


        public static bool VerificarExistenciaDni(int dni)
        {
            bool existe = false;

            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.coneccion))
            {
                cn.Open();

                // Consulta SQL para verificar la existencia del código
                string consulta = "SELECT COUNT(*) FROM Cliente WHERE cli_dni = @Dni";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@Dni", dni);

                    // Ejecutar la consulta y obtener el número de filas
                    int rowCount = (int)cmd.ExecuteScalar();

                    // Si rowCount es mayor que 0, significa que el código ya existe en la base de datos
                    existe = rowCount > 0;
                }
            }

            return existe;
        }







        public static DataTable TraerClientes()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT cli_dni AS 'Dni',cli_apellido AS 'Apellido',cli_nombre AS 'Nombre',cli_telefono AS Telefono FROM Cliente", cn))
                    {
                        da.Fill(dt);
                    }
                }


                return dt;
            }

        }


        public static void guardarCliente(Cliente nuevoCliente)
        {

            Console.WriteLine("se agrego ");
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Cliente(cli_dni,cli_apellido,cli_nombre,cli_telefono) values(@cli_dni,@cli_apellido,@cli_nombre,@cli_telefono)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;


            cmd.Parameters.AddWithValue("@cli_dni", nuevoCliente.ClienteDni);
            cmd.Parameters.AddWithValue("@cli_apellido", nuevoCliente.Apellido);
            cmd.Parameters.AddWithValue("@cli_nombre", nuevoCliente.Nombre);
            cmd.Parameters.AddWithValue("@cli_telefono", nuevoCliente.Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void modificarCliente(Cliente nuevoCliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Cliente SET cli_apellido=@cli_apellido,cli_nombre=@cli_nombre, cli_telefono=@cli_telefono WHERE cli_dni=@cli_dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cli_dni", nuevoCliente.ClienteDni);
            cmd.Parameters.AddWithValue("@cli_apellido", nuevoCliente.Apellido);
            cmd.Parameters.AddWithValue("@cli_nombre", nuevoCliente.Nombre);
            cmd.Parameters.AddWithValue("@cli_telefono", nuevoCliente.Telefono);


            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarCliente(Cliente clienteNuevo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Cliente WHERE cli_dni=@Dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@Dni", clienteNuevo.ClienteDni);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }




    }
}