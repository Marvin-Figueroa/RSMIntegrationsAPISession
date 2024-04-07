using AutoMapper;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

public class DepartmentMappingProfile : Profile
{
  public DepartmentMappingProfile()
  {
    CreateMap<Department, GetDepartmentDto>();
    CreateMap<UpdateDepartmentDto, Department>();
    CreateMap<CreateDepartmentDto, Department>();
  }
}
