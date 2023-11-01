using EmployeesOps.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            var assembly = Assembly.GetExecutingAssembly();
            var entitiesConfigs = assembly.GetTypes()
                .Where(t => t.Namespace == "EmployeesOps.DAL.FluentConfiguration"
                && t.GetInterfaces().Any(i => i.IsGenericType 
                    && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                ).ToList();

            foreach (var entityConfig in entitiesConfigs)
            {
                dynamic configurationInstance = Activator.CreateInstance(entityConfig)!;
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
