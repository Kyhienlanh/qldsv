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
        public static String stringconnection = @"server=DOTANLOC; database=quanlidiem;integrated security=true";
        public  static SqlConnection GetSqlConnection()

        {
            return new SqlConnection(stringconnection);
        }
    }
}
