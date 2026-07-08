using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("PaymentId");

            builder.Property(p => p.Amount)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(p => p.Method)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(p => p.GatewayRef)
                   .HasMaxLength(500);

            builder.Property(p => p.PaidAt)
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(p => p.Student)
                   .WithMany(s => s.Payments)
                   .HasForeignKey(p => p.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Center)
                   .WithMany(c => c.Payments)
                   .HasForeignKey(p => p.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Group)
                   .WithMany(g => g.Payments)
                   .HasForeignKey(p => p.GroupId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.RecordedByUser)
                    .WithMany()
                    .HasForeignKey(p => p.RecordedBy)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.PaymentGateway)
                   .WithMany(g => g.Payments)
                   .HasForeignKey(p => p.PaymentGatewayId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}