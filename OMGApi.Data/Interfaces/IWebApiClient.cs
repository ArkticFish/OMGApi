using System.Threading.Tasks;

namespace OMGApi.Data.Interfaces
{
    public interface IWebApiClient
    {

        Task<R> GetAsync<R>(string baseUri, string url, string apiKey = "");

    }
}
