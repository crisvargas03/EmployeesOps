using EmployeesOps.DAL.Utils;

namespace EmployeesOps.BLL.Interfaces
{
    public interface IDeparmentService
    {
        Task<APIResponse> GetAllAsync();
    }
}
