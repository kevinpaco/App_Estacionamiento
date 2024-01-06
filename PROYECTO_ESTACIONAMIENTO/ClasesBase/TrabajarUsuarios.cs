using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;

namespace ClasesBase
{
    public class TrabajarUsuarios
    {
        public static ObservableCollection<Usuario> TraerUsuario()
        {
            ObservableCollection<Usuario> listausuario= new ObservableCollection<Usuario>();
            DataTable dt = new DataTable();
            dt = UsuarioABM.listUsuarios();

            foreach(DataRow fila in dt.Rows){
                Usuario usu = new Usuario(fila["user_userName"].ToString(),
                                          fila["user_password"].ToString(),
                                          fila["user_apellido"].ToString(),
                                          fila["user_nombre"].ToString(),
                                          fila["user_rol"].ToString());
                listausuario.Add(usu);
            }
            
            return listausuario;
        }
    }
}
