namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
  using AutoMapper;
  using FluentValidation;
  using RSMEnterpriseIntegrationsAPI.Application.DTOs;
  using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  using System.Collections.Generic;
  using System.Threading.Tasks;

  public class SalesOrderHeaderService : ISalesOrderHeaderService
  {
    private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;
    private readonly IValidator<CreateSalesOrderHeaderDto> _createSalesOrderHeaderValidator;
    private readonly IValidator<UpdateSalesOrderHeaderDto> _updateSalesOrderHeaderValidator;
    private readonly IMapper _mapper;

    public SalesOrderHeaderService(ISalesOrderHeaderRepository repository, IValidator<CreateSalesOrderHeaderDto> createSalesOrderHeaderValidator, IValidator<UpdateSalesOrderHeaderDto> updateSalesOrderHeaderValidator, IMapper mapper)
    {
      _salesOrderHeaderRepository = repository;
      _createSalesOrderHeaderValidator = createSalesOrderHeaderValidator;
      _updateSalesOrderHeaderValidator = updateSalesOrderHeaderValidator;
      _mapper = mapper;
    }

    public async Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto)
    {
      var validationResult = _createSalesOrderHeaderValidator.Validate(salesOrderHeaderDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("SalesOrderHeader info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      var salesOrderHeader = _mapper.Map<SalesOrderHeader>(salesOrderHeaderDto);

      return await _salesOrderHeaderRepository.CreateSalesOrderHeader(salesOrderHeader);
    }

    public async Task<int> DeleteSalesOrderHeader(int id)
    {

      if (id <= 0)
      {
        throw new BadRequestException("Id is not valid.");
      }

      var salesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id);

      if (salesOrderHeader == null) throw new NotFoundException($"SalesOrderHeader with Id: {id} was not found.");

      return await _salesOrderHeaderRepository.DeleteSalesOrderHeader(salesOrderHeader);
    }

    public async Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll(int pageNumber, int pageSize)
    {
      var salesOrderHeaders = await _salesOrderHeaderRepository.GetAllSalesOrderHeaders(pageNumber, pageSize);

      return _mapper.Map<IEnumerable<GetSalesOrderHeaderDto>>(salesOrderHeaders);

    }

    public async Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id)
    {
      if (id <= 0)
      {
        throw new BadRequestException("SalesOrderHeaderId is not valid");
      }

      var salesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id);

      if (salesOrderHeader == null) throw new NotFoundException($"SalesOrderHeader with Id: {id} was not found.");

      salesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id);

      return _mapper.Map<GetSalesOrderHeaderDto>(salesOrderHeader);
    }

    public async Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto)
    {
      var salesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(salesOrderHeaderDto.SalesOrderId);

      if (salesOrderHeader == null) throw new NotFoundException($"SalesOrderHeader with Id: {salesOrderHeaderDto.SalesOrderId} was not found.");

      var validationResult = _updateSalesOrderHeaderValidator.Validate(salesOrderHeaderDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("SalesOrderHeader info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      salesOrderHeader = _mapper.Map<SalesOrderHeader>(salesOrderHeaderDto);

      return await _salesOrderHeaderRepository.UpdateSalesOrderHeader(salesOrderHeader);
    }

  }
}