using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oyster.ApplicationCore.Entities;

namespace Oyster.Infrastructure.Data.Config;

public class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
           .UseHiLo("catalog_type_hilo")
           .IsRequired();

        builder.Property(cb => cb.Type)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.PictureUri)
            .IsRequired(false);

        builder.Property(ci => ci.BannerPictureUri)
           .IsRequired(false);

        builder.Property(cb => cb.Description)
           .IsRequired()
           .HasMaxLength(int.MaxValue);

        builder.HasOne(ci => ci.ParentCatalogType)
            .WithMany()
            .HasForeignKey(ci => ci.ParentCatalogTypeId);
    }
}
