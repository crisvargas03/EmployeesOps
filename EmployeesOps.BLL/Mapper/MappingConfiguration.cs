using AutoMapper;
using EmployeesOps.BLL.Dtos;
using EmployeesOps.DAL.Models;

namespace EmployeesOps.BLL.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration() 
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeInsertDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            CreateMap<Department, DeparmentDto>().ReverseMap();

            CreateMap<IdentificationType, IdentificationTypeDto>().ReverseMap();
        }
    }
}
