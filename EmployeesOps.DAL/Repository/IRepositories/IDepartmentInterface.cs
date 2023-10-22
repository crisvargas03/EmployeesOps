using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.Core;

namespace EmployeesOps.DAL.Repository.IRepositories
{
    public interface IDepartmentInterface : IBaseRepository<Department>
    {
        Task<Department> Update(Department entity);
    }
}
