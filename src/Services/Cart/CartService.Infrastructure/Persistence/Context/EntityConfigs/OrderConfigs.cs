using Decors.Domain.Entities;
using Decors.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class OrderConfigs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(p => p.Id);
            builder.Property(o => o.Subtotal)
                .HasColumnType("decimal(18, 2)");
           /* builder.OwnsOne(o => o.ShipToAddress, a => {
                a.WithOwner();
            });*/
            builder.Property(o => o.OrderStatus)
                .HasConversion(
                    s => s.ToString(), 
                    s => (OrderStatus) Enum.Parse(typeof(OrderStatus), s)
                );
        }
    }
}
