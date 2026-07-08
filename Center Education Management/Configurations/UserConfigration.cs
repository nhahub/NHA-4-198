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
    internal class UserConfigration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("UserId");

            builder.Property(u => u.NationalID)
                .HasColumnName("UserNationalID")
                .HasMaxLength(30);

            builder.Property(u => u.FirstName)
                .HasColumnName("UserFirstName")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .HasColumnName("UserLastName")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .HasColumnName("UserEmail")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .HasColumnName("UserPasswordHash")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Phone)
                .HasColumnName("UserPhone")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.AvatarUrl)
                .HasColumnName("UserAvatarUrl")
                .HasMaxLength(200);

            builder.Property(u => u.IsActive)
                .HasColumnName("UserIsActive");

            builder.Property(u => u.EmailVerified)
                .HasColumnName("UserEmailVerified");

            builder.Property(u => u.Salary)
                .HasColumnName("UserSalary")
                .HasPrecision(18, 2); ;

            builder.Property(u => u.LastLoginAt)
                .HasColumnName("UserLastLoginAt");

            builder.Property(u => u.CreatedAt)
                .HasColumnName("UserCreatedAt")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("UserUpdatedAt")
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

        }
    }
}