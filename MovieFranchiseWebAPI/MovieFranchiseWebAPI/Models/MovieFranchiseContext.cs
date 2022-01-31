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

    }
}
