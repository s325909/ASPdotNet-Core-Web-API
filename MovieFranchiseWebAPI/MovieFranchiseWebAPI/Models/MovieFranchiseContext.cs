using Microsoft.EntityFrameworkCore;
using MovieFranchiseWebAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models
{
    public class MovieFranchiseContext : DbContext 
    {
        // dbSets act as tables for Characters, Movies and Franchises created in the database with EF
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public MovieFranchiseContext(DbContextOptions<MovieFranchiseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // dummy data class with list of characters, movies and franchises
            var mockData = new MovieFranchiseMockData();

            // seed dummy Franchise data to database table
            for (int i = 0; i < mockData.Franchises.Count; i++)
                modelBuilder.Entity<Franchise>().HasData(mockData.Franchises[i]);

            // seed dummy Movie data to database table
            for (int i = 0; i < mockData.Movies.Count; i++)
                modelBuilder.Entity<Movie>().HasData(mockData.Movies[i]);

            // seed dummy Character data to database table
            for (int i = 0; i < mockData.Characters.Count; i++)
                modelBuilder.Entity<Character>().HasData(mockData.Characters[i]);

            // seed m2m Movie-Character by accessing defined linking table with FK Ids
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity<Dictionary<string, object>>(
                "MovieCharacter",
                    rs => rs.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    ls => ls.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("MovieId", "CharacterId");
                        je.HasData(
                            // John Wick 1 Characters
                            new { MovieId = 1, CharacterId = 1 },
                            // Captain America TWS Characters
                            new { MovieId = 2, CharacterId = 3 },
                            new { MovieId = 2, CharacterId = 4 },
                            // Captain America CW Chracters
                            new { MovieId = 3, CharacterId = 2 },
                            new { MovieId = 3, CharacterId = 3 },
                            new { MovieId = 3, CharacterId = 4 },
                            new { MovieId = 3, CharacterId = 6 },
                            // Avangers Infinity War Characters
                            new { MovieId = 4, CharacterId = 2 },
                            new { MovieId = 4, CharacterId = 3 },
                            new { MovieId = 4, CharacterId = 4 },
                            new { MovieId = 4, CharacterId = 5 },
                            new { MovieId = 4, CharacterId = 6 }
                        );
                    }
                );
        }
    }
}
