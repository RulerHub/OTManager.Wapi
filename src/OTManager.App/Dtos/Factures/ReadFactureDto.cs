namespace OTManager.App.Dtos.Factures;

public class ReadFactureDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    public string? ClientName { get; set; }
    public Guid OrderId { get; set; }
    public string? OrderNumber { get; set; }
    public decimal TotalPrice { get; set; }
}
