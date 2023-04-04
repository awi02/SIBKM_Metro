using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Context
{
    internal class OurContext
    {
        private static SqlConnection connection;
        private static string connectionstring = "Data Source=LAPTOP-OE2ICFDP;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public static SqlConnection GetConnection()
        {
            try
            {
                connection = new SqlConnection(connectionstring);
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return connection;
        }
    }
}
