using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace adopse
{
    public class dbConnector
    {
        private static string Host = "dblabs.it.teithe.gr";
        private static string User = "it185244";
        private static string DBname = "it185244";
        private static string Password = "adopse21";
        private static string Port = "5432";

        public static void connect()
        {
            string connString =
               String.Format(
                   "Server={0};Username={1};Database={2};Port={3};Password={4};",
                   Host,
                   User,
                   DBname,
                   Port,
                   Password);

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
            
                conn.Open();

               
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
