using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TektonLabs.Challenge.Domain.Products;

namespace TektonLabs.Challenge.Infraestructure.Configurations;
internal sealed class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
{
    public void Configure(EntityTypeBuilder<StatusType> builder)
    {

        builder.ToTable(nameof(StatusType));
        builder.HasKey(p => p.Code);

        builder.Property(p => p.Code)
          .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .HasMaxLength(64);
    }
}
