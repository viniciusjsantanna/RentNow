using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentNow.Domain.Entities;
using RentNow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Infrastructure.Mapping
{
    public class CarBrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("CAR_BRAND");
            builder.HasKey(e => e.Key);
            builder.Property(e => e.Key)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEY");

            builder.OwnsOne(
                    e => e.Name,
                    e =>
                    {
                        e.Property(e => e.name)
                            .HasColumnName("NAME")
                            .HasColumnType("varchar(100)");
                    }
                );
        }
    }
}
