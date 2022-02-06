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
                Id = 1,
                Name = "John Wick",
                Description = "John Wick is an American neo-noir action-thriller media franchise created by screenwriter Derek Kolstad and starring Keanu Reeves as John Wick, a former hitman who is forced back into the criminal underworld he abandoned."
            },
            new Franchise()
            {
                Id = 2,
                Name = "The Marvel Cinematic Universe",
                Description = "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios."
            }
        };

        public readonly List<Movie> Movies = new()
        {
            new Movie()
            {
                Id = 1,
                FranchiseId = 2,
                Tittle = "Captain America: The First Avenger",
                Genre = "Action, Crime, Drama, Thriller",
                ReleaseYear = 2011,
                Director = "Joe Johnston",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMTYzOTc2NzU3N15BMl5BanBnXkFtZTcwNjY3MDE3NQ@@._V1_FMjpg_UX1000_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=JerVrbLldXw"
            },
            new Movie()
            {
                Id = 2,
                FranchiseId = 2,
                Tittle = "Captain America: The Winter Soldier",
                Genre = "Action, Drama, Romace",
                ReleaseYear = 2014,
                Director = "Anthony Russo, Joe Russo",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=tbayiPxkUMM"
            },
            new Movie()
            {
                Id = 3,
                FranchiseId = 2,
                Tittle = "Captain America: Civil War",
                Genre = "Action, Drama",
                ReleaseYear = 2016,
                Director = "Anthony Russo, Joe Russo",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=tbayiPxkUMM"
            },
            new Movie()
            {
                Id = 4,
                FranchiseId = 2,
                Tittle = "Avengers: Infinity War",
                Genre = "Action, Comedy, Drama, Romance",
                ReleaseYear = 2018,
                Director = "Anthony Russo, Joe Russo",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=QwievZ1Tx-8"
            },
            new Movie()
            {
                Id = 5,
                FranchiseId = 1,
                Tittle = "John Wick: Chapter 4",
                Genre = "Action, Crime, Drama, Thriller",
                ReleaseYear = 2023,
                Director = "Chad Stahelski",
                PictureURL = "https://filmyhotspot.com/wp-content/uploads/2020/12/39e611e5-870c-4c6d-97a1-e7c9ee51a97b.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=gy31U2bvVGU"
            },
            new Movie()
            {
                Id = 6,
                FranchiseId = 1,
                Tittle = "John Wick: Chapter 3",
                Genre = "Action, Mystery, thriller",
                ReleaseYear = 2019,
                Director = "Chad Stahelski",
                PictureURL = "https://www.the-rampage.org/wp-content/uploads/2019/06/268x0w.png",
                TrailerURL = "https://www.youtube.com/watch?v=M7XM597XO94"
            },
            new Movie()
            {
                Id = 7,
                FranchiseId = 1,
                Tittle = "John Wick: Chapter 2",
                Genre = "Action, Drama",
                ReleaseYear = 2017,
                Director = "Chad Stahelski",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMjE2NDkxNTY2M15BMl5BanBnXkFtZTgwMDc2NzE0MTI@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=XGk2EfbD_Ps"
            },
            new Movie()
            {
                Id = 8,
                FranchiseId = 1,
                Tittle = "John Wick (2014)",
                Genre = "Action, Crime, Drama, Thriller, Tragedy",
                ReleaseYear = 2014,
                Director = "Chad Stahelski",
                PictureURL = "https://m.media-amazon.com/images/M/MV5BMTU2NjA1ODgzMF5BMl5BanBnXkFtZTgwMTM2MTI4MjE@._V1_.jpg",
                TrailerURL = "https://www.youtube.com/watch?v=2AUmvWm5ZDQ"
            },
        };

        public readonly List<Character> Characters = new()
        {
            new Character()
            {
                Id = 1,
                FullName = "John Wick",
                Alias = "Baba Yaga",
                Gender = "Male",
                PictureURL = "https://static1.colliderimages.com/wordpress/wp-content/uploads/2021/03/john-wick-keanu-reeves-social-1.jpg",
            },
            new Character()
            {
                Id = 2,
                FullName = "Tony Stark",
                Alias = "Iron Man",
                Gender = "Male",
                PictureURL = "https://img.joomcdn.net/dace9a3da47d7d748e13af43f96344a4449c7688_original.jpeg",
            },
            new Character()
            {
                Id = 3,
                FullName = "Steve Rogers",
                Alias = "Captain America",
                Gender = "Male",
                PictureURL = "https://static.wikia.nocookie.net/marvel-cinematic/images/3/32/Steve_Rogers_2.jpg/revision/latest?cb=20131025030358",
            },
            new Character()
            {
                Id = 4,
                FullName = "Natasha Romanoff",
                Alias = "Black Widow",
                Gender = "Female",
                PictureURL = "https://pbs.twimg.com/media/FC-HLpbWUAI4UCa.jpg",
            },
            new Character()
            {
                Id = 5,
                FullName = "Bruce Banner",
                Alias = "The Incredible Hulk",
                Gender = "Male",
                PictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg/200px-Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg",
            },
            new Character()
            {
                Id = 6,
                FullName = "Peter Parker",
                Alias = "Spider-Man",
                Gender = "Male",
                PictureURL = "https://www.koimoi.com/wp-content/new-galleries/2021/12/new-spider-man-trilogy-to-witness-tom-hollands-peter-parker-in-college-001.jpg",
            },
        };
    }
}
