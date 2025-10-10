using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Repositories.Abstracts;

namespace OTManager.Data.Repositories.Interface;

/// <summary>
/// Repositorio para operaciones sobre entidades de servicios de orden.
/// </summary>
public interface IOrderServiceRepository : IRepository<OrderService>
{
    /// <summary>
    /// Obtiene una lista filtrada de servicios de orden según los parámetros de consulta.
    /// </summary>
    /// <param name="query">Parámetros de consulta para filtrar servicios.</param>
    /// <returns>Lista de servicios y el total de elementos.</returns>
    Task<(IEnumerable<OrderService> Items, int TotalCount)> GetFilteredAsync(OrderServiceQueryParams query);
}
