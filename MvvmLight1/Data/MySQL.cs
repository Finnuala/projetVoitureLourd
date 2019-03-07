using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MvvmLight1.Data
{
    public class MySQL
    {
        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static MySQL _instance = null;
        public static MySQL Instance()
        {
            if (_instance == null)
                _instance = new MySQL();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                connection = new MySqlConnection(Properties.Settings.Default.selectcarConnectionString2);
                connection.Open();
            }

            return true;
        }

        public MySQL()
        {
            connection = new MySqlConnection(Properties.Settings.Default.selectcarConnectionString2);
        }

        public bool ReaderQuery(string query)
        {
            MySqlDataReader result;
            connection.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                result = cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            connection.Close();

            if (result != null)
                return true;
            else
                return false;
        }

        public bool ExecuteQuery(string query)
        {
            int result;
            connection.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            connection.Close();

            if (result > 0)
                return true;
            else
                return false;
        }

        public void Open()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
