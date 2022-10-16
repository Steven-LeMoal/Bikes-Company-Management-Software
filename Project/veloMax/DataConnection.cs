using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace veloMax
{
    class DataConnection
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;database=velomax;username=root;password=Kilosierra16;");

        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public MySqlConnection DataBase()
        {
            return connection;
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public bool Connection_Query(MySqlCommand command)
        {
            this.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                this.closeConnection();
                return true;
            }
            else
            {
                this.closeConnection();
                return false;
            }
        }



    }
}
