using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OMGApi.Data;
using OMGApi.Data.Interfaces;
using OMGApi.Models;
using System;

namespace OMGApi.UnitTests.Layers.Data
{
    [TestClass]
    public class WebApiClientTests
    {

        [TestMethod]
        public void WebAPIClient_Title()
        {

            string apiKey = "35eba3c4";
            string baseURI = "http://www.omdbapi.com";
            string url = "?t=thor ragnarok";

            IWebApiClient client = new WebApiClient();

            Movie movie = client.GetAsync<Movie>(baseURI, url, apiKey).Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void WebAPIClient_TitleAndYear()
        {

            string apiKey = "35eba3c4";
            string baseURI = "http://www.omdbapi.com";
            string url = "?t=thor&y=2017";

            IWebApiClient client = new WebApiClient();

            Movie movie = client.GetAsync<Movie>(baseURI, url, apiKey).Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void WebAPIClient_ImdbID()
        {

            string apiKey = "35eba3c4";
            string baseURI = "http://www.omdbapi.com";
            string url = "?i=tt3501632";

            IWebApiClient client = new WebApiClient();

            Movie movie = client.GetAsync<Movie>(baseURI, url, apiKey).Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void WebAPIClient_WrongAPIKey()
        {

            string apiKey = "gysefsdfbjh";
            string baseURI = "http://www.omdbapi.com";
            string url = "?t=thor ragnarok";

            IWebApiClient client = new WebApiClient();

            try
            {
                var movie = client.GetAsync<Movie>(baseURI, url, apiKey).Result;
                Console.WriteLine(JsonConvert.SerializeObject(movie));
            }
            catch (Exception ex)
            {
                if (ex.Message != "One or more errors occurred. (You are not allowed to use this service.)")
                    throw ex;
            }

        }

    }
}
