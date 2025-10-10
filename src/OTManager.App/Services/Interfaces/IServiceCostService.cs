using OTManager.App.Dtos.ServiceCosts;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IServiceCostService
{
    Task<IEnumerable<ReadServiceCostDto>> GetAllAsync();
    Task<(IEnumerable<ReadServiceCostDto> Items, int TotalCount)> GetFilteredAsync(ServiceCostQueryParams query);
    Task<ReadServiceCostDto?> GetByIdAsync(Guid id);
    Task<ReadServiceCostDto> CreateAsync(WriteServiceCostDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateServiceCostDto dto);
    Task<bool> DeleteAsync(Guid id);
}
