using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Character
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureURL { get; set; }
        public List<int> Movies { get; set; } 
    }
}
