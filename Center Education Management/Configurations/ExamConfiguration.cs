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
    internal class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
           
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ExamId");

           
            builder.HasOne(e => e.Teacher)
                   .WithMany(t => t.Exams)
                   .HasForeignKey(e => e.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

           
            builder.HasOne(e => e.Group)
                   .WithMany(g => g.Exams)
                   .HasForeignKey(e => e.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasOne(e => e.Subject)
                   .WithMany(s => s.Exams)
                   .HasForeignKey(e => e.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);

           
            builder.HasMany(e => e.Questions)
                   .WithOne(q => q.Exam)
                   .HasForeignKey(q => q.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(e => e.Attempts)
                   .WithOne(a => a.Exam)
                   .HasForeignKey(a => a.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);

           
            builder.Property(e => e.Title)
                   .HasColumnName("ExamTitle")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.DurationMinutes)
                   .IsRequired();

            builder.Property(e => e.TotalPoints)
                   .HasPrecision(10, 2);

            builder.Property(e => e.ShuffleQuestions)
                   .HasDefaultValue(false);

            builder.Property(e => e.ShuffleOptions)
                   .HasDefaultValue(false);

            builder.Property(e => e.StartsAt)
                   .IsRequired();

            builder.Property(e => e.EndsAt)
                   .IsRequired();

            builder.Property(e => e.ShowResultsAt);

            builder.Property(e => e.Status)
                   .HasConversion<string>();
        }
    }
}
