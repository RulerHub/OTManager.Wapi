using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

/// <summary>
/// Representa un servicio que puede ser solicitado en una orden.
/// </summary>
public class OrderService : Auditable<Guid>
{
    /// <summary>
    /// Nombre del servicio.
    /// </summary>
    public string Name { get; set; } = string.Empty!;
    /// <summary>
    /// Descripción del servicio.
    /// </summary>
    public string Description { get; set; } = string.Empty!;
    /// <summary>
    /// Precio del servicio.
    /// </summary>
    public decimal Price { get; set; }
}