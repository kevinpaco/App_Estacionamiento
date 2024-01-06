using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarSector
    {
        public DataTable TraerSectores()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.coneccion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TipoVehiculo", cn))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }
    }
}
