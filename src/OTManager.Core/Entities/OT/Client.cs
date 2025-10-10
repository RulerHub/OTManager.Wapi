using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class Client : Auditable<Guid>
{
    public string Code { get; set; } = string.Empty!;
    public string Name { get; set; } = string.Empty!;
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<Facture> Factures { get; set; } = [];
}