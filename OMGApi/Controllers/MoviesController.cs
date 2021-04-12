using Microsoft.AspNetCore.Mvc;
using OMGApi.Logic.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OMGApi.Controllers
{
    [ApiController]
    [Route("OMDbMovies")]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieLogic moviesLogic;

        public MoviesController(IMovieLogic moviesLogic)
        {
            this.moviesLogic = moviesLogic;
        }

        [HttpGet]
        [Route("searchTitle/{title}")]
        public async Task<IActionResult> SearchTitle(string title)
        {
            return Ok(await moviesLogic.SearchMoviesByTitle(title));
        }

        [HttpGet]
        [Route("searchTitle/{title}/{year}")]
        public async Task<IActionResult> SearchTitleAndYear(string title, string year)
        {
            return Ok(await moviesLogic.SearchMoviesByTitle(title, year));
        }

        [HttpGet]
        [Route("searchID/{id}")]
        public async Task<IActionResult> SearchID(string id)
        {
            return Ok(await moviesLogic.SearchMoviesByID(id));
        }

    }
}
