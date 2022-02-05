using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models.DTO.Character
{
    /// <summary>
    /// DTO used when creating a new Character
    /// </summary>
    public class CharacterCreateDTO 
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureURL { get; set; }
    }
}
