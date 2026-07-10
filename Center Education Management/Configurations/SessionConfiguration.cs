using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configuration
{
    public class SessionConfiguration
        : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Id)
              .HasColumnName("SessionId");

            builder.Property(x => x.Title)
                   .HasMaxLength(200);

            builder.Property(x => x.VideoLink)
                   .HasMaxLength(1000);

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.Property(x => x.StartTime)
                   .IsRequired();

            builder.Property(x => x.EndTime)
                   .IsRequired();

            builder.HasOne(x => x.Group)
                   .WithMany(x => x.Sessions)
                   .HasForeignKey(x => x.GroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Teacher)
                   .WithMany()
                   .HasForeignKey(x => x.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Attendances)
                   .WithOne(x => x.Session)
                   .HasForeignKey(x => x.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Content)
                   .WithOne(x => x.Session)
                   .HasForeignKey(x => x.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.QRToken)
                   .WithOne(x => x.Session)
                   .HasForeignKey(x => x.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}