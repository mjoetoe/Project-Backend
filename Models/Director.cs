using System;
using System.Collections.Generic;

namespace Project_Backend.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public List<DirectorMovies> DirectorMovies {get;set;}
    }
}
