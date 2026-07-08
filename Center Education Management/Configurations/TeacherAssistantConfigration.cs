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
    internal class TeacherAssistantConfigration : IEntityTypeConfiguration<TeacherAssistant>
    {
        void IEntityTypeConfiguration<TeacherAssistant>.Configure(EntityTypeBuilder<TeacherAssistant> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("TeacherAssistantId");

            builder.HasOne(ta => ta.Teacher)
                .WithMany(t => t.Assistants)
                .HasForeignKey(ta => ta.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ta => ta.Center)
                .WithMany(c => c.TeacherAssistant)
                .HasForeignKey(ta => ta.CenterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.JoinedAt)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}