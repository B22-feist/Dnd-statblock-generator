using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace dbStuff
{
    public class dbConnection
    {
        private string ConnectToDatabase()
        {
            dbConnection numCall = new();
            
            string connstring = "server=localhost; uid=root; pwd=VeryLazyPAssword; database= dndspells; Persist Security Info=True;";
            
            using (MySqlConnection conn = new MySqlConnection(connstring)) {
                try
                {
                    conn.Open();

                    string ReValue = "";
                    string cmd = "SELECT * FROM spells";

                    using (MySqlCommand comand = new MySqlCommand(cmd, conn))
                    {
                        using (MySqlDataReader  reader = comand.ExecuteReader()) 
                        {
                            if (reader.Read())
                            {
                                ReValue = reader.GetString(numCall.ReaderLength(reader)-1);
                                return ReValue;
                            }
                        }
                    }
                    return ReValue;
                }

                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public void dboutput()
        {
            dbConnection connection = new dbConnection();

            if (connection.ConnectToDatabase() == "")
            {
                Console.WriteLine("didn't excute command");
            }

            else
            {
                string Returndboutput1 = connection.ConnectToDatabase();
                Console.WriteLine(Returndboutput1);
            }
        }

        int ReaderLength(MySqlDataReader input)
        {
            int counter = 0;

            while (input.Read()) {
                counter++;
            }
            return counter;
        }
    }
}
