using AnaAna.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnaAna.Data
{
    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Result> Results { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder builder)
    {
            //builder.Entity<Poll>().HasQueryFilter(x => !x.IsPrivate);
            base.OnModelCreating(builder);
    }
    }
}
