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
            //TODO: SEED DATA Character, Movie & Franchise

            // modelBuilder.Entity<Character>().HasData(new Character { Id = 1, FullName = "Name Nameson", Alias = "Chad", Gender = "Male", PictureURL = "" });
            // modelBuilder.Entity<Character>().HasData(new Character { Id = 2, FullName = "Name Nameson", Alias = "Chad", Gender = "Male", PictureURL = "" });
            // modelBuilder.Entity<Character>().HasData(new Character { Id = 3, FullName = "Name Nameson", Alias = "Chad", Gender = "Male", PictureURL = "" });




        }
    }
}
