﻿using EmployeesOps.BLL.Dtos;
using EmployeesOps.DAL.Utils;

namespace EmployeesOps.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<APIResponse> DeleteAsync(Guid id);
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetByIdAsync(Guid id);
        Task<APIResponse> InsertAsync(EmployeeInsertDto employeeInsert);
        Task<APIResponse> UpdateAsync(Guid id, EmployeeUpdateDto employeeUpdate);
    }
}
