using Microsoft.EntityFrameworkCore;
using MovieFranchiseWebAPI.Models;
using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieFranchiseContext _context;

        // FranchiseService depends on the DbContextc, thus freeing up the Controller for code implementation
        public FranchiseService(MovieFranchiseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds new Franchise to DbSet of Franchises and updates the database.
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }

        /// <summary>
        /// Deletes a Franchise from DbSet of Franchises and updates the database. 
        /// Finds the Franchise by using FindAsync(id) on DbSet of Franchises.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            var franchiseMovies = _context.Movies
                .Where(m => m.FranchiseId == id);

            foreach (var movie in franchiseMovies)
                movie.FranchiseId = null;

            _context.Franchises.Remove(franchise);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if id exists in DbSet of Franchises
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(f => f.Id == id); 
        }

        /// <summary>
        /// Gets all franchises from DbSet of Franchises while also including a list of Movie Ids
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
        {
            return await _context.Franchises
               .Include(f => f.Movies)
               .ToListAsync();
        }

        /// <summary>
        /// Get list of all characters related to a Movie in a Franchise by id from DbSet of Movies
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Character>> GetFranchiseCharactersAsync(int franchiseId)
        {
            var franchiseMovies = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.FranchiseId == franchiseId)
                .ToListAsync();

            var franciseCharacters = new List<Character>();
            foreach (var movie in franchiseMovies)
            {
                foreach (var character in movie.Characters.ToList())
                {
                    if (!franciseCharacters.Contains(character))
                        franciseCharacters.Add(character);
                }
            }

            /**
            var franchiseMovieCharacters = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.FranchiseId == franchiseId)
                .Select(m => m.Characters.ToList())
                .FirstOrDefaultAsync();
            // return franchiseMovieCharacters;
            **/

            return franciseCharacters;
        }

        /// <summary>
        /// Get list of all movies related to a Franchise by id from DbSet of Franchises
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetFranchiseMoviesAsync(int franchiseId)
        {
            var franchise = await GetSpecificFranchiseAsync(franchiseId);

            return franchise.Movies.ToList();
        }

        /// <summary>
        /// Gets a specific Franchise from DbSet of Franchises while also including list of Movie Ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Franchise> GetSpecificFranchiseAsync(int id)
        {
            return await _context.Franchises
                   .Include(f => f.Movies)
                   .SingleOrDefaultAsync(f => f.Id == id);
        }

        /// <summary>
        /// Updates Franchise from DbSet of Franchises.
        /// Provides entry access to change tracking information and operations of the Franchise 
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
