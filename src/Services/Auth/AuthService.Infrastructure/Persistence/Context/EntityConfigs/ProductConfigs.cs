using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Shipping).HasDefaultValue(false).IsRequired();
            builder.Property(p => p.VendorId).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        }
    }
}
