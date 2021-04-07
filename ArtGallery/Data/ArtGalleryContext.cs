using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ArtGallery.Data
{
    public class ArtGalleryContext :IdentityDbContext
    {
        public ArtGalleryContext()
        {

        }

        public ArtGalleryContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Account> Account { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Following> Following { get; set; }
        
        public DbSet<Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ArtGalleryDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
