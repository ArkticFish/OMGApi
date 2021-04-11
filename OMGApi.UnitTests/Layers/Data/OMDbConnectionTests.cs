using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OMGApi.Data;
using OMGApi.Data.Interfaces;
using OMGApi.Models;
using System;

namespace OMGApi.UnitTests.Layers.Data
{
    [TestClass]
    public class OMDbConnectionTests
    {

        [TestMethod]
        public void OMDbConnection_Title()
        {

            IWebApiClient client = new WebApiClient();

            IOMDbConnection oMDbConnection = new OMDbConnection(client);

            Movie movie = oMDbConnection.SearchMovie("?t=thor").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void OMDbConnection_TitleAndYear()
        {

            IWebApiClient client = new WebApiClient();

            IOMDbConnection oMDbConnection = new OMDbConnection(client);

            Movie movie = oMDbConnection.SearchMovie("?t=thor&y=2017").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void OMDbConnection_ImdbID()
        {

            IWebApiClient client = new WebApiClient();

            IOMDbConnection oMDbConnection = new OMDbConnection(client);

            Movie movie = oMDbConnection.SearchMovie("?i=tt3501632").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

    }
}
