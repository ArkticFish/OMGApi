using OMGApi.Models;
using System.Threading.Tasks;

namespace OMGApi.Data.Interfaces
{
    public interface IOMDbConnection
    {

        Task<Movie> SearchMovie(string query);

    }
}
