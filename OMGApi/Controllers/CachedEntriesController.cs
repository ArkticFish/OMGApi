using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OMGApi.Logic.Interfaces;
using OMGApi.Models;
using System.Collections.Generic;

namespace OMGApi.Controllers
{
    [Route("cachedEntries")]
    [ApiController]
    public class CachedEntriesController : ControllerBase
    {

        private readonly IMovieLogic moviesLogic;

        public CachedEntriesController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }

        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Movie> Get()
        {
            return moviesLogic.GetCachedMovies();
        }

        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            moviesLogic.PostCachedMovie(movie);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Movie movie)
        {
            moviesLogic.PutCachedMovie(id, movie);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            moviesLogic.DelCachedMovie(id);
        }

    }
}
