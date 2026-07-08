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
    internal class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
           
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("ContentId");

            
            builder.HasOne(c => c.Teacher)
                   .WithMany(t => t.Content)
                   .HasForeignKey(c => c.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasOne(c => c.Group)
                   .WithMany(g => g.Contents)
                   .HasForeignKey(c => c.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasOne(c => c.Session)
                   .WithMany(s => s.Content)
                   .HasForeignKey(c => c.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasOne(c => c.UploadedByUser)
                   .WithMany()
                   .HasForeignKey(c => c.UploadedByID)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.Property(c => c.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(c => c.Url)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(c => c.SizeBytes)
                   .IsRequired();

            builder.Property(c => c.Type)
                   .HasConversion<string>();

            builder.Property(c => c.Visibility)
                   .HasConversion<string>();

            builder.Property(c => c.CreatedAt)
                   .IsRequired();
        }
    }
}
