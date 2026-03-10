using AutoMapper;
using EmpMangSys.Api.DTOs.Employees;
using EmpMangSys.Core.Data;

namespace EmpMangSys.Api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee,GetEmployeesDTOs>()
                .ForMember(dest => dest.DepartmentName,
            opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<CreateEmployeeDTOs, Employee>();
            CreateMap<UpdateDTOs, Employee>();
        }
    }
}
