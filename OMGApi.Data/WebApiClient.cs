using Newtonsoft.Json;
using OMGApi.Data.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMGApi.Data
{
    public class WebApiClient : IWebApiClient
    {
        public async Task<R> GetAsync<R>(string baseUri, string url, string apiKey = "")
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            var response = await client.GetAsync(url + $"&apikey={apiKey}");
            var resp = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("You are not allowed to use this service.");
            return JsonConvert.DeserializeObject<R>(resp);
        }

    }
}
