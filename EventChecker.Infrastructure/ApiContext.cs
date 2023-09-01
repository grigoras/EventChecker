using EventChecker.Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EventChecker.Infrastructure
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
