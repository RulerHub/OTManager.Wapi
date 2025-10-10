namespace OTManager.App.Dtos.Orders;

public class ReadOrderServiceDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
