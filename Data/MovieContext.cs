using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project_Backend.Configuration;
using Project_Backend.Models;

namespace Project_Backend.Data
{
    public class MovieContext: DbContext
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
            modelBuilder.Entity<Movies>().HasData(new Movies(){
                ID = Guid.NewGuid(), Name = "Titanic" , Genre="Romance"
            });
            modelBuilder.Entity<Movies>().HasData(new Movies(){
                ID = Guid.NewGuid(), Name = "The Martian" , Genre="Sci-Fi"
            });

            modelBuilder.Entity<Director>().HasData(new Director(){
                ID = Guid.NewGuid(), Name = "Steven" , LastName = "Spielberg" , Age = 25 
            });

            modelBuilder.Entity<Director>().HasData(new Director(){
                ID = Guid.NewGuid(), Name = "Christopher" , LastName = "Nolan" , Age = 50 
            });

            modelBuilder.Entity<DirectorMovies>().HasNoKey();

        }
    }
}
