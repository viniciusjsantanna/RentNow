using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Infrastructure.Mapping
{
    public class CredentialsMapping : IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            builder.ToTable("CREDENTIALS");
            builder.HasKey(e => e.Key);
            builder.Property(e => e.Key)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEY");

            builder.Property(e => e.Login)
                .HasColumnName("LOGIN")
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar(200)");
        } 
    }
}
