using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Backend.Data;
using Project_Backend.DTO;
using Project_Backend.Models;
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
        [Route("movies/{MovieId}")]
        
        public async Task<ActionResult<MovieService>> GetMovie(int MovieId)
        {
            try{
                return new OkObjectResult(await _movieService.GetMovie(MovieId));
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

        [HttpGet]
        [Route("director/{DirectorId}")]
        
        public async Task<ActionResult<MovieService>> GetDirector(int DirectorId)
        {
            try{
                return new OkObjectResult(await _movieService.GetDirector(DirectorId));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("movies")]
        public async Task<ActionResult<MoviesDTO>> AddMovie(MoviesDTO movie)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddMovie(movie));
            }
            catch(System.Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        

        [HttpDelete]
        [Route("movies/{MovieId}")]
        public async Task<ActionResult> DeleteMovie(int MovieId)
        {
            try{
                await _movieService.DeleteMovie(MovieId);
                return Ok();
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("director/{DirectorId}")]
        public async Task<ActionResult> DeleteDirector(int DirectorId)
        {
            try{
                await _movieService.DeleteDirector(DirectorId);
                return Ok();
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }


        [HttpPost]
        [Route("director")]
        public async Task<ActionResult<DirectorDTO>> AddDirector(DirectorDTO director)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddDirector(director));
            }
            catch(System.Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
