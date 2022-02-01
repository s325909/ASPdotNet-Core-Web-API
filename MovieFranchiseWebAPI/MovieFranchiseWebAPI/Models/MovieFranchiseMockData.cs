using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models
{
    public class MovieFranchiseMockData 
    {
        public readonly List<Franchise> Franchises = new()   
        {
            new Franchise()
            {
                Name = "John Wick",
                Description = "John Wick is an American neo-noir action-thriller media franchise created by screenwriter Derek Kolstad and starring Keanu Reeves as John Wick, a former hitman who is forced back into the criminal underworld he abandoned."
            },
            new Franchise()
            {
                Name = "The Marvel Cinematic Universe",
                Description = "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios."
            }
        };

        public readonly List<Movie> Movies= new()  
        {
            new Movie()
            {
                Tittle = "John Wick: Chapter 4",
                Genre = "Action, Crime, Drama, Thriller",
                ReleaseYear = 2023,
                Director = "Derek Kolstad",
                PictureURL = "https://filmyhotspot.com/wp-content/uploads/2020/12/39e611e5-870c-4c6d-97a1-e7c9ee51a97b.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=gy31U2bvVGU"
            },
            new Movie()
            {
                Tittle = "Captain America: The Winter Soldier",
                Genre = "Action, Drama, Romace",
                ReleaseYear = 2014,
                Director = "Russo",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=tbayiPxkUMM"
            },
            new Movie()
            {
                Tittle = "Captain America: Civil War",
                Genre = "Action, Drama",
                ReleaseYear = 2016,
                Director = "Russo",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=tbayiPxkUMM"
            },
            new Movie()
            {
                Tittle = "Avengers: Infinity War",
                Genre = "Action, Comedy, Drama, Romance",
                ReleaseYear = 2018,
                Director = "Russo",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=QwievZ1Tx-8"
            }
        };

        public readonly List<Character> Characters = new()
        {
            new Character()
            {
                FullName = "John Wick",
                Alias = "Baba Yaga",
                Gender = "Male",
                PictureURL = "https://static1.colliderimages.com/wordpress/wp-content/uploads/2021/03/john-wick-keanu-reeves-social-1.jpg",
            },
            new Character()
            {
                FullName = "Tony Stark",
                Alias = "Iron Man",
                Gender = "Male",
                PictureURL = "https://img.joomcdn.net/dace9a3da47d7d748e13af43f96344a4449c7688_original.jpeg",
            },
            new Character()
            {
                FullName = "Steve Rogers",
                Alias = "Captain America",
                Gender = "Male",
                PictureURL = "https://static.wikia.nocookie.net/marvel-cinematic/images/3/32/Steve_Rogers_2.jpg/revision/latest?cb=20131025030358",
            },
            new Character()
            {
                FullName = "Natasha Romanoff",
                Alias = "Black Widow",
                Gender = "Female",
                PictureURL = "https://pbs.twimg.com/media/FC-HLpbWUAI4UCa.jpg",
            },
            new Character()
            {
                FullName = "Bruce Banner",
                Alias = "Hulk",
                Gender = "Male",
                PictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg/200px-Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg",
            },
            new Character()
            {
                FullName = "Peter Parker",
                Alias = "Spider-Man",
                Gender = "Male",
                PictureURL = "https://www.koimoi.com/wp-content/new-galleries/2021/12/new-spider-man-trilogy-to-witness-tom-hollands-peter-parker-in-college-001.jpg",
            },
        };
    }
}
