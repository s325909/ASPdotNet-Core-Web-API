using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Movie
{
    /// <summary>
    /// DTO used when updating an existing Movie
    /// </summary>
    public class MovieEditDTO
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureURL { get; set; }
        public string TrailerURL { get; set; }
    }
}
