using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class AcademicSeasonConfiguration : IEntityTypeConfiguration<AcademicSeason>
    {
        public void Configure(EntityTypeBuilder<AcademicSeason> builder)
        {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("AcademicSeasonId");

            builder.Property(a => a.CenterId)
                   .HasColumnName("CenterId");

            builder.Property(a => a.Name)
                   .HasColumnName("AcademicSeasonName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.StartsAt)
                   .IsRequired();

            builder.Property(a => a.EndsAt)
                   .IsRequired();

            builder.Property(a => a.Type)
                   .HasConversion<string>();

            builder.Property(a => a.Status)
                   .HasConversion<string>();

            builder.Property(a => a.IsCurrent)
                   .HasDefaultValue(false);

            builder.HasOne(a => a.Center)
                   .WithMany(c => c.AcademicSeasons)
                   .HasForeignKey(a => a.CenterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}