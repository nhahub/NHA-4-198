using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
             builder.HasKey(s => s.Id);
            
            builder.Property(a => a.Id)
                    .HasColumnName("SubjectId");

            builder.Property(s => s.Name)
                   .HasColumnName("SubjectName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(s => s.IsActive)
                   .HasColumnName("Is_Active")
                   .HasDefaultValue(true);

            builder.Property(s => s.CreatedAt)
                  .HasColumnName("Created_At")
                  .IsRequired();

            builder.HasOne(s => s.Center)
                   .WithMany(c => c.Subjects)
                   .HasForeignKey(s => s.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Stage)
                   .WithMany(es => es.Subjects)
                   .HasForeignKey(s => s.StageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Teachers)
                   .WithOne(t => t.Subject)
                   .HasForeignKey(t => t.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Groups)
                   .WithOne(g => g.Subject)
                   .HasForeignKey(g => g.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Questions)
                  .WithOne(q => q.Subject)
                  .HasForeignKey(q => q.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Exams)
                  .WithOne(e => e.Subject)
                  .HasForeignKey(e => e.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Assignments)
                  .WithOne(a => a.Subject)
                  .HasForeignKey(a => a.SubjectId)  
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Leads)
                 .WithOne(l => l.Subject)
                 .HasForeignKey(l => l.SubjectId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}