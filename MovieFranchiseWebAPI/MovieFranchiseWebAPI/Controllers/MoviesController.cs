using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFranchiseWebAPI.Models.Domain;
using MovieFranchiseWebAPI.Models.DTO.Character;
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
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesController(IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        /// <summary>
        /// Fetches all Movies from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies() 
        {
            return _mapper.Map<List<MovieReadDTO>>(
                await _movieService.GetAllMoviesAsync());
        }

        /// <summary>
        /// Adds a new Movie to the database
        /// </summary>
        /// <param name="dtoMovie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MovieReadDTO>> PostCharacter(MovieCreateDTO dtoMovie)
        {
            var domainMovie = _mapper.Map<Movie>(dtoMovie);

            domainMovie = await _movieService.AddMovieAsync(domainMovie);

            string uri = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                + HttpContext.Request.Path + "/" + domainMovie.Id;

            return Created(uri, _mapper.Map<MovieReadDTO>(domainMovie));
        }

        /// <summary>
        /// Fetches a specific Movie from the database by their id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var movie = await _movieService.GetSpecificMovieAsync(id);

            if (movie == null)
                return NotFound($"Movie with id: {id} was not found");

            return _mapper.Map<MovieReadDTO>(movie);
        }

        /// <summary>
        /// Updates a Movie in the database by their id; 
        /// must pass in an updated Movie object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoMovie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO dtoMovie)
        {
            if (id != dtoMovie.Id)
                return BadRequest("Invalid MovieId");

            if (!_movieService.MovieExists(id))
                return NotFound($"Movie with id: {id} was not found");

            var domainMovie = _mapper.Map<Movie>(dtoMovie);
            await _movieService.UpdateMovieAsync(domainMovie);

            return Ok($"Updated Movie with id: {id}");
        }

        /// <summary>
        /// Deletes a Movie in the database by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieReadDTO>> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
                return NotFound($"Movie with id: {id} was not found");

            await _movieService.DeleteMovieAsync(id);

            return Ok($"Deleted Movie with id: {id}");
        }


        /// <summary>
        /// Fetches all Characters related to a Movie by Id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetMovieCharacters(int id)
        {
            if (!_movieService.MovieExists(id))
                return NotFound($"Movie with id: {id} was not found");

            return _mapper.Map<List<CharacterReadDTO>>(
                await _movieService.GetMovieCharactersAsync(id));
        }

        /// <summary>
        /// Updates characters of a Movie in the database by their id; 
        /// must pass in an updated list of character Ids
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
        [HttpPatch("{id}/characters")]
        public async Task<IActionResult> PatchMovieCharacters(int id, List<int> characterIds) 
        {
            if (!_movieService.MovieExists(id))
                return NotFound($"Movie with id: {id} was not found");
            try
            {
                await _movieService.UpdateMovieChractersAsync(id, characterIds);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            string characters = " ";
            characterIds.ForEach(m => characters += $"{m}, ");
            return Ok($"Patch-updated Character(s) [{characters}] for Movie with id: {id}");
        }

        /// <summary>
        /// Updates Franchise of a Movie in the database by their id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        [HttpPatch("{id}/franchise")]
        public async Task<IActionResult> PatchMovieFranchise(int id, int franchiseId) 
        {
            if (!_movieService.MovieExists(id))
                return NotFound($"Movie with id: {id} was not found");
            try
            {
                await _movieService.UpdateMovieFranchiseAsync(id, franchiseId);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok($"Patch-updated Franchise [{franchiseId}] for Movie with id: {id}");
        }
    }
}
