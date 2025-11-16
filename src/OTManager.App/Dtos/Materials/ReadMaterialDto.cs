using OTManager.Core.Entities.Abstracts;

namespace OTManager.App.Dtos.Materials;

public class ReadMaterialDto : Auditable<Guid>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MeasureUnit { get; set; } = string.Empty;
    public decimal UnitCost { get; set; }
}
