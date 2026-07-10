using Center_Education_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Center_Education_Management.Configuration
{
    public class QRTokenConfiguration : IEntityTypeConfiguration<QRToken>
    {
        public void Configure(EntityTypeBuilder<QRToken> builder)
        {
            builder.ToTable("QRTokens");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Id)
              .HasColumnName("QRTokenId");

            builder.Property(x => x.Token)
                   .HasMaxLength(255);

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.Property(x => x.GeneratedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();

            builder.HasOne(x => x.Session)
                   .WithMany(x => x.QRToken)
                   .HasForeignKey(x => x.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.GenrateUser)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}