using Microsoft.EntityFrameworkCore;
using PersistanceProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HesaplamaTeorisiProjesiDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AıReponse> AIResponses { get; set; }
    }
}
