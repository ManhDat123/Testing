using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tesing
{
    public class Conn
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public void initilize()
        {
            string connectionString;
            connectionString = $"server=localhost;port=3307;database=ql_khohang;user=sa;password=1234";
            connection = new MySqlConnection(connectionString);

        }
        public void OpenConnection()
        {
            connection.Open();
        }

        //Close connection
        public void CloseConnection()
        {
            connection.Close();
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public DataTable Select(String query)

        {
            MySqlDataAdapter returnVal = new MySqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            try
                {
                returnVal.Fill(dt);
                }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            return dt;
        }
        public string getUserName(String query)
        {
            string username = "";
            MySqlCommand cmd = new MySqlCommand(query,connection);
            
            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
           
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        username += rd.GetString(2);
                    }
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            return username;
        }


        public void Count()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
