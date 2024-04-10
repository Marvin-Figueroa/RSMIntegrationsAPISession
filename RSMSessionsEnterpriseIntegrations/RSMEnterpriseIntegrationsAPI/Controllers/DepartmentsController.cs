namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
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
            return Ok(await _service.GetDepartmentById(id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteDepartment(id));
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            return Ok(await _service.CreateDepartment(dto));
        }

        [Authorize]
        [HttpPut("")]
        public async Task<IActionResult> Update(UpdateDepartmentDto dto)
        {
            return Ok(await _service.UpdateDepartment(dto));
        }
    }
}
