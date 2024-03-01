﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tesing
{
    public class Conn
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string user;
        private string password;

        public Conn(String server, String port, String database, String user, String password)
        {
            this.server = server;
            this.port = port;
            this.database = database;
            this.user = user;
            this.password = password;
        }
        public void initilize()
        {
            string connectionString;
            connectionString = $"server=" + server + ";port=" + port + ";database=" + database + ";user=" + user + ";password=" + password;
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
        public void Insert(String query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        //Update statement
        public void Update(String query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        //Delete statement
        public void Delete(String query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
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
        public string getUsername(String query)
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


        public int Count(String query)
        {
            OpenConnection();
            int result = 0;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                result = rd.GetInt32(0);
            }
            CloseConnection();
            return result;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }

        public String GetName(String username, String password)
        {
            String result = "";
            String login = "SELECT * FROM users WHERE username =@username AND password =@password;";
            MySqlCommand cmd = new MySqlCommand(login, connection);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                result = rd.GetString(2);
            }
            rd.Close();
            return result;
        }

        public bool IsValid(String username, String password)
        {
            connection.Open();
            String login = "SELECT * FROM users WHERE username =@username AND password =@password;";
            MySqlCommand cmd = new MySqlCommand(login, connection);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader rd = cmd.ExecuteReader();
            try
            {
                if (rd.HasRows)
                {
                    rd.Close();
                    return true;
                }
                else { MessageBox.Show("Tài khoản hoặc mật khẩu không đúng"); }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            rd.Close();
            connection.Close();
            return false;
        }
    }
}
