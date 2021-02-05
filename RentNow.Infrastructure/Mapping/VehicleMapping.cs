using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentNow.Domain.Entities;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Infrastructure.Mapping
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("VEHICLE");
            builder.HasKey(e => e.Key);
            builder.Property(e => e.Key)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEY");

            builder.OwnsOne(
                e => e.Plate,
                e =>
                {
                    e.Property(e => e.plate)
                        .HasColumnName("PLATE")
                        .HasColumnType("varchar(8)");
                });

            builder.OwnsOne(
                e => e.Year,
                e =>
                {
                    e.Property(e => e.year)
                        .HasColumnName("YEAR")
                        .HasColumnType("int");
                });

            builder.OwnsOne(
                e => e.HourPrice,
                e =>
                {
                    e.Property(e => e.hourPrice)
                        .HasColumnName("HOUR_PRICE")
                        .HasColumnType("money");
                });

            builder.OwnsOne(
                e => e.TrunkLimit,
                e =>
                {
                    e.Property(e => e.trunkLimit)
                        .HasColumnName("TRUNK_LIMIT")
                        .HasColumnType("int");
                });

            builder.Property(e => e.Fuel)
                .HasConversion<int>()
                .HasColumnName("FUEL");

            builder.Property(e => e.Category)
                .HasConversion<int>()
                .HasColumnName("CATEGORY");

            builder.HasOne(e => e.CarModel)
                .WithMany()
                .HasForeignKey("CAR_MODEL_KEY");

        }
    }
}
