using Microsoft.EntityFrameworkCore;

namespace HealthSphere
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Patient> patients { get; set; } = null!;
        public DbSet<Doctor> doctors { get; set; } = null!;
        public DbSet<Specialization> specializations { get; set; } = null!;
        public DbSet<Records> records { get; set; } = null!;
        public DbSet<Times> times { get; set; } = null!;
        public DbSet<Mkb> mkb { get; set; } = null!;
        public DbSet<Appointment> appointments { get; set; } = null!;



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
