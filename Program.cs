using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    public class Connect
    {
        public static MySqlConnection connection;
        private string Host;
        private string Database;
        private string Username;
        private string Password;
        private string ConnectionString;

        public Connect()
        {
            Host = "localhost";
            Database = "auto";
            Username = "root";
            Password = "";

            ConnectionString = "SERVER=" + Host+";DATABASE="+Database+";UID="+Username+";PASSWORD="+Password+";SslMode=None" ;

            connection = new MySqlConnection(ConnectionString);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
