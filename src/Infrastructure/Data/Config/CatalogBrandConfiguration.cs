using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oyster.ApplicationCore.Entities;

namespace Oyster.Infrastructure.Data.Config;

public class CatalogBrandConfiguration : IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
           .UseHiLo("catalog_brand_hilo")
           .IsRequired();

        builder.Property(cb => cb.Brand)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.PictureUri)
            .IsRequired(false);

        builder.Property(ci => ci.BannerPictureUri)
           .IsRequired(false);

        builder.Property(ci => ci.Status)
          .IsRequired(true);
    }
}
