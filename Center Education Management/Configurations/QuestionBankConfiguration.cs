using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configuration
{
    public class QuestionBankConfiguration
        : IEntityTypeConfiguration<QuestionBank>
    {
        public void Configure(EntityTypeBuilder<QuestionBank> builder)
        {
            builder.ToTable("QuestionBanks");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Id)
              .HasColumnName("QuestionBankId");

            builder.Property(x => x.Lesson)
                   .HasMaxLength(200);

            builder.Property(x => x.Body)
                   .HasMaxLength(2000);

            builder.Property(x => x.OptionsJson)
                   .HasColumnType("nvarchar(max)");

            builder.Property(x => x.CorrectAnswer)
                   .HasMaxLength(500);

            builder.Property(x => x.Points)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.HasOne(x => x.Teacher)
                   .WithMany(t => t.QuestionBanks)
                   .HasForeignKey(x => x.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Center)
                   .WithMany(c => c.QuestionBanks)
                   .HasForeignKey(x => x.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subject)
                   .WithMany(s => s.Questions)
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ExamAttempts)
                     .WithOne(x => x.QuestionBank)
                     .HasForeignKey(x => x.QuestionBankId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}