using EmployeesOps.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesOps.DAL.FluentConfiguration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.Names).IsRequired().HasMaxLength(80);
            builder.Property(x => x.LastNames).IsRequired().HasMaxLength(80);
            builder.Property(x => x.IdentificationNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.EntryDate).IsRequired();

            builder.HasOne(em => em.Department)
                .WithMany(de => de.Employees)
                .HasForeignKey(em => em.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(em => em.IdentificationType)
                .WithMany(it => it.Employees)
                .HasForeignKey(em => em.IdentificationTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
