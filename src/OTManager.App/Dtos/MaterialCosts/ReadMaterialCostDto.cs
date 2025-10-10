namespace OTManager.App.Dtos.MaterialCosts;

public class ReadMaterialCostDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MeasureUnit { get; set; } = string.Empty;
    public decimal UnitCost { get; set; }
    public decimal Quantity { get; set; }
    public decimal TotalCost { get; set; }
    public Guid OrderId { get; set; }
}
