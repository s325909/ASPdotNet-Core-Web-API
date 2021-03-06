using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Franchise
{
    /// <summary>
    /// DTO used when fetching a Franchise
    /// </summary>
    public class FranchiseReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Movies { get; set; } 
    }
}
