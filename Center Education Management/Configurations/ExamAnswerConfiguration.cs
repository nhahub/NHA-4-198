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
    internal class ExamAnswerConfiguration : IEntityTypeConfiguration<ExamAnswer>
    {
        public void Configure(EntityTypeBuilder<ExamAnswer> builder)
        {
           
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("ExamAnswerId");

            
            builder.HasOne(a => a.Attempt)
                   .WithMany(at => at.Answers)
                   .HasForeignKey(a => a.AttemptId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(a => a.ExamQuestion)
                   .WithMany()
                   .HasForeignKey(a => a.ExamQuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(a => a.GradedByTeacher)
                   .WithMany()
                   .HasForeignKey(a => a.GradedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.Property(a => a.AnswerText)
                   .HasMaxLength(2000);

            builder.Property(a => a.IsAutoGraded)
                   .HasDefaultValue(false);

            builder.Property(a => a.EarnedPoints)
                   .HasPrecision(10, 2);

            builder.Property(a => a.GradedAt);

            builder.Property(a => a.SavedAt)
                   .IsRequired();
        }
    }
}
