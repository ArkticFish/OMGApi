using OMGApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMGApi.Logic.Interfaces
{
    public interface IMovieLogic
    {

        Task<Movie> SearchMoviesByTitle(string title);

        Task<Movie> SearchMoviesByTitle(string title, string year) ;

        Task<Movie> SearchMoviesByID(string id);

        List<Movie> GetCachedMovies();

        void PostCachedMovie(Movie movie);

        void PutCachedMovie(string id, Movie movie);

        void DelCachedMovie(string id);

    }
}
