using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tickets.DataAccess.Models;

namespace Tickets.DataAccess.EntityFramework
{
    public partial class ModDbContext : DbContext
    {
        private readonly string SqlConnectionString;
        public ModDbContext(string sqlConnectionString)
        {
            SqlConnectionString = sqlConnectionString;
        }

        public ModDbContext(DbContextOptions<ModDbContext> options) : base(options) { }
        public virtual DbSet<Ticket> Ticket { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.SqlConnectionString,
                    builder => builder.EnableRetryOnFailure());
            }
        }
    }
}
