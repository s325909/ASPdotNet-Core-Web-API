using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Franchise
{
    /// <summary>
    /// DTO used when creating a new Franchise
    /// </summary>
    public class FranchiseCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
