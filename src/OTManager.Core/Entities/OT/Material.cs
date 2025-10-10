using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class Material : Auditable<Guid>
{
    public string Code { get; set; } = string.Empty!;
    public string Name { get; set; } = string.Empty!;
    public string MeasureUnit { get; set; } = string.Empty!;
    public decimal UnitCost { get; set; }
}