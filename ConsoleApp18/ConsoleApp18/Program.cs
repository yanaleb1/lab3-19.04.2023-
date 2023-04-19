using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace ConsoleApp18
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
            string id, surname, name, birthday, category, gender, phonenumber ;
            string sql = "Select surgeon_num, surname, name, birthday, category, gender, phone_number from surgeons";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())

            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["surgeon_num"].ToString();
                        surname = reader["surname"].ToString();
                        name = reader["name"].ToString();
                        birthday = reader["birthday"].ToString();
                        category = reader["category"].ToString();
                        gender = reader["gender"].ToString();
                        phonenumber = reader["phone_number"].ToString();
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Surgeon num:" + id + " Surname:" + surname + " Ім'я:" + name 
                            + " Birthday:" + birthday + " Category:" + category 
                            + " Gender:" + gender + " Phone number:" + phonenumber);
                        Console.WriteLine("-----------------------------------------------------------");
                    }
                }
            }
        }
    }




}
