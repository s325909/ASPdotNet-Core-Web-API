using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Services
{
    /// <summary>
    /// essentially a repository for Character that follows the same pattern
    /// </summary>
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetAllCharactersAsync();
        public Task<Character> GetSpecificCharacterAsync(int id);
        public Task<Character> AddCharacterAsync(Character character);
        public Task UpdateCharacterAsync(Character character);
        public Task DeleteCharacterAsync(int id);
        public Task UpdateCharacterMoviesAsync(int characterId, List<int> movieIds);
        public bool CharacterExists(int id);
    }
}
