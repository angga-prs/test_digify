using Microsoft.EntityFrameworkCore;
using DigifyAPI.Models;
using System.Collections.Generic;

namespace DigifyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CompanyRegistration> CompanyRegistration { get; set; }
    }
}
