using OTManager.App.Dtos.Workers;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IWorkerService
{
    Task<IEnumerable<ReadWorkerDto>> GetAllAsync();
    Task<(IEnumerable<ReadWorkerDto> Items, int TotalCount)> GetFilteredAsync(WorkerQueryParams query);
    Task<ReadWorkerDto?> GetByIdAsync(Guid id);
    Task<ReadWorkerDto> CreateAsync(WriteWorkerDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateWorkerDto dto);
    Task<bool> DeleteAsync(Guid id);
}
