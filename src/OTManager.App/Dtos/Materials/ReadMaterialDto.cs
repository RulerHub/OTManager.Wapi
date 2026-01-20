namespace OTManager.App.Dtos.Materials;

public class ReadMaterialDto
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MeasureUnit { get; set; } = string.Empty;
    public decimal UnitCost { get; set; }
}
