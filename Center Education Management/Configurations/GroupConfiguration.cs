using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                   .HasColumnName("Group_ID");

            builder.Property(g => g.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(g => g.MaxCapacity)
                   .HasColumnName("Capacity")
                   .IsRequired();

            builder.Property(g => g.Price)
                    .HasColumnName("Price")
                   .HasColumnType("decimal(18,2)")  ;

            builder.Property(g => g.ScheduleJson)
                   .HasColumnName("Schedule_JSON")
                   .HasColumnType("nvarchar(max)");

            builder.Property(g => g.Status)
                   .HasColumnName("Status")
                   .HasConversion<string>();

            builder.Property(g => g.CreatedAt)
                    .HasColumnName("Created_At")
                    .IsRequired();

            builder.HasOne(g => g.Teacher)
                   .WithMany(t => t.Groups)
                   .HasForeignKey(g => g.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Subject)
                   .WithMany(s => s.Groups)
                   .HasForeignKey(g => g.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Center)
                   .WithMany(c => c.Groups)
                   .HasForeignKey(g => g.CenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.AcademicSeason)
                   .WithMany(a => a.Groups)
                   .HasForeignKey(g => g.SeasonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Stage)
                   .WithMany(s => s.Groups)
                   .HasForeignKey(g => g.StageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Classroom)
                   .WithMany(c => c.Groups)
                   .HasForeignKey(g => g.ClassroomId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}