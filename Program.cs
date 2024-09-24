using auto.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    public class Connect
    {
        public MySqlConnection connection;
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

    public class Program
    {
        public static Connect conn = new Connect();
        public static List<Car> cars = new List<Car>();

        static void feltolt()
        {
            conn.connection.Open();
            string sql = "SELECT * FROM `cars`";
            MySqlCommand cmd = new MySqlCommand(sql, conn.connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            do
            {
                Car car = new Car();
                car.Id = dr.GetInt32(0);
                car.Brand = dr.GetString(1);
                car.Type = dr.GetString(2);
                car.License = dr.GetString(3);
                car.Date = dr.GetInt32(4);

                cars.Add(car);
            } while (dr.Read());

            


            conn.connection.Close();
        }
        static void Main(string[] args)
        {
            feltolt();
            foreach (Car item in cars)
            {
                Console.WriteLine($"Autó gyártója: {item.Brand} motor száma {item.License}.");
            }
            Console.WriteLine(cars.Count);

            Console.ReadLine();
        }
    }
}
