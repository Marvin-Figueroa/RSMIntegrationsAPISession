namespace RSMEnterpriseIntegrationsAPI.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  using RSMEnterpriseIntegrationsAPI.Application.DTOs;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

  [Route("api/product-categories")]
  [ApiController]
  public class ProductCategoriesController : ControllerBase
  {
    private readonly IProductCategoryService _service;

    public ProductCategoriesController(IProductCategoryService service)
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
      return Ok(await _service.GetProductCategoryById(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      return Ok(await _service.DeleteProductCategory(id));
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(CreateProductCategoryDto dto)
    {
      return Ok(await _service.CreateProductCategory(dto));
    }

    [HttpPut("")]
    public async Task<IActionResult> Update(UpdateProductCategoryDto dto)
    {
      return Ok(await _service.UpdateProductCategory(dto));
    }
  }
}

