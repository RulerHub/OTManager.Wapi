using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IServiceCostRepository : IRepository<ServiceCost>
{
    Task<(IEnumerable<ServiceCost> Items, int TotalCount)> GetFilteredAsync(ServiceCostQueryParams query);
}
