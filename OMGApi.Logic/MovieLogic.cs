using OMGApi.Data.Interfaces;
using OMGApi.Logic.Interfaces;
using OMGApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMGApi.Logic
{
    public class MovieLogic : IMovieLogic
    {

        private readonly IDataCache dataCache;
        private readonly IMovieData movieData;
        private readonly IOMDbConnection omdbConnection;

        public MovieLogic(IOMDbConnection omdbConnection, IDataCache dataCache, IMovieData movieData)
        {
            this.dataCache = dataCache;
            this.movieData = movieData;
            this.omdbConnection = omdbConnection;
        }

        public async Task<Movie> SearchMoviesByID(string id)
        {
            var movie = await omdbConnection.SearchMovie($"?i={id}");

            CheckAndAdd(movie);

            return movie;
        }

        public async Task<Movie> SearchMoviesByTitle(string title)
        {
            var movie = await omdbConnection.SearchMovie($"?t={title}");

            CheckAndAdd(movie);

            return movie;
        }

        public async Task<Movie> SearchMoviesByTitle(string title, string year)
        {
            var movie = await omdbConnection.SearchMovie($"?t={title}&y={year}");

            CheckAndAdd(movie);

            return movie;
        }

        public List<Movie> GetCachedMovies()
        {
            return dataCache.GetAllEntries();
        }

        public void PostCachedMovie(Movie movie)
        {
            CheckAndAdd(movie);
        }

        public void PutCachedMovie(string id, Movie movie)
        {
            if (dataCache.EntryExists(id))
            {
                dataCache.EditEntry(id, movie);
                movieData.EditDatabaseRecord(id, movie);
            }
            else
            {
                dataCache.AddNewEntry(movie);
                movieData.AddToDatabase(movie);
            }
        }

        public void DelCachedMovie(string id)
        {
            if (dataCache.EntryExists(id))
            {
                dataCache.DeleteEntry(id);
                movieData.DeleteDatabaseRecord(id);
            }
        }

        private void CheckAndAdd(Movie movie)
        {
            if (!dataCache.EntryExists(movie.imdbID))
            {
                dataCache.AddNewEntry(movie);
                movieData.AddToDatabase(movie);
            }
        }

    }
}
