using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source=LOORJACOBSON;initial catalog=deruzims;persist security info=True;user id=sa;password=.inhotesT1234.";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection Opened");
                    string query = "SELECT COUNT(*) FROM Product";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        Console.WriteLine("Total number of products: " + count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine(); 
        }
    }
}
