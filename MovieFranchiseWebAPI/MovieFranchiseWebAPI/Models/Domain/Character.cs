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
        // Primary Key
        public int Id { get; set; }
        // Fields
        [Required]
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureURL { get; set; } 
    }
}
