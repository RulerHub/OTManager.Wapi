using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IMaterialCostRepository : IRepository<MaterialCost>
{
    Task<(IEnumerable<MaterialCost> Items, int TotalCount)> GetFilteredAsync(MaterialCostQueryParams query);
}
