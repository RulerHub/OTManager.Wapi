using OTManager.Api.Account.Records;
using OTManager.Data.Account;

namespace OTManager.Api.Account.Services.Interface;

public interface IJwtTokenService
{
    Task<(TokenResponse token, SessionInfo session)> CreateTokenAsync(ApplicationUser user);
}
