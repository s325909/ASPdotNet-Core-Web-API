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

        // MovieService depends on the DbContextc, thus freeing up the Controller for code implementation
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
