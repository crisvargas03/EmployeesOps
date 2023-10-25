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

        public async Task<int> ExecuteInsertSpAsync(Employee employee)
        {
            var affectedRows = await _mainDbContext.Database.ExecuteSqlInterpolatedAsync($@"InsertEmployee
            @Id={employee.Id},
            @Names={employee.Names},
            @LastNames={employee.LastNames},
            @IdentificationNumber={employee.IdentificationNumber},
            @BirthDate={employee.BirthDate},
            @EntryDate={employee.EntryDate},
            @Salary={employee.Salary},
            @IdentificationTypeId={employee.IdentificationTypeId},
            @DepartmentId={employee.DepartmentId},
            @CreatedBy={employee.CreatedBy},
            @CreationDate={employee.CreationDate}");

            return affectedRows;
        }

        public async Task<int> ExecuteUpdateSpAsync(Employee employee)
        {
            var affectedRows = await _mainDbContext.Database.ExecuteSqlInterpolatedAsync($@"UpdateEmployee
            @Id={employee.Id},
            @Names={employee.Names},
            @LastNames={employee.LastNames},
            @IdentificationNumber={employee.IdentificationNumber},
            @BirthDate={employee.BirthDate},
            @EntryDate={employee.EntryDate},
            @Salary={employee.Salary},
            @IdentificationTypeId={employee.IdentificationTypeId},
            @DepartmentId={employee.DepartmentId},
            @ModificationBy={employee.ModificationBy},
            @ModificationDate={employee.ModificationDate}");

            return affectedRows;
        }

        public async Task<int> ExecuteDeleteSpAsync(Guid id)
        {
            var affectedRows = await _mainDbContext.Database.ExecuteSqlInterpolatedAsync($@"DeleteEmployee 
            @EmployeeId={id}");

            return affectedRows;
        }

        public async Task<bool> ExistDepartment(int id)
        {
            return await _mainDbContext.Department.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> ExistIdentificationType(int id)
        {
            return await _mainDbContext.IdentificationTypes.AnyAsync(d => d.Id == id);
        }
    }
}
