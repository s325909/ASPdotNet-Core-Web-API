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
        // Primary Key (Autoincremented Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Fields
        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long!")]
        public string Name { get; set; }

        [MaxLength(125, ErrorMessage = "Description can only be 125 characters long!")]
        public string Description { get; set; }

        // Relationships
        public ICollection<Movie> Movies { get; set; } 
    }
}
