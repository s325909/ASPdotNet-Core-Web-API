using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.Domain
{
    [Table("Movie")]
    public class Movie
    {
        // Primary Key (Autoincremented Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Fields
        [Required]
        [MaxLength(50, ErrorMessage = "Tittle can only be 50 characters long!")]
        public string Tittle { get; set; }

        [MaxLength(75, ErrorMessage = "Genre can only be 75 characters long!")]
        public string Genre { get; set; }

        [MaxLength(4), MinLength(4)]
        public int ReleaseYear { get; set; }

        [MaxLength(50, ErrorMessage = "Director can only be 50 characters long!")]
        public string Director { get; set; }

        [MaxLength(175, ErrorMessage = "Picture URL can only be 175 characters long!")]
        public string PictureURL { get; set; }

        [MaxLength(175, ErrorMessage = "Trailer URL can only be 175 characters long!")]
        public string TrailerURL { get; set; }

        // Relationships
        public int? FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        public ICollection<Character> Characters { get; set; } 
    }
}
