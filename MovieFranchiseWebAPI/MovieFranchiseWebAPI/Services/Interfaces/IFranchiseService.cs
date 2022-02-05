using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Services
{
    public interface IFranchiseService
    {
        public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        public Task<Franchise> GetSpecificFranchiseAsync(int id);
        public Task<Franchise> AddFranchiseAsync(Franchise franchise);
        public Task UpdateFranchiseAsync(Franchise franchise);
        public Task DeleteFranchiseAsync(int id); 
        public bool FranchiseExists(int id); 
    }
}
