using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configuration
{
    public class PaymentGatewayConfiguration
        : IEntityTypeConfiguration<Paymentgetway>
    {
        public void Configure(EntityTypeBuilder<Paymentgetway> builder)
        {
            builder.ToTable("Paymentgetways");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id)
              .HasColumnName("PaymentGatewayId");

            builder.Property(x => x.Provider)
                   .IsRequired();

            builder.Property(x => x.Credentials)
                   .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Center)
                   .WithMany(c => c.PaymentGateways)
                   .HasForeignKey(x => x.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Owner)
                   .WithMany(o => o.PaymentGateways)
                   .HasForeignKey(x => x.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Payments)
                    .WithOne(p => p.PaymentGateway)
                    .HasForeignKey(p => p.PaymentGatewayId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}