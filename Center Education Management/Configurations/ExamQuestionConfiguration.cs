using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                   .HasColumnName("ExamQuestionId");

            builder.Property(q => q.BodySnapshot)
                   .HasColumnType("nvarchar(max)");

            builder.Property(q => q.OptionsSnapshot)
                   .HasColumnType("nvarchar(max)");

            builder.Property(q => q.CorrectAnswer)
                   .HasMaxLength(500);

            builder.Property(q => q.Type)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(q => q.Points)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(q => q.OrderIndex)
                   .IsRequired();

            builder.HasOne(q => q.Exam)
                   .WithMany(e => e.Questions)
                   .HasForeignKey(q => q.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.QuestionBank)
                   .WithMany(qb => qb.ExamQuestions)
                   .HasForeignKey(q => q.QuestionBankId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}