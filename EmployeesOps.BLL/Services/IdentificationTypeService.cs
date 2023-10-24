using AutoMapper;
using EmployeesOps.BLL.Dtos;
using EmployeesOps.BLL.Interfaces;
using EmployeesOps.DAL.Repository.IRepositories;
using EmployeesOps.DAL.Utils;
using System.Net;

namespace EmployeesOps.BLL.Services
{
    public class IdentificationTypeService : IIdentificationTypeService
    {
        private readonly IIdentificationTypeInterface _repository;
        protected readonly IMapper _mapper;
        protected APIResponse _response;

        public IdentificationTypeService(IMapper mapper, IIdentificationTypeInterface repository)
        {
            _response = new();
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var identiticationTypes = await _repository.GetAllAsync(tracked: false);
                _response.Payload = _mapper.Map<List<IdentificationTypeDto>>(identiticationTypes);

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
