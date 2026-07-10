using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class EducationalStageConfiguration : IEntityTypeConfiguration<EducationalStage>
    {
        public void Configure(EntityTypeBuilder<EducationalStage> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("EducationalStageId");

            builder.Property(e => e.Name)
                   .HasColumnName("EducationalStageName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.DisplayName)
                   .HasMaxLength(150);

            builder.Property(e => e.EducationSystem)
                   .HasMaxLength(100);

            builder.Property(e => e.LevelNumber)
                   .IsRequired();

            builder.Property(e => e.IsActive)
                   .HasDefaultValue(true);
        }
    }
}