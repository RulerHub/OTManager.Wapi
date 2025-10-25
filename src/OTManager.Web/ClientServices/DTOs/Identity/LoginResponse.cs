namespace OTManager.Web.ClientServices.DTOs.Identity
{
    public record LoginResponse
    (
        bool Success,
        string? Token,
        string? Message
    );
}
