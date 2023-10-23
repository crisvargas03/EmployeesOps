using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.Core;

namespace EmployeesOps.DAL.Repository.IRepositories
{
    public interface IEmployeeInterface : IBaseRepository<Employee>
    {
        Task<int> ExecuteInsertSpAsync(Employee employee);
        Task<List<Employee>> GetAllFromSpAsync();
        Task<Employee> GetByIdFromSpAsync(Guid Id);
    }
}
