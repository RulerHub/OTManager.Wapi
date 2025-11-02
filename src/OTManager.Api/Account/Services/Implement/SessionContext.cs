using System.Security.Claims;

using OTManager.Api.Account.Records;
using OTManager.Api.Account.Services.Interface;

namespace OTManager.Api.Account.Services.Implement;

public class SessionContext(IHttpContextAccessor http) : ISessionContext
{
    private const string PermissionClaimType = "perm";
    public SessionInfo? GetCurrent()
    {

        var u = http.HttpContext?.User;
        if (u == null || !(u.Identity?.IsAuthenticated ?? false)) return null;

        var sub = u.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? u.FindFirstValue("sub");
        if (!Guid.TryParse(sub, out var userId)) return null;


        var userName = u.Identity?.Name
            ?? u.FindFirstValue(ClaimTypes.Name)
            ?? string.Empty;

        var roles = u.FindAll(ClaimTypes.Role)
            .Select(x => x.Value).Distinct().ToArray();

        var perms = u.FindAll(PermissionClaimType)
            .Select(x => x.Value).Distinct().ToArray();

        return new SessionInfo
        (
            userId,
            userName,
            roles,
            perms
        );

    }

    public string? GetCorrelationId() => http.HttpContext?.Items["CorrelationId"] as string;

}
