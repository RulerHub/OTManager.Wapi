
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using OTManager.Api.Account.Records;
using OTManager.Api.Account.Services.Interface;
using OTManager.Data.Account;

namespace OTManager.Api.Account.Services.Implement;

public class JwtTokenService(
    IConfiguration configuration,
    UserManager<ApplicationUser> users,
    RoleManager<IdentityRole<Guid>> roles) : IJwtTokenService
{
    public async Task<(TokenResponse token, SessionInfo session)> CreateTokenAsync(ApplicationUser user)
    {
        var jwtSettings = configuration.GetSection("Jwt");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now = DateTime.UtcNow;

        var userClaims = await users.GetClaimsAsync(user);
        var roleNames = await users.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var roleName in roleNames)
        {
            var role = await roles.FindByNameAsync(roleName);
            if (role is not null)
                roleClaims.AddRange(await roles.GetClaimsAsync(role));
        }

        // Normaliza permisos: tipo "perm"
        var perms = userClaims.Where(c => c.Type == "perm").Select(c => c.Value)
            .Concat(roleClaims.Where(c => c.Type == "perm").Select(c => c.Value))
            .Distinct()
            .ToList();

        var claims = new List<Claim>
        {
            new("sub", user.Id.ToString()),
            new("name", user.UserName ?? ""),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(now).ToString(), ClaimValueTypes.Integer64)
        };

        // Roles
        claims.AddRange(roleNames.Select(r => new Claim(ClaimTypes.Role, r)));
        // Permisos
        claims.AddRange(perms.Select(p => new Claim("perm", p)));

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(60),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        var session = new SessionInfo(
            user.Id,
            user.UserName ?? string.Empty,
            [.. roleNames],
            perms);

        return (new TokenResponse(jwt, token.ValidTo), session);
    }
}
