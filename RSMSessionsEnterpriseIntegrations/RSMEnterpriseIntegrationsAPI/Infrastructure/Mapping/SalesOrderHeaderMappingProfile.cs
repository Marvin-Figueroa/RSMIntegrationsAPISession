using AutoMapper;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

public class SalesOrderHeaderMappingProfile : Profile
{
  public SalesOrderHeaderMappingProfile()
  {
    CreateMap<SalesOrderHeader, GetSalesOrderHeaderDto>();
    CreateMap<UpdateSalesOrderHeaderDto, SalesOrderHeader>();
    CreateMap<CreateSalesOrderHeaderDto, SalesOrderHeader>();
  }
}