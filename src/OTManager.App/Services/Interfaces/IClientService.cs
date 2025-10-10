using OTManager.App.Dtos.Clients;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ReadClientDto>> GetAllAsync();
    Task<(IEnumerable<ReadClientDto> Items, int TotalCount)> GetFilteredAsync(ClientQueryParams query);
    Task<ReadClientDto?> GetByIdAsync(Guid id);
    Task<ReadClientDto> CreateAsync(WriteClientDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateClientDto dto);
    Task<bool> DeleteAsync(Guid id);
}
