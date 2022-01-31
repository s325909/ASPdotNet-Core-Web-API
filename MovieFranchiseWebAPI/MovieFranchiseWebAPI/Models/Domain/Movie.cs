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
        // Primary Key
        public int Id { get; set; }
        // Fields
        [Required] 
        public string Tittle { get; set; }
        public string Genre { get; set; }
        [MaxLength(4), MinLength(4)]
        public int ReleaseYear { get; set; }
        public string DirectorName { get; set; } 
        public string PictureURL { get; set; }
        public string TrailerURL { get; set; }

    }
}
