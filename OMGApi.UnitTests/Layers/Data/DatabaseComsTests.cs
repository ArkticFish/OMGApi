using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using OMGApi.Data;
using OMGApi.Data.Interfaces;
using OMGApi.Models;
using System;

namespace OMGApi.UnitTests.Layers.Data
{
    [TestClass]
    public class DatabaseComsTests
    {

        [TestMethod]
        public void DatabaseComsTests_FillTable()
        {

            IDatabaseComs databaseComs = new DatabaseComs();

            var table = databaseComs.FillTable("SELECT * FROM Movies");

            Console.WriteLine(JsonConvert.SerializeObject(table.Rows.Count));

        }

        [TestMethod]
        public void DatabaseComsTests_RunCommand()
        {

            IDatabaseComs databaseComs = new DatabaseComs();
            // Create installation parameters.
            (string, MySqlDbType, string)[] parameters = {
                ("@imdbID" , MySqlDbType.VarChar, "invalid")
            };

            // Create command text for inserting installation info.
            var commandText = $@"
DELETE FROM movies WHERE imdbID = @imdbID
";

            var effectedRows = databaseComs.RunCommand(commandText, parameters);

            Console.WriteLine(JsonConvert.SerializeObject(effectedRows));

        }

    }
}
