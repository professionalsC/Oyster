using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oyster.ApplicationCore.Entities;

namespace Oyster.Infrastructure.Data.Config;

public class CatalogGenderTypeConfiguration : IEntityTypeConfiguration<CatalogGenderType>
{
    public void Configure(EntityTypeBuilder<CatalogGenderType> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
           .UseHiLo("catalog_gender_type_hilo")
           .IsRequired();

        builder.Property(cb => cb.GenderType)
            .IsRequired()
            .HasMaxLength(100);
    }
}
