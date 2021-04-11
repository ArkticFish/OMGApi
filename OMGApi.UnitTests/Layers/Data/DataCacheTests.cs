using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OMGApi.Data;
using OMGApi.Data.Interfaces;
using OMGApi.UnitTests.DummyClasses;
using OMGApi.UnitTests.DummyData;
using System;

namespace OMGApi.UnitTests.Layers.Data
{
    [TestClass]
    public class DataCacheTests
    {

        [TestMethod]
        public void DataCacheTests_AddNewEntry()
        {

            IMovieData movieData = new DummyMovieData();
            IDataCache dataCache = new DataCache(movieData);

            dataCache.AddNewEntry(DummyMovies.NewMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void DataCacheTests_AddOldEntry()
        {

            IMovieData movieData = new DummyMovieData();
            IDataCache dataCache = new DataCache(movieData);

            try
            {
                dataCache.AddNewEntry(DummyMovies.SingleMovie);
            }
            catch (Exception ex)
            {
                if (ex.Message != "Movie allready in cache.")
                    throw ex;
            }

            Console.WriteLine();

        }

        [TestMethod]
        public void DataCacheTests_EditEntry()
        {

            IMovieData movieData = new DummyMovieData();
            IDataCache dataCache = new DataCache(movieData);

            dataCache.EditEntry(DummyMovies.SingleMovie.imdbID, DummyMovies.SingleMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void DataCacheTests_DeleteMovie()
        {

            IMovieData movieData = new DummyMovieData();
            IDataCache dataCache = new DataCache(movieData);

            dataCache.DeleteEntry(DummyMovies.SingleMovie.imdbID);

            Console.WriteLine();

        }

        [TestMethod]
        public void DataCacheTests_GetAllEntries()
        {

            IMovieData movieData = new DummyMovieData();
            IDataCache dataCache = new DataCache(movieData);

            var movies = dataCache.GetAllEntries();

            Console.WriteLine(JsonConvert.SerializeObject(movies));

        }

    }
}
