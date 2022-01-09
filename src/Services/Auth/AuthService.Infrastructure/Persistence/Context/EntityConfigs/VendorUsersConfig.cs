using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class VendorUsersConfig : IEntityTypeConfiguration<VendorUsers>
    {
        public void Configure(EntityTypeBuilder<VendorUsers> builder)
        {
            builder.ToTable("VendorUsers");

            builder.HasKey(vu => new { vu.VendorId, vu.UserId });
        }
    }
}
