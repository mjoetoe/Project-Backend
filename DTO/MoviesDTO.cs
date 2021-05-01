using System;

namespace Project_Backend.DTO
{
    public class MoviesDTO
    {
        public int MoviesId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
