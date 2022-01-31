using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Models
{
    public class MovieFranchiseContext : DbContext 
    {
        public MovieFranchiseContext(DbContextOptions<MovieFranchiseContext> options) : base(options)
        {

        }

    }
}
