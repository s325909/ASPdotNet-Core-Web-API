using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFranchiseWebAPI.Models;
using MovieFranchiseWebAPI.Models.DTO.Character;
using MovieFranchiseWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        // private readonly MovieFranchiseContext _context;
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;

        public CharactersController(IMapper mapper, ICharacterService characterService)
        {
            //_context = context;
            _mapper = mapper;
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()  
        {
            // return _mapper.Map<List<CharacterReadDTO>>
            //   (await _characterService.GetAllCharactersAsync());

            return _mapper.Map<List<CharacterReadDTO>>(
                await _characterService.GetAllCharactersAsync());

            /**
            return _mapper.Map<List<CharacterReadDTO>>(
                await _context.Characters
                .Include(c => c.Movies)
                .ToListAsync()
                );
            **/
        }

        [HttpGet("{id}")]
        public async Task<CharacterReadDTO> GetCharacter(int id)
        {

            /**

            var a = _mapper.Map<List<CharacterReadDTO>>(
                await _context.Characters
                .Include(c => c.Movies)
                .ToListAsync()
                )//.GetEnumerator(id);


           // var a = _mapper.Map<List<CharacterReadDTO>>(
               // await _context.Characters
                //.Include(c => c.Movies)
                //.Select(c => c.Id == id)
                //.Where(c => c.)
                //.Where(c => c.Movies.Equals(id))
                //.ToListAsync()
                //);
                return new()

            **/

            return new();
        }
    }
}
