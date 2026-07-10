using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Configurations
{
    internal class CenterSubscriptionConfiguration : IEntityTypeConfiguration<Centersubscription>
    {
        public void Configure(EntityTypeBuilder<Centersubscription> builder)
        {
          
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("CenterSubscriptionId");

           
            builder.HasOne(c => c.Center)
                   .WithMany(c => c.Subscriptions)
                   .HasForeignKey(c => c.CenterId)
                   .OnDelete(DeleteBehavior.Cascade);

          
            builder.HasOne(c => c.Plan)
                   .WithMany(p => p.CenterSubscriptions)
                   .HasForeignKey(c => c.PlanId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(c => c.ApprovedByAdmin)
                   .WithMany()
                   .HasForeignKey(c => c.ApprovedBy)
                   .OnDelete(DeleteBehavior.NoAction);

            
            builder.Property(c => c.Status)
                   .HasConversion<string>();

            builder.Property(c => c.BillingCycle)
                   .HasConversion<string>();

            
            builder.Property(c => c.StartsAt)
                   .IsRequired();

            builder.Property(c => c.EndsAt)
                   .IsRequired();

            builder.Property(c => c.ApprovedAt);
        }
    }
}
