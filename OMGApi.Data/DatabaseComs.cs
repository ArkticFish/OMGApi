using MySql.Data.MySqlClient;
using OMGApi.Data.Interfaces;
using System.Data;

namespace OMGApi.Data
{
    public class DatabaseComs : IDatabaseComs
    {

        private readonly string conString = "Server=localhost; database=onlinemovies; UID=root; password=roots";

        public DataTable FillTable(string commandText)
        {
            var con = new MySqlConnection(conString);
            var dataTable = new DataTable();
            var command = new MySqlCommand(commandText, con);
            var adapter = new MySqlDataAdapter(command);
            con.Open();
            adapter.Fill(dataTable);
            con.Close();
            return dataTable;

        }

        public int RunCommand(string commandText, (string PName, MySqlDbType PType, string PValue)[] parameters)
        {
            var con = new MySqlConnection(conString);
            var command = new MySqlCommand(commandText, con);
            foreach (var param in parameters)
            {
                command.Parameters.Add(param.PName, param.PType);
                if (string.IsNullOrEmpty(param.PValue))
                    command.Parameters[param.PName].Value = string.Empty;
                else
                    command.Parameters[param.PName].Value = param.PValue;
            }
            con.Open();
            int count = command.ExecuteNonQuery();
            con.Close();
            return count;
        }

    }
}
