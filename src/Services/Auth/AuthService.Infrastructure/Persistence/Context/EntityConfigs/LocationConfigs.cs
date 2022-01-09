using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class LocationConfigs : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.Property(l => l.Latitude).HasColumnType("decimal(18, 4)");
            builder.Property(l => l.Longitude).HasColumnType("decimal(18, 4)");
        }
    }
}
