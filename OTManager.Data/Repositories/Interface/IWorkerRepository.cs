using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IWorkerRepository : IRepository<Worker>
{
    Task<(IEnumerable<Worker> Items, int TotalCount)> GetFilteredAsync(WorkerQueryParams query);
}
