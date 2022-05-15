using System;
using AnoxyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AnoxyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
    }
}

