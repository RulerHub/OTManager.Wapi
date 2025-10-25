using OTManager.Web.ClientServices.DTOs.Identity;

namespace OTManager.Web.ClientServices.Authorize.AuthenticationService;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);
    Task<LoginResponse?> LoginAsync(LoginRequest request);
    Task LogOutAsync();
    Task<string> GetTokenAsync();
}
