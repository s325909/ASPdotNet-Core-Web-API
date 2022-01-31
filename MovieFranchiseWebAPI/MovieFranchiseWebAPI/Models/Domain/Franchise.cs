using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.Domain
{
    [Table("Franchise")]
    public class Franchise
    {
        // Primary Key
        public int Id { get; set; }
        // Fields
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
