using MySql.Data.MySqlClient;
using System.Data;

namespace OMGApi.Data.Interfaces
{
    public interface IDatabaseComs
    {

        DataTable FillTable(string commandText);

        int RunCommand(string commandText, (string PName, MySqlDbType PType, string PValue)[] parameters);

    }
}
