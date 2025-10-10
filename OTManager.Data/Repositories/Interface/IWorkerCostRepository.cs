using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IWorkerCostRepository : IRepository<WorkerCost>
{
    Task<(IEnumerable<WorkerCost> Items, int TotalCount)> GetFilteredAsync(WorkerCostQueryParams query);
}
