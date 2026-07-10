    using Center_Education_Management.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace Center_Education_Management.Configuration
    {
        public class StudentLeadConfiguration : IEntityTypeConfiguration<StudentLead>
        {
            public void Configure(EntityTypeBuilder<StudentLead> builder)
            {
                builder.ToTable("StudentLeads");

                builder.HasKey(x => x.Id);

                builder.Property(a => a.Id)
                  .HasColumnName("StudentLeadId");

                builder.Property(x => x.Name)
                       .HasMaxLength(200);

                builder.Property(x => x.Phone)
                       .HasMaxLength(20);

                builder.Property(x => x.Email)
                       .HasMaxLength(255);

                builder.Property(x => x.InterestedStageOrSubject)
                       .HasMaxLength(500);

                builder.Property(x => x.Status)
                    .HasConversion<string>()
                    .IsRequired();

                builder.Property(x => x.CreatedAt)
                       .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Center)
                       .WithMany(c => c.Leads)
                       .HasForeignKey(x => x.CenterId)
                       .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Stage)
                       .WithMany(x => x.Leads)
                       .HasForeignKey(x=>x.StageId)
                       .OnDelete(DeleteBehavior.NoAction);

                builder.HasOne(x => x.Subject)
                       .WithMany(x => x.Leads)
                       .HasForeignKey(x => x.SubjectId)
                       .OnDelete(DeleteBehavior.NoAction);
            }
        }
    }