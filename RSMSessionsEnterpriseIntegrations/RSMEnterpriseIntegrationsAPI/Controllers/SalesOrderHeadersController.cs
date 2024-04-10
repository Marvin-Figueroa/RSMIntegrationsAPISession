namespace RSMEnterpriseIntegrationsAPI.Controllers
{
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;

  using RSMEnterpriseIntegrationsAPI.Application.DTOs;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

  [Authorize]
  [Route("api/sales-order-headers")]
  [ApiController]
  public class SalesOrderHeadersController : ControllerBase
  {
    private readonly ISalesOrderHeaderService _service;

    public SalesOrderHeadersController(ISalesOrderHeaderService service)
    {
      _service = service;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 20)
    {
      return Ok(await _service.GetAll(pageNumber, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      return Ok(await _service.GetSalesOrderHeaderById(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      return Ok(await _service.DeleteSalesOrderHeader(id));
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(CreateSalesOrderHeaderDto dto)
    {
      return Ok(await _service.CreateSalesOrderHeader(dto));
    }

    [HttpPut("")]
    public async Task<IActionResult> Update(UpdateSalesOrderHeaderDto dto)
    {
      return Ok(await _service.UpdateSalesOrderHeader(dto));
    }
  }
}
