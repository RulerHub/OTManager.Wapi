using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IOrderRepository : IRepository<Order>
{
    Task<(IEnumerable<Order> Items, int TotalCount)> GetFilteredAsync(OrderQueryParams query);
}
