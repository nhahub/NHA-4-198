using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class ExamAttemptConfiguration : IEntityTypeConfiguration<ExamAttempt>
    {
        public void Configure(EntityTypeBuilder<ExamAttempt> builder)
        {
            builder.ToTable("ExamAttempts");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("ExamAttemptId");

            builder.Property(a => a.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(a => a.TotalPoints)
                   .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Score)
                   .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Percentage)
                   .HasColumnType("float");

            builder.HasOne(a => a.Exam)
                   .WithMany(e => e.Attempts)
                   .HasForeignKey(a => a.ExamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Student)
                   .WithMany(s => s.ExamAttempts)
                   .HasForeignKey(a => a.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Answers)
                   .WithOne(ans => ans.Attempt)
                   .HasForeignKey(ans => ans.AttemptId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}