using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Character
{
    /// <summary>
    /// DTO used when fetching a Character
    /// </summary>
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureURL { get; set; }
        public List<int> Movies { get; set; } 
    }
}
