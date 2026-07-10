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
    internal class AssignmentConfigration : IEntityTypeConfiguration<Assignment>
    {
        void IEntityTypeConfiguration<Assignment>.Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("AssignmentId");

            builder.Property(a => a.Name)
                .HasColumnName("AssignmentName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.StartDate)
                .HasColumnName("AssignmentStartDate")
                .IsRequired();

            builder.Property(a => a.DueDate)
                .HasColumnName("AssignmentDueDate");

            builder.Property(a => a.TeacherId)
                .HasColumnName("AssignmentTeacherId")
                .IsRequired();

            builder.Property(a => a.GroupId)
                .HasColumnName("AssignmentGroupId")
                .IsRequired();

            builder.Property(a => a.SubjectId)
                .HasColumnName("AssignmentSubjectId")
                .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion<string>()
                .HasColumnName("AssignmentStatus");

            builder.HasOne(a => a.Subject)
                .WithMany(s => s.Assignments)
                .HasForeignKey(a => a.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Teacher)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Group)
                .WithMany(g => g.Assignments)
                .HasForeignKey(a => a.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}