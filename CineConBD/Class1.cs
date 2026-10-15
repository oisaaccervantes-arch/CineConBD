using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;


namespace CineConBD
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CineDB"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
