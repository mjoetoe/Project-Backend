using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Backend.Data;
using Project_Backend.Models;

namespace Project_Backend.Repositories
{
    public interface IMovieRepository
    {
        Task<Movies> AddMovie(Movies Movie);
        
        Task<List<Movies>> GetMovies();
    }
    public class MovieRepository : IMovieRepository
    {
        private IMovieContext _context;

        public MovieRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Movies>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movies> AddMovie(Movies movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
