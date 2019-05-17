using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity.Connected
{
   public class Services
    {
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["main"].ToString());

                return connection;
            }
            set { connection = value; }
        }
    }
}
