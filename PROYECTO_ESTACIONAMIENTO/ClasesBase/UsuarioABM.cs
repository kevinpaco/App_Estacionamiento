using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class UsuarioABM
    {
        public static void ingresarUsuario(Usuario usuario)
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuario(user_userName,user_password,user_apellido,user_nombre,user_rol) values(@uName,@pass,@ape,@nom,@rol)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.Parameters.AddWithValue("@uName",usuario.UserName);
            cmd.Parameters.AddWithValue("@pass", usuario.Password);
            cmd.Parameters.AddWithValue("@ape", usuario.Apellido);
            cmd.Parameters.AddWithValue("@nom", usuario.Nombre);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static DataTable listUsuarios()
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            /*SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;*/

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuario",cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void modificarUsuario(Usuario usu)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Usuario SET user_userName=@uName, user_password=@pass, user_apellido=@ape, user_nombre=@nom, user_rol=@rol  WHERE (user_id=@user_id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@user_id",usu.User_id);
                    cmd.Parameters.AddWithValue("@uName", usu.UserName);
                    cmd.Parameters.AddWithValue("@pass", usu.Password);
                    cmd.Parameters.AddWithValue("@ape", usu.Apellido);
                    cmd.Parameters.AddWithValue("@nom", usu.Nombre);
                    cmd.Parameters.AddWithValue("@rol", usu.Rol);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }

        }

        public static void eliminarusuario(string userName)
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Usuario WHERE user_userName=@uName";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@uName",userName);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static Boolean buscarUsuario(string usuName)
        {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT @count_usu= count(*) FROM Usuario WHERE user_userName=@uName";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.Parameters.AddWithValue("@uName", usuName);

            cmd.Parameters.Add("@count_usu",SqlDbType.Int);
            cmd.Parameters["@count_usu"].Direction = ParameterDirection.Output;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            return ((int)cmd.Parameters["@count_usu"].Value) == 0;
        }

        public static Usuario buscarUnUsuario(string usuName)
        {
            using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario WHERE user_userName=@uName";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@uName", usuName);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Usuario usu = new Usuario();

                        usu.User_id = int.Parse(dr["user_id"].ToString());
                        usu.UserName = dr["user_userName"].ToString();
                        usu.Password = dr["user_password"].ToString();
                        usu.Apellido = dr["user_apellido"].ToString();
                        usu.Nombre = dr["user_nombre"].ToString();
                        usu.Rol = dr["user_rol"].ToString();

                        return usu;
                    }
                    else
                    {
                        return null;
                    }
                }

                cn.Close();
            }
        }


    }
}
