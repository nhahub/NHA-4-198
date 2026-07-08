using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Configurations
{
    internal class CenterrequestConfigration : IEntityTypeConfiguration<Centerrequest>

    {
        void IEntityTypeConfiguration<Centerrequest>.Configure(EntityTypeBuilder<Centerrequest> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("CenterRequestId");

            builder.Property(c => c.CenterName)
                   .HasMaxLength(100)
                   .HasColumnName("CenterName")
                   .IsRequired();

            builder.Property(c => c.ContactPhone)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.Address)
                   .HasMaxLength(250);

            builder.Property(c => c.City)
                   .HasMaxLength(100);

            builder.Property(c => c.State)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(c => c.CreatedAt)
                   .IsRequired();

            builder.Property(c => c.ReviewedAt);

            builder.HasOne(c => c.ReviewedBy)
                   .WithMany()
                   .HasForeignKey(c => c.ReviewedById)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
