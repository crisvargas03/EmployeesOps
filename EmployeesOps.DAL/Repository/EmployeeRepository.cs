using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.Core;
using EmployeesOps.DAL.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeesOps.DAL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeInterface
    {
        private readonly MainDbContext _mainDbContext;
        public EmployeeRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<Employee>> GetAllFromSpAsync()
        {
            return await _mainDbContext.Employees
                .FromSqlInterpolated($"exec GetAllEmployees")
                .AsNoTracking()
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<Employee> GetByIdFromSpAsync(Guid id)
        {
            var result = await _mainDbContext.Employees
                .FromSqlInterpolated($"exec GetEmployeeById @EmployeeId={id}")
                .AsNoTracking()
                .IgnoreQueryFilters()
                .ToListAsync();

            return result.FirstOrDefault()!;
        }
    }
}
