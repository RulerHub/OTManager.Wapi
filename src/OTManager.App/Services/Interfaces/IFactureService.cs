using OTManager.App.Dtos.Factures;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IFactureService
{
    Task<IEnumerable<ReadFactureDto>> GetAllAsync();
    Task<(IEnumerable<ReadFactureDto> Items, int TotalCount)> GetFilteredAsync(FactureQueryParams query);
    Task<ReadFactureDto?> GetByIdAsync(Guid id);
    Task<ReadFactureDto> CreateAsync(WriteFactureDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateFactureDto dto);
    Task<bool> DeleteAsync(Guid id);
}
