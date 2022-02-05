﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;

        public CharactersController(IMapper mapper, ICharacterService characterService)
        {
            //_context = context;
            _mapper = mapper;
            _characterService = characterService;
        }

        /// <summary>
        /// Fetches all Characters from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()  
        {
            return _mapper.Map<List<CharacterReadDTO>>(
                await _characterService.GetAllCharactersAsync());
        }

        /// <summary>
        /// Adds a new Character to the database
        /// </summary>
        /// <param name="dtoCharacter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CharacterReadDTO>> PostCharacter(CharacterCreateDTO dtoCharacter)
        {
            var domainCharacter = _mapper.Map<Character>(dtoCharacter);

            domainCharacter = await _characterService.AddCharacterAsync(domainCharacter);
            
            string uri = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                + HttpContext.Request.Path + "/" + domainCharacter.Id;

            return Created(uri, _mapper.Map<CharacterReadDTO>(domainCharacter));
        }

        /// <summary>
        /// Fetches a specific Character from the database by their id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetSpecificCharacterAsync(id);

            if (character == null)
                return NotFound($"Character with id: {id} was not found");

            return _mapper.Map<CharacterReadDTO>(character);
        }

        /// <summary>
        /// Updates a Character in the database by their id; 
        /// must pass in an updated Character object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoCharacter"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes a Character in the database by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> DeleteCharacter(int id) 
        {
            if (!_characterService.CharacterExists(id))
                return NotFound($"Character with id: {id} was not found");

            await _characterService.DeleteCharacterAsync(id);

            return Ok($"Deleted Character with id: {id}");
        }

        /// <summary>
        /// Updates movies of a Character in the database by their id; 
        /// must pass in an updated list of movie Ids
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        [HttpPatch("{id}/movies")]
        public async Task<IActionResult> PatchCharacterMovies(int id, List<int> movieIds)
        {
            if (!_characterService.CharacterExists(id))
                return NotFound($"Character with id: {id} was not found");
            try
            {
                await _characterService.UpdateCharacterMoviesAsync(id, movieIds);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            string movies = " ";
            movieIds.ForEach(m => movies += $"{m}, ");
            return Ok($"Patch-updated Movie(s) [{movies}] for Character with id: {id}");
        }
    }
}
