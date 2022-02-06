using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFranchiseWebAPI.Models.Domain;
using MovieFranchiseWebAPI.Models.DTO.Character;
using MovieFranchiseWebAPI.Models.DTO.Franchise;
using MovieFranchiseWebAPI.Models.DTO.Movie;
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
    public class FranchisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFranchiseService _franchiseService; 

        public FranchisesController(IMapper mapper, IFranchiseService franchiseService)
        {
            _mapper = mapper;
            _franchiseService = franchiseService;
        }

        /// <summary>
        /// Fetches all Franchises from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises() 
        {
            return _mapper.Map<List<FranchiseReadDTO>>(
                await _franchiseService.GetAllFranchisesAsync());
        }

        /// <summary>
        /// Adds a new Franchise to the database
        /// </summary>
        /// <param name="dtoFranchise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FranchiseReadDTO>> PostFranchise(FranchiseCreateDTO dtoFranchise) 
        {
            var domainFranchise = _mapper.Map<Franchise>(dtoFranchise);

            domainFranchise = await _franchiseService.AddFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise", new { id = domainFranchise.Id },
                _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        /// <summary>
        /// Fetches a specific Franchise from the database by their Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetSpecificFranchiseAsync(id);

            if (franchise == null)
                return NotFound($"Franchise with Id: {id} was not found");

            return _mapper.Map<FranchiseReadDTO>(franchise); 
        }

        /// <summary>
        /// Updates a Franchise in the database by their Id; 
        /// must pass in an updated Franchise object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoFranchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDTO dtoFranchise)
        {
            if (id != dtoFranchise.Id)
                return BadRequest("Invalid Franchise Id");

            if (!_franchiseService.FranchiseExists(id))
                return NotFound($"Franchise with Id: {id} was not found");

            var domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            await _franchiseService.UpdateFranchiseAsync(domainFranchise);

            return Ok($"Updated Franchise with Id: {id}");
        }

        /// <summary>
        /// Deletes a Franchise in the database by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> DeleteFranchise(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
                return NotFound($"Franchise with id: {id} was not found");

            await _franchiseService.DeleteFranchiseAsync(id);

            return Ok($"Deleted Franchise with id: {id}");
        }

        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetFranchiseMovies(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
                return NotFound($"Franchise with Id: {id} was not found");

            return _mapper.Map<List<MovieReadDTO>>(
                await _franchiseService.GetFranchiseMoviesAsync(id));
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetFranchiseCharacters(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
                return NotFound($"Franchise with Id: {id} was not found");

            return _mapper.Map<List<CharacterReadDTO>>(
                await _franchiseService.GetFranchiseCharactersAsync(id));
        }
    }
}