using Decors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decors.Infrastructure.Persistence.Context.EntityConfigs
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsMain)
                .HasColumnName("is_main")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(p => p.IsMain)
                .IsRequired();
        }
    }
}
