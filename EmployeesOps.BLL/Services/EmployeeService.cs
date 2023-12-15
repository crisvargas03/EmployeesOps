using AutoMapper;
using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Interfaces;
using EmployeesOps.DAL.Models;
using EmployeesOps.DAL.Repository.IRepositories;
using EmployeesOps.DAL.Utils;
using FluentValidation;
using System.Net;

namespace EmployeesOps.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeInterface _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeInsertDto> _validatorInsert;
        private readonly IValidator<EmployeeUpdateDto> _validatorUpdate;
        protected APIResponse _response;

        public EmployeeService(IEmployeeInterface repository, 
            IMapper mapper, 
            IValidator<EmployeeInsertDto> validatorInsert, 
            IValidator<EmployeeUpdateDto> validatorUpdate)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new();
            _validatorInsert = validatorInsert;
            _validatorUpdate = validatorUpdate;
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
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<APIResponse> GetByIdAsync(Guid id) 
        {
            try
            {
                var employee = await _repository.GetByIdFromSpAsync(id);
                if (employee is null) 
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "Not Found...");
                }

                _response.Payload = _mapper.Map<EmployeeDto>(employee);
                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<APIResponse> InsertAsync(EmployeeInsertDto employeeInsert)
        {
            if (await IdentificationNumberExits(employeeInsert.IdentificationNumber))
            {                
                return _response.FailedResponse(HttpStatusCode.BadRequest, "The identification number already exists.");
            }

            var validationResult = _validatorInsert.Validate(employeeInsert);
            if (!validationResult.IsValid)
            {
                _response.FailedResponse(HttpStatusCode.BadRequest, "Validation error.");
                _response.Payload = new { validationResult.Errors };
                return _response;
            }

            if (!await _repository.ExistDepartment(employeeInsert.DepartmentId) || 
                !await _repository.ExistIdentificationType(employeeInsert.IdentificationTypeId))
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Department or IdentificationType does not exist.");
            }

            try
            {
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
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Error creating employee.");
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
            if (employeeUpdate is null || id != employeeUpdate.Id)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Incorrect Information");
            }

            var employeeToUpdate = await _repository.GetAsync(x => x.Id == id);
            if (employeeToUpdate is null)
            {
                return _response.FailedResponse(HttpStatusCode.NotFound, "Employee was not found");
            }

            var validationResult = _validatorUpdate.Validate(employeeUpdate);
            if (!validationResult.IsValid) 
            {
                _response.FailedResponse(HttpStatusCode.BadRequest, "Validation error.");
                _response.Payload = new { validationResult.Errors };
                return _response;
            }

            if (!await _repository.ExistDepartment(employeeUpdate.DepartmentId) ||
                !await _repository.ExistIdentificationType(employeeUpdate.IdentificationTypeId))
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, "Department or IdentificationType does not exist.");
            }

            _mapper.Map(employeeUpdate, employeeToUpdate);
            employeeToUpdate.ModificationDate = DateTime.Now;
            employeeToUpdate.ModificationBy = "By User";
            try
            {
                var result = await _repository.ExecuteUpdateSpAsync(employeeToUpdate);
                if (result >= 1)
                {
                    _response.Payload = _mapper.Map<EmployeeDto>(employeeToUpdate);
                    return _response;
                }
                else
                {
                    _response.FailedResponse(HttpStatusCode.BadRequest, "Error Editing Employee");
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
            var exits = await _repository.GetAsync(x => x.Id == id, tracked: false);
            if (exits is null)
            {
                return _response.FailedResponse(HttpStatusCode.NotFound, "Employee was not found");
            }
            try
            {
                var result = await _repository.ExecuteDeleteSpAsync(id);
                if (result >= 1) return _response;
                else
                {
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "Error Deleting Employee");
                }
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
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
