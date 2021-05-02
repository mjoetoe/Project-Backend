using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Backend.DTO;
using Project_Backend.Models;
using Project_Backend.Repositories;
using AutoMapper;
namespace Project_Backend.Services
{
    public interface IMovieService
    {
        Task<Movies> GetMovie(int MovieId);
        Task<List<Movies>> GetMovies();
        Task<MoviesDTO> AddMovie(MoviesDTO Movie);

        Task DeleteMovie(int MovieId);

        Task<List<Director>> GetDirectors();
        Task<Director> GetDirector(int DirectorId);
        Task<DirectorDTO> AddDirector(DirectorDTO director);

        Task DeleteDirector(int DirectorId);

    }
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;

        private IDirectorRepository _directorReposity;

        private IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IDirectorRepository directorReposity , IMapper mapper)
        {
            _movieRepository = movieRepository;
            _directorReposity = directorReposity;
            _mapper = mapper;
        }

        public async Task DeleteMovie(int MovieId)
        {
            try
            {
                await _movieRepository.DeleteMovie(MovieId);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Movies>> GetMovies()
        {
            return await _movieRepository.GetMovies();
        }

        public async Task<List<Director>> GetDirectors()
        {
            return await _directorReposity.GetDirectors();
        }
        public async Task<Movies> GetMovie(int MovieId)
        {
            try
            {
                return await _movieRepository.GetMovie(MovieId);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Director> GetDirector(int DirectorId)
        {
            try
            {
                return await _directorReposity.GetDirector(DirectorId);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteDirector(int DirectorId)
        {
            try
            {
                await _directorReposity.DeleteDirector(DirectorId);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MoviesDTO> AddMovie(MoviesDTO Movie)
        {
            try
            {
                Movies newMovie = _mapper.Map<Movies>(Movie);
                await _movieRepository.AddMovie(newMovie);
                return Movie;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DirectorDTO> AddDirector(DirectorDTO director)
        {
            try
            {
                Director newDirector = _mapper.Map<Director>(director);
                await _directorReposity.AddDirector(newDirector);
                return director;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    
    
    }
}
