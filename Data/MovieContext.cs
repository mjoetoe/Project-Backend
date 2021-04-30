using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project_Backend.Configuration;
using Project_Backend.Models;

namespace Project_Backend.Data
{

    public interface IMovieContext
    {
        DbSet<Movies> Movies { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<DirectorMovies> DirectorMovies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    public class MovieContext: DbContext, IMovieContext
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        public DbSet<DirectorMovies> DirectorMovies { get; set; }

        private ConnectionStrings _connectionStrings;

        public MovieContext(DbContextOptions<MovieContext> options, IOptions<ConnectionStrings> connectionStrings):base(options)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(LoggerFactory.Create(UriBuilder => UriBuilder.AddDebug()));
            options.UseSqlServer(_connectionStrings.SQL);
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            List<Movies> movies = new List<Movies>(){
                new Movies(){
                    MoviesId = 1,
                    Name = "Titanic",
                    Genre = "Romance"
                },
                new Movies(){
                    MoviesId = 2,
                    Name = "The Martian",
                    Genre = "Sci-Fi"
                }
            };

            List<Director> directors = new List<Director>(){
                new Director(){
                    DirectorId = 1,
                    Name = "Steven",
                    LastName = "Spielberg",
                    Age = 25,
                },
                new Director(){
                     DirectorId = 2, 
                     Name = "Christopher", 
                     LastName = "Nolan", 
                     Age = 50 
                }
            };
            
            List<DirectorMovies> directorMovies = new List<DirectorMovies>(){
                new DirectorMovies(){
                    DirectorId = directors[0].DirectorId,
                    MoviesId = movies[0].MoviesId,
                },
                new DirectorMovies(){
                    DirectorId = directors[1].DirectorId,
                    MoviesId = movies[1].MoviesId,
                }
            };

            modelBuilder.Entity<DirectorMovies>().HasKey(cs => new {cs.MoviesId , cs.DirectorId});
            modelBuilder.Entity<Director>().HasData(directors);
            modelBuilder.Entity<Movies>().HasData(movies);
            modelBuilder.Entity<DirectorMovies>().HasData(directorMovies);
        }
    }
}
