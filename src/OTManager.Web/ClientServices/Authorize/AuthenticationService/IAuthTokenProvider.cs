namespace OTManager.Web.ClientServices.Authorize.AuthenticationService
{
    public interface IAuthTokenProvider
    {
        ValueTask<string?> GetTokenAsync();
        ValueTask SetTokenAsync(string? token);
    }
}
