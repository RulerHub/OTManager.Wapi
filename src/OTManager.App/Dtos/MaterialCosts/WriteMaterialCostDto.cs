namespace OTManager.App.Dtos.MaterialCosts;

public class WriteMaterialCostDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MeasureUnit { get; set; } = string.Empty;
    public decimal UnitCost { get; set; }
    public decimal Quantity { get; set; }
    public Guid OrderId { get; set; }
}
