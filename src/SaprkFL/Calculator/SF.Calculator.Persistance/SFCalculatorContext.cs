using Microsoft.EntityFrameworkCore;

namespace SF.Calculator.Persistence
{
    public class SFCalculatorContext : DbContext
    {
        public virtual DbSet<Test> Item { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host = postgresdb; port = 5432; database = sf; password = password; username = user");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(e =>
            {
                e.ToTable("test");
                e.Property(p => p.Id).HasColumnName("id");
            });
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Test
    {
        public int Id { get; set; }
    }
}