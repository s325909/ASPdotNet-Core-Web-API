using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.Domain
{
    [Table("Character")]
    public class Character
    {
        // Primary Key (Autoincremented Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Fields
        [Required]
        [MaxLength(50, ErrorMessage = "Full name can only be 50 characters long!")]
        public string FullName { get; set; }

        [MaxLength(50, ErrorMessage = "Alias can only be 50 characters long!")]
        public string Alias { get; set; }

        [MaxLength(50, ErrorMessage = "Gender can only be 50 characters long!")]
        public string Gender { get; set; }

        [MaxLength(250, ErrorMessage = "Picture URL can only be 250 characters long!")]
        public string PictureURL { get; set; }

        //Relationships
        public ICollection<Movie> Movies { get; set; } 
    }
}
