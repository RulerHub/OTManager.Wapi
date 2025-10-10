using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IClientRepository : IRepository<Client>
{
    Task<(IEnumerable<Client> Items, int TotalCount)> GetFilteredAsync(ClientQueryParams query);
}
