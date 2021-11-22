using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class DatabaseContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interest>().HasKey(interest => interest.IdInterest);
            modelBuilder.Entity<Job>().HasKey(job => job.IdJob);
        }
        
        
    }
}