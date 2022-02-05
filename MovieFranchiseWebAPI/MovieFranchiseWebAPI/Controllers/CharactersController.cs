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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO dtoCharacter)
        {
            if (id != dtoCharacter.Id)
                return BadRequest("Invalid CharacterId");

            if (!_characterService.CharacterExists(id))
                return NotFound($"Character with id: {id} was not found");

            var domainCharacter = _mapper.Map<Character>(dtoCharacter);
            await _characterService.UpdateCharacterAsync(domainCharacter);

            return Ok($"Updated Character with id: {id}");
        }

        [HttpPost]
        public async Task<ActionResult<CharacterReadDTO>> PostCharacter(CharacterCreateDTO dtoCharacter)
        {
            var domainCharacter = _mapper.Map<Character>(dtoCharacter);

            domainCharacter = await _characterService.AddCharacterAsync(domainCharacter);
            
            string uri = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                + HttpContext.Request.Path + "/" + domainCharacter.Id;

            return Created(uri, _mapper.Map<CharacterReadDTO>(domainCharacter));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetSpecificCharacterAsync(id);

            if (character == null)
                return NotFound($"Character with id: {id} was not found");

            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("{id}/movies")]
        public async Task<IActionResult> PatchCharacterMovies(int id, List<int> movies)
        {
            if (!_characterService.CharacterExists(id))
                return NotFound($"Character with id: {id} was not found");
            try
            {
                await _characterService.UpdateCharacterMoviesAsync(id, movies);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            string movieIds = " ";
            movies.ForEach(m => movieIds += $"{m}, ");
            return Ok($"Patched Movie(s) [{movieIds}] for Character with id: {id}");
        }
    }
}
