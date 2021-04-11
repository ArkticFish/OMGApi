using Newtonsoft.Json;
using OMGApi.Data.Interfaces;
using OMGApi.Models;
using OMGApi.UnitTests.DummyData;
using System;
using System.Collections.Generic;

namespace OMGApi.UnitTests.DummyClasses
{
    public class DummyMovieData : IMovieData
    {
        public void AddToDatabase(Movie movie)
        {
            Console.WriteLine(JsonConvert.SerializeObject(movie));
        }

        public void DeleteDatabaseRecord(string id)
        {
            Console.WriteLine(id);
        }

        public void EditDatabaseRecord(string id, Movie movie)
        {
            Console.WriteLine(id + " - " + JsonConvert.SerializeObject(movie));
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return DummyMovies.ListOfMovies;
        }
    }
}
