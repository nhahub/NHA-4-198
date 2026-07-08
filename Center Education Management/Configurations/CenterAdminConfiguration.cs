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
    internal class CenterAdminConfiguration : IEntityTypeConfiguration<CenterAdmin>
    {
        void IEntityTypeConfiguration<CenterAdmin>.Configure(EntityTypeBuilder<CenterAdmin> builder)
        {
            builder.Property(c => c.Role)
       .HasConversion<string>();

            builder.Property(c => c.GrantedAt)
                   .IsRequired();

            builder.Property(c => c.IsActive)
                   .IsRequired();

            builder.HasOne(c => c.Center)
                   .WithMany(c => c.CenterAdmins)
                   .HasForeignKey(c => c.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.GrantedBy)
                   .WithMany(o => o.CenterAdmins)
                   .HasForeignKey(c => c.GrantedById)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
