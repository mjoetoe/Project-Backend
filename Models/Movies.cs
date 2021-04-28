using System;

namespace Project_Backend.Models
{
    public class Movies
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid DirectorId { get; set; }
    }
}
