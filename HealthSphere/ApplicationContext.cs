using Microsoft.EntityFrameworkCore;

namespace HealthSphere
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Patient> patients { get; set; } = null!;
        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HealthSphere;Username=postgres;Password=12345678");
        }
    }
}
