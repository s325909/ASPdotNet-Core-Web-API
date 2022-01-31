using AutoMapper;
using MovieFranchiseWebAPI.Models.Domain;
using MovieFranchiseWebAPI.Models.DTO.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Profiles
{
    public class CharacterProfile : Profile 
    {
        public CharacterProfile()
        {
            // Character --> CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>()
                // turning related movies into int array
                .ForMember(cdto => cdto.Movies, opt => opt
                .MapFrom(c => c.Movies.Select(c => c.Id).ToArray()));
            // CharacterDTO --> Character
            CreateMap<CharacterDTO, Character>();
        }


    }
}
