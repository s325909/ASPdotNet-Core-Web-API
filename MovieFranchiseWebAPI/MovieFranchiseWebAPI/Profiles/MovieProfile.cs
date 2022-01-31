using AutoMapper;
using MovieFranchiseWebAPI.Models.Domain;
using MovieFranchiseWebAPI.Models.DTO.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Profiles
{
    public class MovieProfile : Profile 
    {
        public MovieProfile()
        {
            // Movie --> MovieReadDTO
            CreateMap<Movie, MovieReadDTO>()
                // turning related characters into int array
                .ForMember(mdto => mdto.Characters, opt => opt
                .MapFrom(m => m.Characters.Select(m => m.Id).ToArray()))
                // (int) Franchise <--> FranchiseId
                .ForMember(mdto => mdto.Franchise, opt => opt
                .MapFrom(m => m.FranchiseId))
                .ReverseMap();
            // MovieDTO --> Movie
            CreateMap<MovieDTO, Movie>(); 
        }
    }
}
