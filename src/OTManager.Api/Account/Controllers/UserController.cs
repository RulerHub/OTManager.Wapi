using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using OTManager.Data.Account;

namespace OTManager.Api.Account.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserManager<ApplicationUser> userManager, IConfiguration config, SignInManager<ApplicationUser> signInManager) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IConfiguration _config = config;
}
