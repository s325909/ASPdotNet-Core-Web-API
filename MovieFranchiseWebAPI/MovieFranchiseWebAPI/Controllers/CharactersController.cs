using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFranchiseWebAPI.Models;
using MovieFranchiseWebAPI.Models.Domain;
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
            return _mapper.Map<List<CharacterReadDTO>>(
                await _characterService.GetAllCharactersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetSpecificCharacterAsync(id);

            if (character == null)
                return NotFound($"Character with id: {id} was not found");

            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, CharacterEditDTO dtoCharacter)
        {
           if (id != dtoCharacter.Id)
               return BadRequest("Invalid CharacterId");

            if (!_characterService.CharacterExists(id))
                return NotFound($"Character with id: {id} was not found");

            var domainCharacter = _mapper.Map<Character>(dtoCharacter);
            await _characterService.UpdateCharacterAsync(domainCharacter);

            return NoContent();
        }
    }
}
