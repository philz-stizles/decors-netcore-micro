using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class VendorConfigs : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendors");

            builder.HasMany(v => v.Users)
                .WithOne(vu => vu.Vendor);
        }
    }
}
