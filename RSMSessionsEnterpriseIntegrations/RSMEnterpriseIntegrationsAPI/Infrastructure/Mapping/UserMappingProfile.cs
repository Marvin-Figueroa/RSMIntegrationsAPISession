using AutoMapper;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

public class UserMappingProfile : Profile
{
  public UserMappingProfile()
  {
    CreateMap<RegisterDto, User>();
  }
}