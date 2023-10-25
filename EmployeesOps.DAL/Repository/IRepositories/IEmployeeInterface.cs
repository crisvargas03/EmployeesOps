using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.Core;

namespace EmployeesOps.DAL.Repository.IRepositories
{
    public interface IEmployeeInterface : IBaseRepository<Employee>
    {
        Task<int> ExecuteDeleteSpAsync(Guid id);
        Task<int> ExecuteInsertSpAsync(Employee employee);
        Task<int> ExecuteUpdateSpAsync(Employee employee);
        Task<bool> ExistDepartment(int id);
        Task<bool> ExistIdentificationType(int id);
        Task<List<Employee>> GetAllFromSpAsync();
        Task<Employee> GetByIdFromSpAsync(Guid Id);
    }
}
