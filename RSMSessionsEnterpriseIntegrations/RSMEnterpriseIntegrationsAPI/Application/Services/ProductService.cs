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

  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductDto> _createProductValidator;
    private readonly IValidator<UpdateProductDto> _updateProductValidator;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IValidator<CreateProductDto> createProductValidator, IValidator<UpdateProductDto> updateProductValidator, IMapper mapper)
    {
      _productRepository = repository;
      _createProductValidator = createProductValidator;
      _updateProductValidator = updateProductValidator;
      _mapper = mapper;
    }

    public async Task<int> CreateProduct(CreateProductDto productDto)
    {
      var validationResult = _createProductValidator.Validate(productDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("Product info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      var product = _mapper.Map<Product>(productDto);

      return await _productRepository.CreateProduct(product);
    }

    public async Task<int> DeleteProduct(int id)
    {

      if (id <= 0)
      {
        throw new BadRequestException("Id is not valid.");
      }

      var product = await _productRepository.GetProductById(id);

      if (product == null) throw new NotFoundException($"Product with Id: {id} was not found.");

      return await _productRepository.DeleteProduct(product);
    }

    public async Task<IEnumerable<GetProductDto>> GetAll()
    {
      var products = await _productRepository.GetAllProducts();
      return _mapper.Map<IEnumerable<GetProductDto>>(products);

    }

    public async Task<GetProductDto?> GetProductById(int id)
    {
      if (id <= 0)
      {
        throw new BadRequestException("ProductId is not valid");
      }

      var product = await _productRepository.GetProductById(id);

      if (product == null) throw new NotFoundException($"Product with Id: {id} was not found.");

      product = await _productRepository.GetProductById(id);
      return _mapper.Map<GetProductDto>(product);
    }

    public async Task<int> UpdateProduct(UpdateProductDto productDto)
    {
      var product = await _productRepository.GetProductById(productDto.ProductId);

      if (product == null) throw new NotFoundException($"Product with Id: {productDto.ProductId} was not found.");

      var validationResult = _updateProductValidator.Validate(productDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("Product info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      product = _mapper.Map<Product>(productDto);

      return await _productRepository.UpdateProduct(product);
    }

  }
}
