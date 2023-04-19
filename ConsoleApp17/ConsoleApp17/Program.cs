using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.Read();
        }
        private static void QueryEmployee(MySqlConnection conn)
        {
            string id, name, country;
            string sql = "Select Code, Name, Continent from country";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())

            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["Code"].ToString();
                        name = reader["Name"].ToString();
                        country = reader["Continent"].ToString();
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Код:" + id + " Назва:" + name + " Континент:" + country);
                        Console.WriteLine("-----------------------------------------------------------");
                    }
                }
            }
        }
    }

    

    
}

