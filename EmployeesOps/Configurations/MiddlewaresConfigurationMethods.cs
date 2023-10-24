using EmployeesOps.BLL.Interfaces;
using EmployeesOps.BLL.Mapper;
using EmployeesOps.BLL.Services;
using EmployeesOps.DAL;
using EmployeesOps.DAL.Repository;
using EmployeesOps.DAL.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EmployeesOps.Configurations
{
    public static class MiddlewaresConfigurationMethods
    {
        public static void ConfigurateDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("MainDB"));
            });
        }

        public static void ConfigurateCors(this IServiceCollection services)
        {
            services.AddCors(p => p.AddPolicy("cors", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        public static void ConfigurateServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDeparmentService, DepartmentService>();
            services.AddScoped<IIdentificationTypeService, IdentificationTypeService>();
        }

        public static void ConfigurateRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeInterface, EmployeeRepository>();
            services.AddScoped<IDepartmentInterface, DepartmentRepository>();
            services.AddScoped<IIdentificationTypeInterface, IdentificationTypeRepository>();
        }

        public static void ConfigurateAutoMapper(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(MappingConfiguration));
        }

        public static void PrepereConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurateDbContext(configuration);
            services.ConfigurateCors();
            services.ConfigurateRepositories();
            services.ConfigurateServices();
            services.ConfigurateAutoMapper();
        }
    }
}
