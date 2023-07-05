using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlidiem
{
    internal class connection
    {
        public static String stringconnection = @"Data Source=GIAKY;Initial Catalog = quanlidiem11; Integrated Security = True";
        public  static SqlConnection GetSqlConnection()

        {
            return new SqlConnection(stringconnection);
        }
    }
}
