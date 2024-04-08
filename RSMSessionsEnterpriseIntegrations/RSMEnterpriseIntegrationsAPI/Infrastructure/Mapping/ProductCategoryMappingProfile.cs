using AutoMapper;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

public class ProductCategoryMappingProfile : Profile
{
  public ProductCategoryMappingProfile()
  {
    CreateMap<ProductCategory, GetProductCategoryDto>();
    CreateMap<UpdateProductCategoryDto, ProductCategory>();
    CreateMap<CreateProductCategoryDto, ProductCategory>();
  }
}