using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class Worker : Auditable<Guid>
{
    public string Name { get; set; } = string.Empty!;
    public decimal HourlyRate { get; set; }
}