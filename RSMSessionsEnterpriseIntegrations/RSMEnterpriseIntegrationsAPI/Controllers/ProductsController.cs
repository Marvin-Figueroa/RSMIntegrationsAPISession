namespace RSMEnterpriseIntegrationsAPI.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  using RSMEnterpriseIntegrationsAPI.Application.DTOs;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

  [Route("api/products")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
      _service = service;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
      return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      return Ok(await _service.GetProductById(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      return Ok(await _service.DeleteProduct(id));
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
      return Ok(await _service.CreateProduct(dto));
    }

    [HttpPut("")]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
      return Ok(await _service.UpdateProduct(dto));
    }
  }
}