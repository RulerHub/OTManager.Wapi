namespace OTManager.Web.ClientServices.DTOs.Identity;

public record UserReadDto
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IList<string> Role { get; set; } = new List<string>();
}
