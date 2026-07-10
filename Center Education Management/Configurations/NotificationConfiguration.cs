using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                   .HasColumnName("NotificationId");

            builder.Property(n => n.Type)
                   .HasConversion<string>();

            builder.Property(n => n.Title)
                   .HasMaxLength(300);

            builder.Property(n => n.Body)
                   .HasMaxLength(2000);

            builder.Property(n => n.IsRead)
                   .HasDefaultValue(false);

            builder.Property(n => n.RefType)
                   .HasMaxLength(100);

            builder.Property(n => n.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(n => n.User)
                   .WithMany()
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}