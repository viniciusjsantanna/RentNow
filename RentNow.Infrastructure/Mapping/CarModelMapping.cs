using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentNow.Domain.Entities;
using System;

namespace RentNow.Infrastructure.Mapping
{
    public class CarModelMapping : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.ToTable("CAR_MODEL");
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

            builder.HasOne(e => e.CarBrand)
                .WithMany()
                .HasForeignKey("CAR_BRAND_KEY");
        }
    }
}
