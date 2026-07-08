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
    internal class SuperadminConfigration : IEntityTypeConfiguration<Superadmin>

    {
        void IEntityTypeConfiguration<Superadmin>.Configure(EntityTypeBuilder<Superadmin> builder)
        {
            builder.Property(s => s.Id)
               .HasColumnName("SuperAdminId");

            builder.Property(s => s.Name)
                .HasColumnName("SuperAdminName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasColumnName("SuperAdminEmail")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.PasswordHash)
                .HasColumnName("SuperAdminPassword")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.LastLogin)
                .HasColumnName("SuperAdminLastLogin");

            builder.Property(s => s.Status)
                .HasColumnName("SuperAdminStatus")
                .HasMaxLength(50);

            builder.Property(s => s.CreatedAt)
                .HasColumnName("SuperAdminCreatedAt")
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.centers)
                  .WithOne(s => s.VerifiedByAdmin)
                  .HasForeignKey(s => s.VerifiedBy)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}