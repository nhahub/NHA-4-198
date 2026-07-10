using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t => t.Id)
               .HasColumnName("TeacherId");

            builder.Property(t => t.Bio)
                   .HasMaxLength(500);

            builder.Property(t => t.JoinedAt)
                   .IsRequired();

            builder.Property(t => t.LeftAt)
                   .IsRequired(false);

            builder.HasOne(t => t.Center)
                   .WithMany(c => c.Teachers)
                   .HasForeignKey(t => t.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Subject)
                   .WithMany(s => s.Teachers)
                   .HasForeignKey(t => t.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Groups)
                   .WithOne(g => g.Teacher)
                   .HasForeignKey(g => g.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Assistants)
                   .WithOne(a => a.Teacher)
                   .HasForeignKey(a => a.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.QuestionBanks)
                   .WithOne(q => q.Teacher)
                   .HasForeignKey(q => q.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Assignments)
                   .WithOne(a => a.Teacher)
                   .HasForeignKey(a => a.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Content)
                   .WithOne(c => c.Teacher)
                   .HasForeignKey(c => c.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TeacherStages)
                    .WithOne(ts => ts.Teacher)
                    .HasForeignKey(ts => ts.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}