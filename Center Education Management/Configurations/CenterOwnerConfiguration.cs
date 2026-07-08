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
    internal class CenterOwnerConfiguration : IEntityTypeConfiguration<CenterOwner>
    {
        void IEntityTypeConfiguration<CenterOwner>.Configure(EntityTypeBuilder<CenterOwner> builder)
        {
            builder.Property(c => c.OwnershipType)
                   .HasConversion<string>();

            builder.Property(c => c.SubscriptionStatus)
                   .HasConversion<string>();

            builder.Property(c => c.DefaultPaymentMethod)
                   .HasConversion<string>();

            builder.Property(c => c.JoinedAt)
                   .IsRequired();
        }
    }
}
