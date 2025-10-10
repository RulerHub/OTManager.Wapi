namespace OTManager.App.Dtos.Factures;

public class UpdateFactureDto
{
    public string Code { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    public Guid OrderId { get; set; }
    public decimal TotalPrice { get; set; }
}
