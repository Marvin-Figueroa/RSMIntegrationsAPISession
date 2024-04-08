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

  public class ProductCategoryService : IProductCategoryService
  {
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IValidator<CreateProductCategoryDto> _createProductCategoryValidator;
    private readonly IValidator<UpdateProductCategoryDto> _updateProductCategoryValidator;
    private readonly IMapper _mapper;

    public ProductCategoryService(IProductCategoryRepository repository, IValidator<CreateProductCategoryDto> createProductCategoryValidator, IValidator<UpdateProductCategoryDto> updateProductCategoryValidator, IMapper mapper)
    {
      _productCategoryRepository = repository;
      _createProductCategoryValidator = createProductCategoryValidator;
      _updateProductCategoryValidator = updateProductCategoryValidator;
      _mapper = mapper;
    }

    public async Task<int> CreateProductCategory(CreateProductCategoryDto productCategoryDto)
    {
      var validationResult = _createProductCategoryValidator.Validate(productCategoryDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("ProductCategory info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      var productCategory = _mapper.Map<ProductCategory>(productCategoryDto);

      return await _productCategoryRepository.CreateProductCategory(productCategory);
    }

    public async Task<int> DeleteProductCategory(int id)
    {

      if (id <= 0)
      {
        throw new BadRequestException("Id is not valid.");
      }

      var productCategory = await _productCategoryRepository.GetProductCategoryById(id);

      if (productCategory == null) throw new NotFoundException($"ProductCategory with Id: {id} was not found.");

      return await _productCategoryRepository.DeleteProductCategory(productCategory);
    }

    public async Task<IEnumerable<GetProductCategoryDto>> GetAll()
    {
      var productCategories = await _productCategoryRepository.GetAllProductCategories();
      return _mapper.Map<IEnumerable<GetProductCategoryDto>>(productCategories);

    }

    public async Task<GetProductCategoryDto?> GetProductCategoryById(int id)
    {
      if (id <= 0)
      {
        throw new BadRequestException("ProductCategoryId is not valid");
      }

      var productCategory = await _productCategoryRepository.GetProductCategoryById(id);

      if (productCategory == null) throw new NotFoundException($"ProductCategory with Id: {id} was not found.");

      productCategory = await _productCategoryRepository.GetProductCategoryById(id);
      return _mapper.Map<GetProductCategoryDto>(productCategory);
    }

    public async Task<int> UpdateProductCategory(UpdateProductCategoryDto productCategoryDto)
    {
      var ProductCategory = await _productCategoryRepository.GetProductCategoryById(productCategoryDto.ProductCategoryId);

      if (ProductCategory == null) throw new NotFoundException($"ProductCategory with Id: {productCategoryDto.ProductCategoryId} was not found.");

      var validationResult = _updateProductCategoryValidator.Validate(productCategoryDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("ProductCategory info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      ProductCategory = _mapper.Map<ProductCategory>(productCategoryDto);

      return await _productCategoryRepository.UpdateProductCategory(ProductCategory);
    }

  }
}
