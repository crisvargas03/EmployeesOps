using EmployeesOps.BLL.Interfaces;
using EmployeesOps.DAL.Repository.IRepositories;
using EmployeesOps.DAL.Utils;
using System.Net;

namespace EmployeesOps.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeInterface _repository;
        private APIResponse _response;

        public EmployeeService(IEmployeeInterface repository)
        {
            _repository = repository;
            _response = new();
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var employees = await _repository.GetAllFromSpAsync();

                // TODO: Make automapper Dto
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Payload = employees;

                return _response;
            }
            catch (Exception ex)
            {
                _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
                return _response;
            }
        }

        public async Task<APIResponse> GetByIdAsync(Guid id) 
        {
            try
            {
                var employee = await _repository.GetByIdFromSpAsync(id);
                if (employee is null) 
                {
                    _response.FailedResponse(HttpStatusCode.NotFound, "Not Found...");
                    return _response;
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Payload = employee;
                return _response;
            }
            catch (Exception ex)
            {
                _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
                return _response;
            }
        }
    }
}
