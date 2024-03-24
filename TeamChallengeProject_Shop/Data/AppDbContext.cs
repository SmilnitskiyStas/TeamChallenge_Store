using Microsoft.EntityFrameworkCore;
using TeamChallengeProject_Shop.Models;

namespace TeamChallengeProject_Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
    }
}
