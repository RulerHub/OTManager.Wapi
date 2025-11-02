using OTManager.App.Dtos.Factures;
using OTManager.App.Dtos.Orders;

namespace OTManager.App.Dtos.Clients;

public class ReadClientDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty!;
    public string Name { get; set; } = string.Empty!;
    public IEnumerable<ReadOrderDto> Orders { get; set; } = new List<ReadOrderDto>();
    public IEnumerable<ReadFactureDto> Factures { get; set; } = new List<ReadFactureDto>();

    public ReadClientDto() { }
    public ReadClientDto(Guid id, string code, string name, IEnumerable<ReadOrderDto> orders, IEnumerable<ReadFactureDto> factures)
    {
        Id = id;
        Code = code;
        Name = name;
        Orders = orders;
        Factures = factures;
    }
}
