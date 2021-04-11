using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OMGApi.Data.Interfaces;
using OMGApi.Logic;
using OMGApi.Logic.Interfaces;
using OMGApi.UnitTests.DummyClasses;
using OMGApi.UnitTests.DummyData;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMGApi.UnitTests.Layers.Logic
{
    [TestClass]
    public class MovieLogicTests
    {

        [TestMethod]
        public void MovieLogicTests_SearchMoviesByID()
        {

            IOMDbConnection omdbConnection  = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            var movie = movieLogic.SearchMoviesByID("00000").Result;

            Console.WriteLine("");

        }

        [TestMethod]
        public void MovieLogicTests_SearchMoviesByTitle()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            var movie = movieLogic.SearchMoviesByTitle("Movie1").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void MovieLogicTests_SearchMoviesByTitleAndYear()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            var movie = movieLogic.SearchMoviesByTitle("Movie1", "1990").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void MovieLogicTests_GetCachedMovies()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            var movies = movieLogic.GetCachedMovies();

            Console.WriteLine(JsonConvert.SerializeObject(movies));

        }

        [TestMethod]
        public void MovieLogicTests_PostCachedMovie()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            movieLogic.PostCachedMovie(DummyMovies.NewMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void MovieLogicTests_PutCachedMovieExisting()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            movieLogic.PutCachedMovie("00000", DummyMovies.NewMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void MovieLogicTests_PutCachedMovieNew()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            movieLogic.PutCachedMovie("00002", DummyMovies.NewMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void MovieLogicTests_DelCachedMovie()
        {

            IOMDbConnection omdbConnection = new DummyOMDbCon();
            IDataCache dataCache = new DummyDataCache();
            IMovieData movieData = new DummyMovieData();

            IMovieLogic movieLogic = new MovieLogic(omdbConnection, dataCache, movieData);

            movieLogic.DelCachedMovie("00000");

            Console.WriteLine();

        }

    }
}
