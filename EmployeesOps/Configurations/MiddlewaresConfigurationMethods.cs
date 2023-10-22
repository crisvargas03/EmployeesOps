using EmployeesOps.DAL;
using Microsoft.EntityFrameworkCore;

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
    }
}
