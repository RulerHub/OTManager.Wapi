using OTManager.Core.Entities.Abstracts;
using OTManager.Core.Enums;

namespace OTManager.Core.Entities.OT;

public class Order : Auditable<Guid>
{
    public OrderType? OrderType { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    public Client? Client { get; set; }
    public ICollection<ServiceCost> Services { get; set; } = [];
    public ICollection<MaterialCost> Materials { get; set; } = [];
    public ICollection<WorkerCost> Workers { get; set; } = [];
    public bool Status { get; set; }
    public decimal TotalCost { get; set; }
}

