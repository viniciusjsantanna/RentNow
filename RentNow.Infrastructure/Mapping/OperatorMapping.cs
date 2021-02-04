using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Infrastructure.Mapping
{
    public class OperatorMapping : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("OPERATOR");
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
               });

            builder.OwnsOne(
               e => e.Registration,
               e =>
               {
                   e.Property(e => e.registration)
                       .HasColumnName("REGISTRATION")
                       .HasColumnType("varchar(6)");
               });

            builder.Property(e => e.Role)
                .HasConversion<string>()
                .HasColumnName("ROLE");

            builder.HasOne(e => e.Credentials)
                .WithOne()
                .HasForeignKey<Operator>(e => e.Key);
        }
    }
}
