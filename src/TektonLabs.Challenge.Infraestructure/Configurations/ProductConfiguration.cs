using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Shared;

namespace TektonLabs.Challenge.Infraestructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .HasMaxLength(127);
        builder.Property(p => p.Description)
            .HasMaxLength(255);

        builder.Property(p => p.Stock);

        builder.Property(p => p.Status);

        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(pr => pr.CurrencyType)
            .HasConversion(ct => ct.Code, code => CurrencyType.FromCodigo(code!));
        });

    }
}
