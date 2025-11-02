using Microsoft.AspNetCore.Mvc;

using OTManager.App.Dtos.Materials;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;

namespace OTManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class MaterialController(IMaterialService materialService) : ControllerBase
{
    private readonly IMaterialService _materialService = materialService;

    [HttpPost("filter")]
    public async Task<IActionResult> GetAll([FromBody] MaterialQueryParams query)
    {
        //var (Items, TotalCount) = await _materialService.GetFilteredAsync(query);
        var Items = await _materialService.GetFilteredAsync(query);
        return Ok(Items.Items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _materialService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WriteMaterialDto dto)
    {
        var created = await _materialService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMaterialDto dto)
    {
        var updated = await _materialService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _materialService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
