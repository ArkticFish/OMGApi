using Newtonsoft.Json;
using OMGApi.Logic.Interfaces;
using OMGApi.Models;
using OMGApi.UnitTests.DummyData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMGApi.UnitTests.DummyClasses
{
    public class DummyMovieLogic : IMovieLogic
    {
        public void DelCachedMovie(string id)
        {
            Console.WriteLine(id);
        }

        public List<Movie> GetCachedMovies()
        {
            return DummyMovies.ListOfMovies;
        }

        public void PostCachedMovie(Movie movie)
        {
            Console.WriteLine(JsonConvert.SerializeObject(movie));
        }

        public void PutCachedMovie(string id, Movie movie)
        {
            Console.WriteLine(id + " - " + JsonConvert.SerializeObject(movie));
        }

        public Task<Movie> SearchMoviesByID(string id)
        {
            return Task.FromResult(DummyMovies.SingleMovie);
        }

        public Task<Movie> SearchMoviesByTitle(string title)
        {
            return Task.FromResult(DummyMovies.SingleMovie);
        }

        public Task<Movie> SearchMoviesByTitle(string title, string year)
        {
            return Task.FromResult(DummyMovies.SingleMovie);
        }
    }
}
