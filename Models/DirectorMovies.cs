using System;

namespace Project_Backend.Models
{
    public class DirectorMovies
    {
        public int MoviesId { get; set; }

        public int DirectorId { get; set; }

        public Director Director { get; set; }

        public Movies Movies { get; set; }
    }
}
