using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Trades.src;

namespace Trades.src
{
    class TradeMigrate
    {
        public static void Migrate()
        {
            
            MySqlConnection con = new MySqlConnection(TradesContext.GetMYSQLStringLink());
            string query =
            @"CREATE TABLE trades
                (
                 id int NOT NULL PRIMARY KEY,
                 price DOUBLE NOT NULL,
                 quantity DOUBLE NOT NULL,
                 side VARCHAR(255) NOT NULL,
                 timestamp DATETIME NOT NULL
                );";
            MySqlCommand cmd = new MySqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
