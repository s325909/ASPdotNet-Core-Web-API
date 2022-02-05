using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Franchise
{
    /// <summary>
    /// DTO used when updating an existing Franchise
    /// </summary>
    public class FranchiseEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
