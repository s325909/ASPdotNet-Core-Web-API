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

        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
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
           // return await _context.Characters
             //   .Include(c => c.Movies)
               // .ToListAsync();

            return await _context.Characters
            .Include(c => c.Movies)
            .ToListAsync();
        }

        public async Task<Character> GetSpecificCharacterAsync(int id)
        {
            //await _context.Characters
              //  .Include(c => c.Movies);

            return await _context.Characters
                .FindAsync(id);
                //.Include(c => c.Movies)
        }

        public async Task UpdateCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCharacterMoviesAsync(int characterId, List<int> movies)
        {
            throw new NotImplementedException();
        }
    }
}
