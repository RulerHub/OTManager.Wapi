using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class Facture : Auditable<Guid>
{
    public string Code { get; set; } = string.Empty!;
    public Guid ClientId { get; set; }
    public Client? Client { get; set; }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public decimal TotalPrice { get; set; }
}