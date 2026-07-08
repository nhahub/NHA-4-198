using Center_Education_Management.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Configurations
{
    internal class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        void IEntityTypeConfiguration<Center>.Configure(EntityTypeBuilder<Center> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("CenterID");

            builder.Property(c => c.Name)
                .HasColumnName("CenterName")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.Slug)
                .IsUnique();

            builder.Property(c => c.Slug)
                .HasMaxLength(250)
                .HasColumnName("CenterSlug");

            builder.Property(c => c.Status)
                .HasColumnName("CenterStatus")
                .HasConversion<string>();

            builder.Property(c => c.Description)
                    .HasMaxLength(1000);

            builder.Property(c => c.LogoUrl)
                   .HasMaxLength(500);

            builder.Property(c => c.Address)
                   .HasMaxLength(250);

            builder.Property(c => c.City)
                   .HasMaxLength(100);

            builder.Property(c => c.Phone)
                   .HasMaxLength(20);

            builder.Property(c => c.CreatedAt)
                    .IsRequired();

            builder.Property(c => c.UpdatedAt)
                   .IsRequired();

            builder.HasOne(s => s.VerifiedByAdmin)
                .WithMany(c => c.centers)
                .HasForeignKey(s => s.VerifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Owner)
                .WithOne(c => c.center)
                .HasForeignKey<Center>(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
