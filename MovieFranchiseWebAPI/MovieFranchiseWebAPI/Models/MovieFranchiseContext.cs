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

            // seed dummy Character data to database table
            for (int i = 0; i < mockData.Characters.Count; i++)
                modelBuilder.Entity<Character>().HasData(mockData.Characters[i]);

            // seed dummy Movie data to database table
            for (int i = 0; i < mockData.Movies.Count; i++)
                modelBuilder.Entity<Movie>().HasData(mockData.Movies[i]);

            // seed dummy Franchise data to database table
            for (int i = 0; i < mockData.Franchises.Count; i++)
                modelBuilder.Entity<Franchise>().HasData(mockData.Franchises[i]);    


            // seed m2m movie-character; need to define m2m and access linking table
            /**
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacter",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "CoachId");
                        je.HasData(
                            new {}
                            );
                    }
                );
            **/


        }
    }
}
