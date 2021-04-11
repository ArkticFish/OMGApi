using MySql.Data.MySqlClient;
using OMGApi.Data.Interfaces;
using System;
using System.Data;

namespace OMGApi.UnitTests.DummyClasses
{
    public class DummyDatabaseComs : IDatabaseComs
    {
        public DataTable FillTable(string commandText)
        {
            return new DataTable();
        }

        public int RunCommand(string commandText, (string PName, MySqlDbType PType, string PValue)[] parameters)
        {
            Console.WriteLine(commandText);
            return 1;
        }

    }
}
