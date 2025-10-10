using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IMaterialRepository : IRepository<Material>
{
    Task<(IEnumerable<Material> Items, int TotalCount)> GetFilteredAsync(MaterialQueryParams query);
}
