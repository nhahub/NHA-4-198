using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(a => a.Id)
              .HasColumnName("StudentId");

            builder.Property(s => s.StudentCode)
                   .HasMaxLength(50);

            builder.Property(s => s.BlockedReason)
                   .HasMaxLength(500);

            builder.Property(s => s.Status)
                   .HasConversion<string>();

            builder.Property(s => s.JoinedAt)
                   .IsRequired();

            builder.HasOne(s => s.Parent)
                   .WithMany(p => p.Students)
                   .HasForeignKey(s => s.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Center)
                   .WithMany(c => c.Students)
                   .HasForeignKey(s => s.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Stage)
                   .WithMany(es => es.Students)
                   .HasForeignKey(s => s.StageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}