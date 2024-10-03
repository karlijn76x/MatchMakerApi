using MatchMakerApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchMakerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
     
    }
}
