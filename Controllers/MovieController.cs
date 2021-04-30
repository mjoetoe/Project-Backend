using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Backend.Services;

namespace Project_Backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet]
        [Route("movies")]
        
        public async Task<ActionResult<List<MovieService>>> GetMovies()
        {
            try{
                return new OkObjectResult(await _movieService.GetMovies());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("director")]
        
        public async Task<ActionResult<List<MovieService>>> GetDirectors()
        {
            try{
                return new OkObjectResult(await _movieService.GetDirectors());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }
    }
}
