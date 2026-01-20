using OTManager.App.Dtos.Materials;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IMaterialService
{
    Task<IEnumerable<ReadMaterialDto>> GetAllAsync();
    Task<(IEnumerable<ReadMaterialDto> Items, int TotalCount)> GetFilteredAsync(MaterialQueryParams query);
    Task<ReadMaterialDto?> GetByIdAsync(Guid id);
    Task<ReadMaterialDto> CreateAsync(WriteMaterialDto dto);
    Task<bool> UpdateAsync(Guid id, ReadMaterialDto dto);
    Task<bool> DeleteAsync(Guid id);
}
