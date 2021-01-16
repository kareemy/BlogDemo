using System;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
        
        // STEP 1: Add DBSet<> to model for each entity class
        public DbSet<Blog> Blogs {get; set;}
        public DbSet<Post> Posts {get; set;}
    }
}