using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

public interface IFactureRepository : IRepository<Facture>
{
    Task<(IEnumerable<Facture> Items, int TotalCount)> GetFilteredAsync(FactureQueryParams query);
}
