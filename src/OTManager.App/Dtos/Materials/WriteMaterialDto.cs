using System.ComponentModel.DataAnnotations;

namespace OTManager.App.Dtos.Materials;

public sealed class WriteMaterialDto
{
    [Required]
    public string Code { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string MeasureUnit { get; set; } = string.Empty;
    [Required]
    public decimal UnitCost { get; set; }
}
