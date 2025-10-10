using OTManager.App.Dtos.Orders;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<ReadOrderDto>> GetAllAsync();
    Task<(IEnumerable<ReadOrderDto> Items, int TotalCount)> GetFilteredAsync(OrderQueryParams query);
    Task<ReadOrderDto?> GetByIdAsync(Guid id);
    Task<ReadOrderDto> CreateAsync(WriteOrderDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateOrderDto dto);
    Task<bool> DeleteAsync(Guid id);
}
