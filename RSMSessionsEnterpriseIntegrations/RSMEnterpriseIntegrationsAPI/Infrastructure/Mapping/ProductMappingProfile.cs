using AutoMapper;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

public class ProductMappingProfile : Profile
{
  public ProductMappingProfile()
  {
    CreateMap<Product, GetProductDto>();
    CreateMap<UpdateProductDto, Product>();
    CreateMap<CreateProductDto, Product>();
  }
}
