using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Infrastructure.Mapping
{
    public class SchedulingMapping : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.ToTable("SCHEDULING");
            builder.HasKey(e => e.Key);
            builder.Property(e => e.Key)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEY");

            builder.OwnsOne(
                    e => e.TotalHours,
                    e =>
                    {
                        e.Property(e => e.hours)
                            .HasColumnName("TOTAL_HOURS")
                            .HasColumnType("int");
                    });

            builder.HasOne(e => e.Vehicle)
                .WithMany()
                .HasForeignKey("VEHICLEKEY");

            builder.HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey("CLIENTEKEY");
        }
    }
}
