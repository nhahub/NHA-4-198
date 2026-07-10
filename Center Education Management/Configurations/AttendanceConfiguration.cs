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
    internal class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        void IEntityTypeConfiguration<Attendance>.Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("AttendanceId");

            builder.Property(a => a.Status)
                   .HasConversion<string>();

            builder.Property(a => a.AttendanceMode)
                   .HasConversion<string>();

            builder.Property(a => a.RecordedAt)
                   .IsRequired();

            builder.HasOne(a => a.Student)
                   .WithMany(s => s.Attendances)
                   .HasForeignKey(a => a.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Session)
                   .WithMany(s => s.Attendances)
                   .HasForeignKey(a => a.SessionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.RecordedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.RecordedByID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.QRToken)
                   .WithMany(q => q.Attendances)
                   .HasForeignKey(a => a.QRTokenId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
