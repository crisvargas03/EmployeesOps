using EmployeesOps.DAL.FluentConfiguration;
using EmployeesOps.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesOps.DAL
{
    public class MainDbContext : DbContext
    {
        // Tables
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Department => Set<Department>();
        public DbSet<IdentificationType> IdentificationTypes => Set<IdentificationType>();

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new IdentificationTypeConfig());
        }
    }
}
