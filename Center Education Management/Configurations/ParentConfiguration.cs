using Center_Education_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configurations
{
    internal class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {

            builder.Property(p => p.Permissions)
                   .HasConversion<string>();

            builder.HasMany(p => p.Students)
                   .WithOne(s => s.Parent)
                   .HasForeignKey(s => s.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}