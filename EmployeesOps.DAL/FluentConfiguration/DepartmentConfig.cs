using EmployeesOps.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesOps.DAL.FluentConfiguration
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Department { Id = 1001, Name = "IT Department", CreatedBy = "Dataseed" },
                new Department { Id = 1002, Name = "Sales Department" , CreatedBy = "Dataseed" },
                new Department { Id = 1003, Name = "HHRR Department" , CreatedBy = "Dataseed" }
            );
        }
    }
}
