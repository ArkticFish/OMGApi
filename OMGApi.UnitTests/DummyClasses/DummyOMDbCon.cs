using OMGApi.Data.Interfaces;
using OMGApi.Models;
using OMGApi.UnitTests.DummyData;
using System.Threading.Tasks;

namespace OMGApi.UnitTests.DummyClasses
{
    public class DummyOMDbCon : IOMDbConnection
    {
        public Task<Movie> SearchMovie(string query)
        {
            return Task.FromResult(DummyMovies.SingleMovie);
        }

    }
}
