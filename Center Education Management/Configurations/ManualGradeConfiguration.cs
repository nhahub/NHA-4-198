using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class ManualGradeConfiguration : IEntityTypeConfiguration<ManualGrade>
    {
        public void Configure(EntityTypeBuilder<ManualGrade> builder)
        {
            builder.ToTable("ManualGrades");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .HasColumnName("ManualGradeId");

            builder.Property(m => m.Points)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(m => m.Notes)
                   .HasMaxLength(1000);

            builder.Property(m => m.GradedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.Student)
                   .WithMany()
                   .HasForeignKey(m => m.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.RecordedByUser)
                   .WithMany()
                   .HasForeignKey(m => m.RecordedById)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Group)
                   .WithMany()
                   .HasForeignKey(m => m.GroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Subject)
                   .WithMany()
                   .HasForeignKey(m => m.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}