using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMGApi.Data;
using OMGApi.Data.Interfaces;
using OMGApi.UnitTests.DummyClasses;
using OMGApi.UnitTests.DummyData;
using System;

namespace OMGApi.UnitTests.Layers.Data
{
    [TestClass]
    public class MovieDataTests
    {

        [TestMethod]
        public void MovieDataTests_AddToDatabase()
        {

            IDatabaseComs databaseComs = new DummyDatabaseComs();
            IMovieData movieData = new MovieData(databaseComs);

            movieData.AddToDatabase(DummyMovies.SingleMovie);

            Console.WriteLine("");

        }

        [TestMethod]
        public void MovieDataTests_EditDatabaseRecord()
        {

            IDatabaseComs databaseComs = new DummyDatabaseComs();
            IMovieData movieData = new MovieData(databaseComs);

            movieData.EditDatabaseRecord("1", DummyMovies.SingleMovie);

            Console.WriteLine("");

        }

        [TestMethod]
        public void MovieDataTests_DeleteDatabaseRecord()
        {

            IDatabaseComs databaseComs = new DummyDatabaseComs();
            IMovieData movieData = new MovieData(databaseComs);

            movieData.DeleteDatabaseRecord("1");

            Console.WriteLine("");

        }

        [TestMethod]
        public void MovieDataTests_GetAllMovies()
        {

            IDatabaseComs databaseComs = new DummyDatabaseComs();
            IMovieData movieData = new MovieData(databaseComs);

            movieData.GetAllMovies();

            Console.WriteLine("");

        }


    }
}
