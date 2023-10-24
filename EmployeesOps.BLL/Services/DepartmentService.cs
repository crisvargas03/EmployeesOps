using AutoMapper;
using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Interfaces;
using EmployeesOps.DAL.Repository.IRepositories;
using EmployeesOps.DAL.Utils;
using System.Net;

namespace EmployeesOps.BLL.Services
{
    public class DepartmentService : IDeparmentService
    {
        private readonly IDepartmentInterface _repository;
        protected readonly IMapper _mapper;
        protected APIResponse _response;

        public DepartmentService(IDepartmentInterface repository, IMapper mapper)
        {
            _repository = repository;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var departments = await _repository.GetAllAsync(tracked: false);
                _response.Payload = _mapper.Map<List<DeparmentDto>>(departments);

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
