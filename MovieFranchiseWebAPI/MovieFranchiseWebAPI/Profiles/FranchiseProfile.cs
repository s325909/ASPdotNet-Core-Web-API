using AutoMapper;
using MovieFranchiseWebAPI.Models.Domain;
using MovieFranchiseWebAPI.Models.DTO.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Profiles
{
    public class FranchiseProfile : Profile 
    {
        public FranchiseProfile()
        {
            // Franchise --> FranchiseReadDTO
            CreateMap<Franchise, FranchiseReadDTO>()
                // turning related movies into int array
                .ForMember(fdto => fdto.Movies, opt => opt
                .MapFrom(f => f.Movies.Select(m => m.Id).ToArray()));
            // FranchiseDTO --> Franchise
            CreateMap<FranchiseDTO, Franchise>();
        }
    }
}
