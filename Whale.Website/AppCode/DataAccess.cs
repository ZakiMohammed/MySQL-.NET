using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Whale.Website.AppCode
{
    public class DataAccess
    {
        private MySqlConnection     connection;
        private MySqlCommand        command;
        private MySqlDataAdapter    adapter;

        public DataAccess(string connectionString = Constants.CONNECTION_STRING)
        {
            connection  = new MySqlConnection(connectionString);
            command     = new MySqlCommand() { Connection = connection };
            adapter     = new MySqlDataAdapter(command);
        }

        public class Parameters
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }

        public DataTable ExecuteTable(string query)
        {
            var table = new DataTable();

            connection.Open();
            command.CommandText = query;
            table.Load(command.ExecuteReader());
            connection.Close();

            return table;
        }

        public DataTable ExecuteTable(string query, List<Parameters> param)
        {
            var table = new DataTable();

            connection.Open();
            command.CommandText = query;
            command.Parameters.Clear();
            foreach (var item in param)
            {
                command.Parameters.AddWithValue(item.Name, item.Value);
            }
            table.Load(command.ExecuteReader());
            connection.Close();

            return table;
        }

        public object ExecuteScalar(string query)
        {
            object result;

            connection.Open();
            command.CommandText = query;
            result = command.ExecuteScalar();
            connection.Close();

            return result;
        }

        public int ExecuteNonQuery(string query, List<Parameters> param)
        {
            int result;

            connection.Open();
            command.CommandText = query;
            command.Parameters.Clear();
            foreach (var item in param)
            {
                command.Parameters.AddWithValue(item.Name, item.Value);
            }
            result = command.ExecuteNonQuery();
            connection.Close();

            return result;
        }

        public DataSet ExecuteStoredProcedure(string name, List<Parameters> param)
        {
            var resultSet = new DataSet();

            command.CommandText = name;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            foreach (var item in param)
            {
                command.Parameters.AddWithValue(item.Name, item.Value);
            }

            adapter.Fill(resultSet);

            return resultSet;
        }
    }
}