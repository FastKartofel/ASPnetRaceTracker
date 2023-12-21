using Microsoft.EntityFrameworkCore;

namespace RaceTrackingAPI.DAL
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarInRace> CarsInRaces { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<PartInCar> PartInCars { get; set; }

        public DbSet<Race> Races { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=RaceFinal;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarInRace>()
                .HasKey(c => new { c.IdCar, c.IdRace });

            modelBuilder.Entity<PartInCar>()
                .HasKey(p => new { p.IdPart, p.IdCar });
        }

    }
}
