using System;
using System.Collections.Generic;

namespace Project_Backend.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<DirectorMovies> DirectorMovies {get;set;}
    }
}
