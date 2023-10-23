using AutoMapper;
using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Interfaces;
using EmployeesOps.DAL.Repository.IRepositories;
using EmployeesOps.DAL.Utils;
using System.Net;

namespace EmployeesOps.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeInterface _repository;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public EmployeeService(IEmployeeInterface repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var employees = await _repository.GetAllFromSpAsync();
                _response.Payload = _mapper.Map<List<EmployeeDto>>(employees);

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

                _response.Payload = _mapper.Map<EmployeeDto>(employee);
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
