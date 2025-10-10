using OTManager.App.Dtos.WorkerCosts;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IWorkerCostService
{
    Task<IEnumerable<ReadWorkerCostDto>> GetAllAsync();
    Task<(IEnumerable<ReadWorkerCostDto> Items, int TotalCount)> GetFilteredAsync(WorkerCostQueryParams query);
    Task<ReadWorkerCostDto?> GetByIdAsync(Guid id);
    Task<ReadWorkerCostDto> CreateAsync(WriteWorkerCostDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateWorkerCostDto dto);
    Task<bool> DeleteAsync(Guid id);
}
