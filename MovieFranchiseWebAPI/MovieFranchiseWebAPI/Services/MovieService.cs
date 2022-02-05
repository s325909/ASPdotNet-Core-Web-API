using Microsoft.EntityFrameworkCore;
using MovieFranchiseWebAPI.Models;
using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieFranchiseContext _context;

        // MovieService depends on the DbContextc, thus freeing up the Controller for code implementation
        public MovieService(MovieFranchiseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds new Movie to DbSet of Movies and updates the database.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        /// <summary>
        /// Deletes a Movie from DbSet of Movies and updates the database. 
        /// Finds the Movie by using FindAsync(id) on DbSet of Movies.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all movies from DbSet of Movies while also including list of Character Ids
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
               .Include(m => m.Characters)
               .ToListAsync();
        }

        /// <summary>
        /// Gets a specific Movie from DbSet of Characters while also including list of Character Ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetSpecificMovieAsync(int id)
        {
            return await GetMovieAsync(id);
        }

        /// <summary>
        /// Checks if id exists in DbSet of Movies
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }

        /// <summary>
        /// Updates Movie from DbSet of Movies.
        /// Provides entry access to change tracking information and operations of the Movie 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates Movie from DbSet of Movies with list of Character Ids.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
        public async Task UpdateMovieChractersAsync(int movieId, List<int> characterIds)
        {
            var movie = await GetMovieAsync(movieId); 

            movie.Characters = await GetMovieCharactersAsync(characterIds);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieFranchiseAsync(int movieId, int franchiseId)
        {
            var movie = await GetMovieAsync(movieId);

            var franchise = await _context.Franchises.FindAsync(franchiseId);
            movie.Franchise = franchise ?? throw new KeyNotFoundException($"Record of Franchise with id: {franchiseId} does not exist");

            await _context.SaveChangesAsync();
        }

        private async Task<Movie> GetMovieAsync(int movieId)
        {
            return await _context.Movies
                   .Include(m => m.Characters)
                   .SingleOrDefaultAsync(m => m.Id == movieId);
        }

        private async Task<List<Character>> GetMovieCharactersAsync(List<int> characterIds)
        {
            var characters = new List<Character>();
            foreach (int characterId in characterIds)
            {
                var character = await _context.Characters.FindAsync(characterId);
                if (character == null)
                    throw new KeyNotFoundException($"Record of Character with id: {characterId} does not exist");
                characters.Add(character);
            }
            return characters;
        }
    }
}
