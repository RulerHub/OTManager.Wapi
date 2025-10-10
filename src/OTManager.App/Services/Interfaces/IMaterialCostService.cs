using OTManager.App.Dtos.MaterialCosts;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IMaterialCostService
{
    Task<IEnumerable<ReadMaterialCostDto>> GetAllAsync();
    Task<(IEnumerable<ReadMaterialCostDto> Items, int TotalCount)> GetFilteredAsync(MaterialCostQueryParams query);
    Task<ReadMaterialCostDto?> GetByIdAsync(Guid id);
    Task<ReadMaterialCostDto> CreateAsync(WriteMaterialCostDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateMaterialCostDto dto);
    Task<bool> DeleteAsync(Guid id);
}
