using OMGApi.Data.Interfaces;
using OMGApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OMGApi.Data
{
    public class DataCache : IDataCache
    {

        private readonly List<Movie> movieCache;
        private readonly IMovieData movieData;

        public DataCache(IMovieData movieData)
        {
            movieCache = new List<Movie>();
            this.movieData = movieData;

            movieCache = this.movieData.GetAllMovies().ToList();
            
        }

        public void AddNewEntry(Movie movie)
        {
            if (movieCache.Any(val => val.imdbID == movie.imdbID))
            {
                throw new Exception("Movie allready in cache.");
            }
            else
            {
                movieCache.Add(movie);
            }
        }

        public void EditEntry(string id, Movie movie)
        {
            foreach(var _movie in movieCache.Where(val => val.imdbID == id))
            {
                _movie.imdbID = movie.imdbID;
                _movie.imdbRating = movie.imdbRating;
                _movie.imdbVotes = movie.imdbVotes;
                _movie.Title = movie.Title;
                _movie.Year = movie.Year;
                _movie.Rated = movie.Rated;
                _movie.Released = movie.Released;
                _movie.Runtime = movie.Runtime;
            }
        }

        public void DeleteEntry(string id)
        {
            movieCache.RemoveAll(val => val.imdbID == id);
        }

        public List<Movie> GetAllEntries()
        {
            return movieCache;
        }

        public bool EntryExists(string id)
        {
            return movieCache.Any(val => val.imdbID == id);
        }

    }
}
