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
            // Character --> CharacterDTO
            CreateMap<Character, CharacterDTO>()
                // turning related movies into int array
                .ForMember(cdto => cdto.Movies, opt => opt
                .MapFrom(c => c.Movies.Select(m => m.Id).ToArray()));
            // CharacterCreateDTO --> Character
            CreateMap<CharacterCreateDTO, Character>();
        }


    }
}
