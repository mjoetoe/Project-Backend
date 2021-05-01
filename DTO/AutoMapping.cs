using System;
using AutoMapper;
using Project_Backend.Models;
namespace Project_Backend.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping(){

            CreateMap<Movies,MoviesDTO>();
            CreateMap<Director,DirectorDTO>();
        }
    }
}
