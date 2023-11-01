using EmployeesOps.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesOps.DAL.FluentConfiguration
{
    public class IdentificationTypeConfig : IEntityTypeConfiguration<IdentificationType>
    {
        public void Configure(EntityTypeBuilder<IdentificationType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(30);

            builder.HasData(
                new IdentificationType { Id = 1, Description = "Cedula", CreatedBy = "Dataseed" },
                new IdentificationType { Id = 2, Description = "SocialId", CreatedBy = "Dataseed" },
                new IdentificationType { Id = 3, Description = "Passport", CreatedBy = "Dataseed" }
            );
        }
    }
}
