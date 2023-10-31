using AIService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIService.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AıResponse> AIResponses { get; set; }
}