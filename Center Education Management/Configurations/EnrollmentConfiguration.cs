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
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        void IEntityTypeConfiguration<Enrollment>.Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("EnrollmentId");

            builder.Property(e => e.Status)
                   .HasConversion<string>();

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.GroupEnrollments)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Group)
                   .WithMany(g => g.Enrollments)
                   .HasForeignKey(e => e.GroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Center)
                   .WithMany()
                   .HasForeignKey(e => e.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
