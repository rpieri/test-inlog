using InLogTest.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InLogTest.Repository.Mappings
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Chassis).HasColumnName("chassis").HasColumnName("varchar(250)").IsRequired();
            builder.Property(x => x.Color).HasColumnName("chassis").HasColumnName("varchar(50)").IsRequired();
            builder.Property(x => x.NumberOfPassagers).HasColumnName("numberPassagers").IsRequired();
            builder.Property(x => x.Type).HasColumnName("typeVehicle").IsRequired();
            builder.Property(x => x.Deleted).HasColumnName("deleted").HasDefaultValue(false);
            builder.Ignore(x => x.Notifications);
        }
    }
}
