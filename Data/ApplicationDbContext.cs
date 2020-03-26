using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<project.Models.Homes> Homes { get; set; }
        public DbSet<project.Models.Bidding> Bidding { get; set; }
        public DbSet<project.Models.Broker> Broker { get; set; }
        public DbSet<project.Models.Demonstration> Demonstration { get; set; }
        public DbSet<project.Models.Image> Image { get; set; }
        public DbSet<project.Models.Persons> Persons { get; set; }
     

    }
}
