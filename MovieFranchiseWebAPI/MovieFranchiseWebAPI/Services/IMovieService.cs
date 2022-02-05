using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetSpecificMovieAsync(int id);
        public Task<Movie> AddMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie);
        public Task DeleteMovieAsync(int id);
        public Task UpdateMovieChractersAsync(int movieId, List<int> characterIds);
        public Task UpdateMovieFranchiseAsync(int movieId, int franchiseId); 
        public bool MovieExists(int id);  
    }
}
