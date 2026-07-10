using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Configurations
{
    internal class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("ClassroomId");

           
            builder.Property(c => c.Name)
                   .HasColumnName("ClassroomName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Capacity)
                   .IsRequired();

            builder.Property(c => c.Type)
                   .HasConversion<string>();

            builder.Property(c => c.IsVirtual)
                   .HasDefaultValue(false);

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            
            builder.HasOne(c => c.Center)
                   .WithMany(c => c.Classrooms)
                   .HasForeignKey(c => c.CenterId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(c => c.Groups)
                   .WithOne(g => g.Classroom)
                   .HasForeignKey(g => g.ClassroomId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(c => c.Sessions)
                   .WithOne(s => s.Classroom)
                   .HasForeignKey(s => s.ClassroomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
