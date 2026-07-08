using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configuration
{
    public class SubscriptionPlanConfiguration
        : IEntityTypeConfiguration<SubscriptionPlan>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            builder.ToTable("SubscriptionPlans");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("SubscriptionPlanId");


            builder.Property(x => x.Name)
                   .HasColumnName("SubscriptionPlanName")
                   .HasMaxLength(200);

            builder.Property(x => x.PriceMonthly)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.PriceYearly)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.PriceSemester)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.MaxStudents)
                   .IsRequired();

            builder.Property(x => x.MaxTeachers)
                   .IsRequired();

            builder.Property(x => x.MaxGroups)
                   .IsRequired();

            builder.Property(x => x.StorageGB)
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.HasMany(x => x.CenterSubscriptions)
                   .WithOne(x => x.Plan)
                   .HasForeignKey(x => x.PlanId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}