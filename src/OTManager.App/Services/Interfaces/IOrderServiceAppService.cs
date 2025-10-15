using OTManager.App.Dtos.Orders;
using OTManager.Core.QueryParams;

namespace OTManager.App.Services.Interfaces;

/// <summary>
/// Servicio de aplicación para la gestión de servicios de orden.
/// </summary>
public interface IOrderServiceAppService
{
    /// <summary>
    /// Obtiene todos los servicios de orden.
    /// </summary>
    Task<IEnumerable<ReadOrderServiceDto>> GetAllAsync();
    /// <summary>
    /// Obtiene servicios de orden filtrados por parámetros de consulta.
    /// </summary>
    Task<(IEnumerable<ReadOrderServiceDto> Items, int TotalCount)> GetFilteredAsync(OrderServiceQueryParams query);
    /// <summary>
    /// Obtiene un servicio de orden por su identificador.
    /// </summary>
    Task<ReadOrderServiceDto?> GetByIdAsync(Guid id);
    /// <summary>
    /// Crea un nuevo servicio de orden.
    /// </summary>
    Task<ReadOrderServiceDto> CreateAsync(ReadOrderServiceDto dto);
    /// <summary>
    /// Actualiza un servicio de orden existente.
    /// </summary>
    Task<bool> UpdateAsync(Guid id, ReadOrderServiceDto dto);
    /// <summary>
    /// Elimina un servicio de orden por su identificador.
    /// </summary>
    Task<bool> DeleteAsync(Guid id);
}
