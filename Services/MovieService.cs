using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Backend.Models;
using Project_Backend.Repositories;

namespace Project_Backend.Services
{
    public interface IMovieService
    {
        Task<List<Movies>> GetMovies();
        Task<List<Director>> GetDirectors();
        
    }
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;

        private IDirectorRepository _directorReposity;

        public MovieService(IMovieRepository movieRepository, IDirectorRepository directorReposity)
        {
            _movieRepository = movieRepository;
            _directorReposity = directorReposity;
        }

        public async Task<List<Movies>> GetMovies()
        {
            return await _movieRepository.GetMovies();
        }

        public async Task<List<Director>> GetDirectors()
        {
            return await _directorReposity.GetDirector();
        }
    }
}
