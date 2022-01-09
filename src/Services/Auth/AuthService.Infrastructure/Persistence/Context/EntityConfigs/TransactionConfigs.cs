using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class TransactionConfigs : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.Property(t => t.Amount).HasColumnType("decimal(18, 2)").IsRequired();
        }
    }
}
