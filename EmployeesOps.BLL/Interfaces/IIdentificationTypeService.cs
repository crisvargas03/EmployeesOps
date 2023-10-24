using EmployeesOps.DAL.Utils;

namespace EmployeesOps.BLL.Interfaces
{
    public interface IIdentificationTypeService
    {
        Task<APIResponse> GetAllAsync();
    }
}
