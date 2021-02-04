using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Infrastructure.Mapping
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("CLIENT");
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
                e => e.Cpf,
                e =>
                {
                    e.Property(e => e.cpf)
                        .HasColumnName("CPF")
                        .HasColumnType("varchar(11)");
                });

            builder.OwnsOne(
                e => e.Address,
                e =>
                {
                    e.ToTable("ADDRESS");
                    e.Property(e => e.Street)
                        .HasColumnName("STREET")
                        .HasColumnType("varchar(200)");

                    e.Property(e => e.Postcode)
                        .HasColumnName("POSTCODE")
                        .HasColumnType("varchar(10)");

                    e.Property(e => e.Number)
                        .HasColumnName("NUMBER")
                        .HasColumnType("varchar(50)");

                    e.Property(e => e.Complement)
                        .HasColumnName("COMPLEMENT")
                        .HasColumnType("varchar(300)");

                    e.Property(e => e.City)
                        .HasColumnName("CITY")
                        .HasColumnType("varchar(100)");

                    e.Property(e => e.State)
                        .HasColumnName("STATE")
                        .HasColumnType("varchar(20)");

                    e.HasKey("Street", "Postcode", "Number", "City", "State", "ClientKey");
                });

            builder.Property(e => e.Birthdate)
                .HasColumnName("BIRTHDATE");

            builder.Property(e => e.Role)
                .HasConversion<string>()
                .HasColumnName("ROLE");

            builder.HasOne(e => e.Credentials)
                           .WithOne()
                           .HasForeignKey<Client>(e => e.Key);
        }
    }
}
