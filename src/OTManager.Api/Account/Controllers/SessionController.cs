using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using OTManager.Api.Account.Dto;
using OTManager.Api.Account.Records;
using OTManager.Api.Account.Services.Interface;
using OTManager.Data.Account;

namespace OTManager.Api.Account.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController(UserManager<ApplicationUser> userManager, IConfiguration config, SignInManager<ApplicationUser> signInManager, ISessionContext session, IJwtTokenService jwt) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly ISessionContext _session = session;
    private readonly IConfiguration _config = config;
    private readonly IJwtTokenService _jwt = jwt;

    public record RegisterDto(string Email, string Password);
    public record LoginDto(string Email, string Password);

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        if (await _userManager.FindByEmailAsync(model.Email) != null)
        {
            return BadRequest("El correo ya está registrado.");
        }

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        // Asignar rol por defecto
        await _userManager.AddToRoleAsync(user, "User");

        return Ok("Usuario registrado correctamente");
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<SessionResponse<TokenResponse>>> Login([FromBody] LoginRequestDto req)
    {
        var correlationId = _session.GetCorrelationId();

        var user = await _userManager.FindByNameAsync(req.Username);
        if (user is null || !user.EmailConfirmed)
        {
            return Unauthorized(SessionResponse<TokenResponse>.Failure("Credenciales inválidas o usuario inactivo", null, correlationId));
        }

        var ok = await _userManager.CheckPasswordAsync(user, req.Password);
        if (!ok)
        {
            // Bloqueo temporal después de varios intentos fallidos
            await _userManager.AccessFailedAsync(user);
            if (await _userManager.IsLockedOutAsync(user))
            {
                return Unauthorized(SessionResponse<TokenResponse>.Failure("Cuenta bloqueada temporalmente por múltiples intentos fallidos", null, correlationId));
            }

            return Unauthorized(SessionResponse<TokenResponse>.Failure("Credenciales inválidas", null, correlationId));
        }

        // Reiniciar contador de accesos fallidos
        await _userManager.ResetAccessFailedCountAsync(user);

        var (token, sessionInfo) = await _jwt.CreateTokenAsync(user);
        return Ok(SessionResponse<TokenResponse>.Success(token, sessionInfo, correlationId));
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // Invalidar el token si se utiliza almacenamiento de tokens
        await _signInManager.SignOutAsync();
        return Ok(new { Message = "Sesión cerrada correctamente" });
    }
}
