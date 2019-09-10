using InLogTest.Domain.Vehicles;
using InLogTest.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InLogTest.Repository.Contexts
{
    public class EntityContext : DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public void ExecuteMigrate() => Database.Migrate();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseSetting.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
