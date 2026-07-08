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
    internal class TeacherEducationalStageConfigration : IEntityTypeConfiguration<TeacherEducationalStage>
    {
        void IEntityTypeConfiguration<TeacherEducationalStage>.Configure(EntityTypeBuilder<TeacherEducationalStage> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("TeacherEducationalStageId")
                .IsRequired();

            builder.HasOne(t => t.Teacher)
                    .WithMany(te => te.TeacherStages)
                    .HasForeignKey(t => t.TeacherId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Stage)
                    .WithMany(te => te.TeacherStages)
                    .HasForeignKey(t => t.StageId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}