using Microsoft.EntityFrameworkCore;
using MovieFranchiseWebAPI.Models;
using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieFranchiseContext _context;

        // CharacterService depends on the DbContextc, thus freeing up the Controller for code implementation
        public CharacterService(MovieFranchiseContext context)
        {
            _context = context;
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public bool CharacterExists(int id)
        {
            return _context.Characters.Any(c => c.Id == id);
        }

        /// <summary>
        /// uses FindAsync(id) on dBContext to find a charater, remove it, and update the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCharacterAsync(int id)
        {
            var Character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(Character);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets all character from dBContext while also including list of movie ids
        /// </summary>
        /// <returns>list of characters</returns>
        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _context.Characters
            .Include(c => c.Movies)
            .ToListAsync();
        }

        /// <summary>
        /// get specific chracter from dBContext while also including list of movie ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Character> GetSpecificCharacterAsync(int id)
        {
            return await GetCharacterAsync(id);
        }

        /// <summary>
        /// provides entry access to change tracking information & operations of a character 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public async Task UpdateCharacterAsync(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// updates list of movie ids for a character by id
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        public async Task UpdateCharacterMoviesAsync(int characterId, List<int> movieIds)
        {
            var character = await GetCharacterAsync(characterId);

            character.Movies = await GetCharacterMoviesAsync(movieIds);

            await _context.SaveChangesAsync();
        }

        private async Task<Character> GetCharacterAsync(int characterId)
        {
            return await _context.Characters
                .Include(c => c.Movies)
                .SingleOrDefaultAsync(c => c.Id == characterId);
        }

        private async Task<List<Movie>> GetCharacterMoviesAsync(List<int> movieIds)
        {
            var movies = new List<Movie>();
            foreach (int movieId in movieIds)
            {
                var movie = await _context.Movies.FindAsync(movieId);
                if (movie == null)
                    throw new KeyNotFoundException($"Record of Movie with id: {movieId} does not exist");
                movies.Add(movie);
            }
            return movies;
        }
    }

}
