using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public interface IWebApiClient
    {

        Task<R> GetAsync<R>(string baseUri, string url);

        Task PutAsync<S>(string baseUri, string url, S package);

        Task PostAsync<S>(string baseUri, string url, S package);

        Task DeleteAsync(string baseUri, string url);

    }
    public class WebApiClient : IWebApiClient
    {

        public async Task<R> GetAsync<R>(string baseUri, string url)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            var response = await client.GetAsync(url);
            var resp = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("You are not allowed to use this service.");
            return JsonConvert.DeserializeObject<R>(resp);
        }

        public async Task PostAsync<S>(string baseUri, string url, S package)
        {
            var json = JsonConvert.SerializeObject(package);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            var response = await client.PostAsync(url, data);
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("You are not authorized to use this service.");
        }

        public async Task PutAsync<S>(string baseUri, string url, S package)
        {
            var json = JsonConvert.SerializeObject(package);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            var response = await client.PutAsync(url, data);
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("You are not authorized to use this service.");
        }

        public async Task DeleteAsync(string baseUri, string url)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            var response = await client.DeleteAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("You are not authorized to use this service.");
        }

    }
}
