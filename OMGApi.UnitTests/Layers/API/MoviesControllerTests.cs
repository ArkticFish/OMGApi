using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OMGApi.Controllers;
using OMGApi.Logic.Interfaces;
using OMGApi.UnitTests.DummyClasses;
using System;

namespace OMGApi.UnitTests.Layers.API
{
    [TestClass]
    public class MoviesControllerTests
    {

        [TestMethod]
        public void MoviesControllerTests_SearchTitle()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            MoviesController moviesController = new MoviesController(movieLogic);

            var movie = moviesController.SearchTitle("").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void MoviesControllerTests_SearchTitleAndYear()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            MoviesController moviesController = new MoviesController(movieLogic);

            var movie = moviesController.SearchTitleAndYear("", "").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void MoviesControllerTests_SearchID()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            MoviesController moviesController = new MoviesController(movieLogic);

            var movie = moviesController.SearchID("").Result;

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

    }
}
