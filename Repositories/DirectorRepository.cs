using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Backend.Data;
using Project_Backend.Models;

namespace Project_Backend.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> AddDirector(Director Director);
        
        Task<List<Director>> GetDirectors();

        Task<Director> GetDirector(int DirectorId);

        Task DeleteDirector(int DirectorId);

    }
    public class DirectorRepository : IDirectorRepository
    {
        private IMovieContext _context;

        public DirectorRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Director>> GetDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> AddDirector(Director director)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<Director> GetDirector(int DirectorId)
        {
            return await _context.Directors.Where(d => d.DirectorId == DirectorId).SingleOrDefaultAsync();
        }

        public async Task DeleteDirector(int DirectorId)
        {
            var director = _context.Directors.Where(d => d.DirectorId == DirectorId).SingleOrDefault();
            if(director != null)
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
        }
    }
}
