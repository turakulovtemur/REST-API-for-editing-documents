using Microsoft.EntityFrameworkCore;
using TestRestApiApp.Models;

namespace TestRestApiApp.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder
                .Entity<Document>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
