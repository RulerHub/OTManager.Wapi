using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;

namespace OTManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ServiceOrderController : ControllerBase
{
    private readonly IOrderServiceAppService _serviceOrderService;

    public ServiceOrderController(IOrderServiceAppService serviceOrderService)
    {
        _serviceOrderService = serviceOrderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] OrderServiceQueryParams query)
    {
        var (Items, TotalCount) = await _serviceOrderService.GetFilteredAsync(query);
        return Ok(new { Items, TotalCount });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _serviceOrderService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReadOrderServiceDto dto)
    {
        var created = await _serviceOrderService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ReadOrderServiceDto dto)
    {
        var updated = await _serviceOrderService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _serviceOrderService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
