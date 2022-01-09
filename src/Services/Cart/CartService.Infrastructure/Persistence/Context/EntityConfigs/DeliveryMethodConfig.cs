using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class DeliveryMethodConfig : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");
            builder.HasKey(p => p.Id);
            builder.Property(dm => dm.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
