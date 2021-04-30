using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Backend.Data;
using Project_Backend.Models;

namespace Project_Backend.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> AddDirector(Director Director);
        
        Task<List<Director>> GetDirector();
    }
    public class DirectorRepository : IDirectorRepository
    {
        private IMovieContext _context;

        public DirectorRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Director>> GetDirector()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> AddDirector(Director director)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();
            return director;
        }
    }
}
