using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Movie
{
    /// <summary>
    /// DTO used when creating a new Movie
    /// </summary>
    public class MovieCreateDTO
    {
        public string Tittle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureURL { get; set; }
        public string TrailerURL { get; set; }
    }
}
