namespace OTManager.App.Dtos.ServiceCosts;

public class UpdateServiceCostDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid OrderId { get; set; }
}
