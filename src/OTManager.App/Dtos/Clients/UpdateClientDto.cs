namespace OTManager.App.Dtos.Clients;

public class UpdateClientDto(string code, string name)
{
    public string Code { get; set; } = code;
    public string Name { get; set; } = name;
}
