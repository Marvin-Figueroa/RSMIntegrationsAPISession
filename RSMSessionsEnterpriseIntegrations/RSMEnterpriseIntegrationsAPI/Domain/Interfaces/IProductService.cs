namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
  using RSMEnterpriseIntegrationsAPI.Application.DTOs;

  public interface IProductService
  {
    Task<GetProductDto?> GetProductById(int id);
    Task<IEnumerable<GetProductDto>> GetAll(int pageNumber, int pageSize);
    Task<int> CreateProduct(CreateProductDto ProductDto);
    Task<int> UpdateProduct(UpdateProductDto ProductDto);
    Task<int> DeleteProduct(int id);
  }
}