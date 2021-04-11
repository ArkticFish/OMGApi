using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OMGApi.Controllers;
using OMGApi.Logic.Interfaces;
using OMGApi.UnitTests.DummyClasses;
using OMGApi.UnitTests.DummyData;
using System;

namespace OMGApi.UnitTests.Layers.API
{
    [TestClass]
    public class CachedEntriesControllerTests
    {

        [TestMethod]
        public void CachedEntriesControllerTests_Get()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            CachedEntriesController cachedEntriesController = new CachedEntriesController(movieLogic);

            var movie = cachedEntriesController.Get();

            Console.WriteLine(JsonConvert.SerializeObject(movie));

        }

        [TestMethod]
        public void CachedEntriesControllerTests_Post()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            CachedEntriesController cachedEntriesController = new CachedEntriesController(movieLogic);

            cachedEntriesController.Post(DummyMovies.NewMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void CachedEntriesControllerTests_Put()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            CachedEntriesController cachedEntriesController = new CachedEntriesController(movieLogic);

            cachedEntriesController.Put("00000", DummyMovies.NewMovie);

            Console.WriteLine();

        }

        [TestMethod]
        public void CachedEntriesControllerTests_Delete()
        {

            IMovieLogic movieLogic = new DummyMovieLogic();

            CachedEntriesController cachedEntriesController = new CachedEntriesController(movieLogic);

            cachedEntriesController.Delete("00000");

            Console.WriteLine();

        }

    }
}
