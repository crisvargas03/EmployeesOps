using AutoMapper;
using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Interfaces;
using EmployeesOps.DAL.Models;
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

        public async Task<APIResponse> InsertAsync(EmployeeInsertDto employeeInsert)
        {
            try
            {
                var exits = await IdentificationNumberExits(employeeInsert!.IdentificationNumber);
                if (employeeInsert is null || exits)
                {
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Incorrect Information...");
                    return _response;
                }

                var employeeModel = _mapper.Map<Employee>(employeeInsert);
                employeeModel.Id = Guid.NewGuid();

                var result = await _repository.ExecuteInsertSpAsync(employeeModel);
                if (result >= 1) 
                {
                    _response.Payload = _mapper.Map<EmployeeDto>(employeeModel);
                    return _response;
                }
                else
                {
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Error Creating Employee...");
                    return _response;
                }
            }
            catch (Exception ex)
            {
                _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
                return _response;
            }
        }

        public async Task<APIResponse> UpdateAsync(Guid id, EmployeeUpdateDto employeeUpdate)
        {
            try
            {
                if (employeeUpdate is null || id != employeeUpdate.Id)
                {
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Incorrect Information...");
                    return _response;
                }
                var employeeToUpdate = await _repository.GetAsync(x => x.Id == id);
                if (employeeToUpdate is null)
                {
                    _response.FailedResponse(HttpStatusCode.NotFound, "Employee was not found");
                    return _response;
                }

                _mapper.Map(employeeUpdate, employeeToUpdate);
                employeeToUpdate.ModificationDate = DateTime.Now;
                employeeToUpdate.ModificationBy = "By User";

                var result = await _repository.ExecuteUpdateSpAsync(employeeToUpdate);
                if (result >= 1)
                {
                    _response.Payload = _mapper.Map<EmployeeDto>(employeeToUpdate);
                    return _response;
                }
                else
                {
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Error Editing Employee...");
                    return _response;
                }
            }
            catch (Exception ex)
            {
                _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
                return _response;
            }
        }

        public async Task<APIResponse> DeleteAsync(Guid id)
        {
            try
            {
                var exits = await _repository.GetAsync(x => x.Id == id);
                if (exits is null)
                {
                    _response.FailedResponse(HttpStatusCode.NotFound, "Employee was not found");
                    return _response;
                }
                var result = await _repository.ExecuteDeleteSpAsync(id);
                if (result >= 1) return _response;
                else
                {
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Error Deleting Employee...");
                    return _response;
                }
            }
            catch (Exception ex)
            {
                _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
                return _response;
            }
        }

        private async Task<bool> IdentificationNumberExits(string identificationNumber)
        {
            var result = await _repository.GetAsync(x => x.IdentificationNumber == identificationNumber, tracked: false);
            
            if (result is not null) return true;
            return false;
        }
    }
}
