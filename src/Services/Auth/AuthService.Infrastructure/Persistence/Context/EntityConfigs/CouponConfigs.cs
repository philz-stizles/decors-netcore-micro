using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class CouponConfigs : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupons");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Discount)
                .IsRequired();

            // Vendor one-to-one r/ship.
            builder.HasOne(c => c.Vendor)
            .WithMany(v => v.Coupons)
            .HasForeignKey(c => c.VendorId);
        }
    }
}
