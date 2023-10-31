using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<AIResponse> AIResponses { get; set; }
    }
}
