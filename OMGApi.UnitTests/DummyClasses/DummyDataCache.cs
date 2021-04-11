using Newtonsoft.Json;
using OMGApi.Data.Interfaces;
using OMGApi.Models;
using OMGApi.UnitTests.DummyData;
using System;
using System.Collections.Generic;

namespace OMGApi.UnitTests.DummyClasses
{
    public class DummyDataCache : IDataCache
    {
        public void AddNewEntry(Movie movie)
        {
            Console.WriteLine(JsonConvert.SerializeObject(movie));
        }

        public void DeleteEntry(string id)
        {
            Console.WriteLine(id);
        }

        public void EditEntry(string id, Movie movie)
        {
            Console.WriteLine(id + " - " + JsonConvert.SerializeObject(movie));
        }

        public bool EntryExists(string id)
        {
            if (id == "00000")
                return true;
            else
                return false;
        }

        public List<Movie> GetAllEntries()
        {
            return DummyMovies.ListOfMovies;
        }
    }
}
