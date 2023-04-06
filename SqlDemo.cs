using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace week_3
{
    internal class SqlDemo
    {
        public static void main(string[] args)
        {
            string connectionString = "Data Source = DESKTOP-50S2HSR;Initial Catalog=practiceDB;Integrated Security=True;Encrypt=False;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            //cmd.CommandText = "insert into Customers values('saran', 'chennai')";
            //cmd.ExecuteReader().Close();
            try
            {
                cmd.CommandText = "Select * from Customers inner join Orders on Customers.id=Orders.customerId";
                SqlDataReader reader = cmd.ExecuteReader();
                //reader.GetColumnSchema().ToList().ForEach(x => Console.WriteLine(x.ColumnName));
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        Console.WriteLine(reader.GetValue(i));
                    }

                    Console.WriteLine("");
                }
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Err: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Format Err: {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Operation Err: {e.Message}");
            }
        }
    }
}
