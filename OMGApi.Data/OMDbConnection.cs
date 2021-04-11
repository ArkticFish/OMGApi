using OMGApi.Data.Interfaces;
using OMGApi.Models;
using System;
using System.Threading.Tasks;

namespace OMGApi.Data
{
    public class OMDbConnection : IOMDbConnection
    {

        private readonly string _apiKey = "35eba3c4";
        private readonly string _omdbConString = @"http://www.omdbapi.com";

        private readonly IWebApiClient _webApiClient;

        public OMDbConnection(IWebApiClient webApiClient)
        {
            _webApiClient = webApiClient;
        }

        public async Task<Movie> SearchMovie(string query)
        {

            var apiResponce = await _webApiClient.GetAsync<Movie>(_omdbConString, query, _apiKey);

            if (apiResponce.Response == "False")
                throw new Exception(apiResponce.Error);
            else
                return apiResponce;

        }

    }
}
